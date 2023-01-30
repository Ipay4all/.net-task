using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VPM.Common;
using VPM.Domain.Interface;
using VPM.Models.CustomModels;
using VPM.Models.Request;
using VPM.Models.Response;

namespace VPM.Controllers
{
    [Route("v1/Products")]
    [ApiController]
    public class ProductController : BaseController
    {
        public IProduct _Product { get; set; }
        public ProductController(IProduct Product)
        {
            _Product = Product;
        }
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(List<ProductListResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> List([FromQuery] SearchRequestModel model)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters = FillParamesFromModel(model);
            var list = await _Product.List(parameters);
            List<ProductListResponse> ListResponses = JsonConvert.DeserializeObject<List<ProductListResponse>>(JsonConvert.SerializeObject(list.Result));
            list.Result = ListResponses;
            return Ok(BindSearchResult(list, model, "Businesses"));
        }
        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">OK: The request was successful and the response body contains the representation requested.</response>
        /// <response code="400">BAD REQUEST: The data given in the POST or PUT failed validation. Inspect the response body for details.</response>
        /// <response code="401">UNAUTHORIZED: The supplied credentials, if any, are not sufficient to access the resource.</response>
        /// <response code="404">NOT FOUND</response>
        /// <response code="500">SERVER ERROR: We couldn't return the representation due to an internal server error.</response>
        [HttpPost]
        [Route("")]
        [Authorize]
        [ProducesResponseType(typeof(ProductDetailResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> ProductPost([FromForm][Required][CustomizeValidator(Interceptor = typeof(FluentInterceptor))] CreateProductJsonRequest model)
        {

            var mediaFiles = new List<MediaFile>();
            var mediaurls = new List<string>();
            if (Request.Form.Files != null && Request.Form.Files.Count > 0)
            {
                foreach (var file in Request.Form.Files)
                {
                    var mediaFile = new MediaFile();
                    mediaFile.filename = file.FileName.Trim('\"');
                    using (var stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream);

                        mediaFile.file = stream.ToArray();

                        if (stream != null)
                        {
                            if (!string.IsNullOrEmpty(mediaFile.filename))
                            {
                                List<string> extension = new List<string> { "jpeg", "jpg", "png" };
                                mediaFile.fileType = Path.GetExtension(mediaFile.filename).Replace('.', ' ').Trim();
                                if (!extension.Contains(mediaFile.fileType))
                                {
                                    throw new HttpStatusCodeException(StatusCodes.Status400BadRequest, "Invalid file type. Allowed file types are : 'jpeg, jpg, png'");
                                }
                                Int64 filesize = stream.Length / 1024;
                                if (filesize > 20480)
                                {
                                    throw new HttpStatusCodeException(StatusCodes.Status400BadRequest, "Please upload file with size less or equal to 20 MB");
                                }
                                mediaFile.fileSize = stream.Length;
                                mediaFiles.Add(mediaFile);
                            }
                        }
                    }
                    string blobpath = string.Empty;
                    if (mediaFile.file != null)
                    {
                        if (mediaFile.file != null)
                        {
                            var fileName = "/productimages/" + mediaFile.filename;
                            string contentType;
                            new FileExtensionContentTypeProvider().TryGetContentType(mediaFile.filename, out contentType);
                            blobpath = await AzureBlobHelper.SaveDataToAzureBlob(mediaFile.file, fileName, null, contentType);
                            mediaurls.Add(blobpath);
                        }
                    }
                }
            }
            var request = JsonConvert.DeserializeObject<CreateProductRequest>(model.ProductRequestBody);
            var data = await _Product.Post(request, mediaurls);
            return CreatedResult(data);
        }
        [HttpDelete]
        [Authorize]
        [Route("{productid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteProduct([FromRoute][Required] int productid)
        {
            await _Product.DeleteProduct(productid);
            return DeletedResult("");
        }
        [HttpGet]
        [Authorize]
        [Route("{productid}")]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProduct([FromRoute][Required] int productid)
        {
            var responseJson = await _Product.GetProduct(productid);
            ProductResponse product = JsonConvert.DeserializeObject<ProductResponse>(responseJson);
            return Ok(product);

        }
        #region Update Business
        /// <summary>
        /// Update Business
        /// </summary>                
        /// <param name="model">Business request model</param>
        /// <param name="business_sid">SID of Business.</param>        
        /// <response code="200">OK: The request was successful and the response body contains the representation requested.</response>
        /// <response code="400">BAD REQUEST: The data given in the POST or PUT failed validation. Inspect the response body for details.</response>
        /// <response code="401">UNAUTHORIZED: The supplied credentials, if any, are not sufficient to access the resource.</response>
        /// <response code="404">NOT FOUND</response>
        /// <response code="500">SERVER ERROR: We couldn't return the representation due to an internal server error.</response>
        [HttpPut]
        [Authorize]
        [Route("{productid}")]
        [ProducesResponseType(typeof(ProductDetailResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> update([FromRoute][Required] int productid, [FromForm][Required][CustomizeValidator(Interceptor = typeof(FluentInterceptor))] CreateProductJsonRequest model)
        {
            var isExists = await _Product.ValidateProductId(productid);
            if (!isExists)
            {
                throw new HttpStatusCodeException(StatusCodes.Status404NotFound, "Product not exists", "5");
            }
            var mediaFiles = new List<MediaFile>();
            var mediaurls = new List<string>();
            if (Request.Form.Files != null && Request.Form.Files.Count > 0)
            {
                foreach (var file in Request.Form.Files)
                {
                    var mediaFile = new MediaFile();
                    mediaFile.filename = file.FileName.Trim('\"');
                    using (var stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream);

                        mediaFile.file = stream.ToArray();

                        if (stream != null)
                        {
                            if (!string.IsNullOrEmpty(mediaFile.filename))
                            {
                                List<string> extension = new List<string> { "jpeg", "jpg", "png" };
                                mediaFile.fileType = Path.GetExtension(mediaFile.filename).Replace('.', ' ').Trim();
                                if (!extension.Contains(mediaFile.fileType))
                                {
                                    throw new HttpStatusCodeException(StatusCodes.Status400BadRequest, "Invalid file type. Allowed file types are : 'jpeg, jpg, png'");
                                }
                                Int64 filesize = stream.Length / 1024;
                                if (filesize > 20480)
                                {
                                    throw new HttpStatusCodeException(StatusCodes.Status400BadRequest, "Please upload file with size less or equal to 20 MB");
                                }
                                mediaFile.fileSize = stream.Length;
                                mediaFiles.Add(mediaFile);
                            }
                        }
                    }
                    string blobpath = string.Empty;
                    if (mediaFile.file != null)
                    {
                        if (mediaFile.file != null)
                        {
                            var fileName = "/productimages/" + mediaFile.filename;
                            string contentType;
                            new FileExtensionContentTypeProvider().TryGetContentType(mediaFile.filename, out contentType);
                            blobpath = await AzureBlobHelper.SaveDataToAzureBlob(mediaFile.file, fileName, null, contentType);
                            mediaurls.Add(blobpath);
                        }
                    }
                }
            }
            var request = JsonConvert.DeserializeObject<CreateProductRequest>(model.ProductRequestBody);
            var data = await _Product.Update(request, mediaurls, productid);
            return CreatedResult(data);
        }
        #endregion
    }
}
