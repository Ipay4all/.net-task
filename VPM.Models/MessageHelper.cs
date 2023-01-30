using VPM.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace VPM.Models
{
    public static class MessageHelper
    {
        public static Codes ReadModuleCodesMessage(string key, string StatusCode = "400", string RequestStatus = "BadRequest")
        {
            Codes codes = new Codes() { Value = StatusCode, Message = RequestStatus };
            if (ResponseCodeHelpers.ModuleCodes != null && ResponseCodeHelpers.ModuleCodes.Any())
            {
                var moduleCodes = ResponseCodeHelpers.MessengerCodes.Where(x => x.Key.ToLower() == key.ToLower()).FirstOrDefault();
                if (moduleCodes != null && !string.IsNullOrWhiteSpace(moduleCodes.Message))
                {
                    codes.Message = moduleCodes.Message;
                    codes.Value = moduleCodes.Value;
                }
            }
            return codes;
        }

        public static Codes ReadCommonCodesMessage(string key, string StatusCode = "400", string RequestStatus = "BadRequest")
        {
            Codes codes = new Codes() { Value = StatusCode, Message = RequestStatus };
            if (ResponseCodeHelpers.CommonCodes != null && ResponseCodeHelpers.CommonCodes.Any())
            {
                var commonCodes = ResponseCodeHelpers.CommonCodes.Where(x => x.Key.ToLower() == key.ToLower()).FirstOrDefault();
                BindCommonCodes(codes, commonCodes);
            }
            return codes;
        }
        private static void BindCommonCodes(Codes codes, Codes commonCodes)
        {
            if (commonCodes != null && !string.IsNullOrWhiteSpace(commonCodes.Message))
            {
                codes.Key = commonCodes.Key;
                codes.Message = commonCodes.Message;
                codes.Value = string.Format("{0}{1}", ResponseCodeHelpers.SelectedModule, commonCodes.Value);
                //codes.Message = Resources.Test;

                var currentCulture = Thread.CurrentThread.CurrentCulture;

                string lang = currentCulture.Name;
                switch (lang)
                {
                    case "ar":
                        codes.Message = commonCodes.arMessage;
                        break;
                    case "af":
                        codes.Message = commonCodes.afMessage;
                        break;
                    default:
                        codes.Message = commonCodes.Message;
                        break;
                }
            }
        }

       


    }
}
