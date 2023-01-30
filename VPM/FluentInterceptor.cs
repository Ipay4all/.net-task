
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using VPM.Models;
using VPM.Models.Constant;
using VPM.Models.Response;

namespace VPM
{
    /// <summary>
    /// 
    /// </summary>
    public class FluentInterceptor : IValidatorInterceptor
    {

        /// <summary>
        /// 
        /// </summary>
        public FluentInterceptor()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="validationContext"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public ValidationResult AfterMvcValidation(ControllerContext controllerContext, ValidationContext validationContext, ValidationResult result)
        {
            if (!result.IsValid)
            {
                FluentErrorResponse errorResponse = new FluentErrorResponse();
                var codes = MessageHelper.ReadCommonCodesMessage(CommonResponseCodeConstant.RequestedModelIsNotValid);
                errorResponse.Code = Convert.ToInt32(codes.Value);
                errorResponse.Status = StatusCodes.Status400BadRequest;
                errorResponse.Message = codes.Message;

                JObject jObject = new JObject();
                int i = 0;
                foreach (var item in result.Errors)
                {
                    if (!jObject.ContainsKey(item.PropertyName))
                    {
                        if (i == 0)
                            errorResponse.Message = item.ErrorMessage;
                        jObject.Add(item.PropertyName, item.ErrorMessage);
                        i++;
                    }
                }
                errorResponse.Errors = jObject;
                errorResponse.isFluentError = true;
                throw new Exception(JsonConvert.SerializeObject(errorResponse));
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public ValidationContext BeforeMvcValidation(ControllerContext controllerContext, ValidationContext validationContext)
        {
            return validationContext;
        }
    }
}
