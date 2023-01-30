using System;
using System.Collections.Generic;
using System.Text;

namespace VPM.Models.Response
{
    public class Codes
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Message { get; set; }
        public string arMessage { get; set; }
        public string afMessage { get; set; }
    }

    public class ResponseCodeHelper
    {
        public List<Codes> ModuleCodes { get; set; }
        public List<Codes> CommonCodes { get; set; }
        public List<Codes> MessengerCodes { get; set; }

    }

    public static class ResponseCodeHelpers
    {
        public static string SelectedModule { get; set; }
        public static List<Codes> ModuleCodes { get; set; }
        public static List<Codes> CommonCodes { get; set; }
        public static List<Codes> MessengerCodes { get; set; }

    }
}
