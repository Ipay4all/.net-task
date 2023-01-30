using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VPM.Common;
using VPM.Domain.Interface;
using VPM.Infrastructure.SpRepository;
using VPM.Infrastructure.UnitOfWork;
using VPM.Models.CustomModels;
using VPM.Models.DbEntity;
using VPM.Models.Eums;
using VPM.Models.Request;
using VPM.Models.Response;

namespace VPM.Domain.Implementation
{
    public class Products : IProduct
    {
        public IUnitOfWork uow;
        private readonly SpContext _dataContext;
        public Products(IUnitOfWork unitOfWork, SpContext dataContext)
        {
            uow = unitOfWork;
            _dataContext = dataContext;
        }

        public async Task<ProductDetailResponse> Post(CreateProductRequest model, List<string> files)
        {
            var productDocument = CommonHelper.ToDocumentData<CreateProductRequest, Product>(model);
            productDocument.ProductLogoUrls = new List<Models.DbEntity.ProductLogoUrl>();
            foreach (var item in files)
            {
                if (item != null)
                {
                    productDocument.ProductLogoUrls.Add(new Models.DbEntity.ProductLogoUrl()
                    {
                        LogoUrl = item
                    });
                }
            }

            await uow.RepositoryAsync<Product>().InsertAsync(productDocument);
            await uow.CommitAsync();
            var productDetailResponse = CommonHelper.ToDocumentData<Product, ProductDetailResponse>(productDocument);

            List<ProductLogoUrls> list = new List<ProductLogoUrls>();
            foreach (var item in productDocument.ProductLogoUrls)
            {
                if (item != null)
                {

                    list.Add(new ProductLogoUrls()
                    {
                        LogoUrl = item.LogoUrl,
                        ProductLogoId = item.ProductLogoId,
                        ProductId = item.ProductId
                    });
                }
            }
            productDetailResponse.ProductLogoUrlsResponse = list;
            return productDetailResponse;
        }
        public async Task DeleteProduct(int id)
        {
            var data = await uow.RepositoryAsync<Product>().SingleOrDefaultAsync(t => t.ProductId == id);
            if (data == null)
            {
                throw new HttpStatusCodeException(StatusCodes.Status404NotFound, "Product not exists with given id", "4");
            }
            data.Status = (int)StatusTypeDB.Delete;
            uow.RepositoryAsync<Product>().Update(data);
            await uow.CommitAsync();
        }
        public async Task<Page> List(Dictionary<string, object> parameters)
        {
            var xmlParam = CommonHelper.DictionaryToXml(parameters, "Search");
            string sqlQuery = "Exec sp_get_product_list {0}";
            object[] param = { xmlParam };
            var result = await _dataContext.ExecuteStoreProcedureForSearchList(sqlQuery, param);
            return result;

        }

        public async Task<string> GetProduct(int productId)
        {
            var isExists = await ValidateProductId(productId);
            if (!isExists)
            {
                throw new HttpStatusCodeException(StatusCodes.Status404NotFound, "Product not exists", "5");
            }
            string sqlQuery = "Exec sp_get_product {0}";
            object[] parameters = { productId };
            var stringJson = await _dataContext.ExecuteStoreProcedure(sqlQuery, parameters);
            return stringJson;
        }

        public async Task<bool> ValidateProductId(int productId)
        {
            var product = await uow.RepositoryAsync<Product>().SingleOrDefaultAsync(p => p.ProductId == productId && p.Status != (int)StatusTypeDB.Delete);
            if (product == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<ProductDetailResponse> Update(CreateProductRequest model, List<string> files,int ProductId)
        {
            var result = await this.GetObj(ProductId);
            if (result == null)
            {
                throw new HttpStatusCodeException(StatusCodes.Status404NotFound, "Product not exists", "5");
            }
            #region product
            result.ProductName = model.ProductName;
            result.Global = model.Global;
            result.SenderFee = model.SenderFee;            
            result.SenderFeePercentage = model.SenderFeePercentage;
            result.DiscountPercentage = model.DiscountPercentage;
            result.DenominationType = model.DenominationType;
            result.RecipientCurrencyCode = model.RecipientCurrencyCode;
            result.MinRecipientDenomination = model.MinRecipientDenomination    ;
            result.MaxRecipientDenomination = model.MaxRecipientDenomination;
            result.SenderCurrencyCode = model.SenderCurrencyCode;            
            result.MinSenderDenomination = model.MinSenderDenomination;
            result.MaxSenderDenomination = model.MaxSenderDenomination;
            result.FixedRecipientDenominations = model.FixedRecipientDenominations;
            result.FixedSenderDenominations =model.FixedSenderDenominations;
            result.FixedRecipientToSenderDenominationsMap = model.FixedRecipientToSenderDenominationsMap;
            result.BrandId = result.BrandId;
            result.CountryId = result.CountryId;
            result.RedeemInstructionConcise = result.RedeemInstructionConcise;
            result.RedeemInstrunctionVerbose = result.RedeemInstrunctionVerbose;
            #endregion Business
                        
            result.ProductLogoUrls = new List<Models.DbEntity.ProductLogoUrl>();
            foreach (var item in files)
            {
                if (item != null)
                {
                    result.ProductLogoUrls.Add(new Models.DbEntity.ProductLogoUrl()
                    {
                        LogoUrl = item
                    });
                }
            }


            #region deleteimages 
            if (model.imagedelete != null)
            {
                foreach (var item in model.imagedelete)
                {
                    var data = await uow.RepositoryAsync<Models.DbEntity.ProductLogoUrl>().SingleOrDefaultAsync(t => t.ProductLogoId == item && t.Status != 3);
                    if (data != null)
                    {
                        data.Status = (int)StatusTypeDB.Delete;
                        uow.RepositoryAsync<Models.DbEntity.ProductLogoUrl>().Update(data);
                    }

                }
            }
            #endregion deleteimage

            uow.RepositoryAsync<Product>().Update(result);
            await uow.CommitAsync();
            
            var productDetailResponse = CommonHelper.ToDocumentData<Product, ProductDetailResponse>(result);
            List<ProductLogoUrls> list = new List<ProductLogoUrls>();
            foreach (var item in result.ProductLogoUrls)
            {
                if (item != null && item.Status!=3)
                {

                    list.Add(new ProductLogoUrls()
                    {
                        LogoUrl = item.LogoUrl,
                        ProductLogoId = item.ProductLogoId,
                        ProductId = item.ProductId
                    });
                }
            }
            productDetailResponse.ProductLogoUrlsResponse = list;
            return productDetailResponse;
        }


        #region Getobj
        public async Task<Product> GetObj(int productId)
        {
            var data = await uow.RepositoryAsync<Product>().SingleOrDefaultAsync(t => t.ProductId == productId && t.Status != (int)StatusTypeDB.Delete);
            return data;
        }
        #endregion Getobj
    }
}
