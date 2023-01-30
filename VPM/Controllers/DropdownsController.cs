using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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


namespace VPM.Controllers
{
    [Route("v1/Dropdowns")]
    [ApiController]
    public class DropdownsController : BaseController
    {
        public IDropdowns _IdropdownDomain { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DropdownsController(IDropdowns IdropdownDomain)
        {
            _IdropdownDomain = IdropdownDomain;
        }

        [HttpGet]
        [Route("countries")]
        [ProducesResponseType(typeof(List<CountryDropdownListResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListCountryCodes([FromQuery] SearchRequestModel model)
        {
            List<CountryDropdownListResponse> listResponses = new List<CountryDropdownListResponse>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters = FillParamesFromModel(model);

            var result = await _IdropdownDomain.ListCountry(parameters);
            if (!string.IsNullOrWhiteSpace(result))
            {
                listResponses = JsonConvert.DeserializeObject<List<CountryDropdownListResponse>>(result);
            }
            return GetResult(listResponses);
        }
        [HttpGet]
        [Route("brands")]
        [ProducesResponseType(typeof(List<BrandDropdownListResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListBrand([FromQuery] SearchRequestModel model)
        {
            List<BrandDropdownListResponse> listResponses = new List<BrandDropdownListResponse>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters = FillParamesFromModel(model);

            var result = await _IdropdownDomain.ListBrand(parameters);
            if (!string.IsNullOrWhiteSpace(result))
            {
                listResponses = JsonConvert.DeserializeObject<List<BrandDropdownListResponse>>(result);
            }
            return GetResult(listResponses);
        }
        [HttpGet]
        [Route("currencies")]
        [ProducesResponseType(typeof(List<CurrencyDropdownListResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListCurrency([FromQuery] SearchRequestModel model)
        {
            List<CurrencyDropdownListResponse> listResponses = new List<CurrencyDropdownListResponse>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters = FillParamesFromModel(model);

            var result = await _IdropdownDomain.ListCurrency(parameters);
            if (!string.IsNullOrWhiteSpace(result))
            {
                listResponses = JsonConvert.DeserializeObject<List<CurrencyDropdownListResponse>>(result);
            }
            return GetResult(listResponses);
        }
    }
}
