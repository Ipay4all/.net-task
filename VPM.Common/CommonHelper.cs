using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace VPM.Common
{
    public static class CommonHelper
    {
        public static T1 ToDocumentData<T, T1>(this T model)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T, T1>();
            });
            IMapper iMapper = config.CreateMapper();
            T1 doc = iMapper.Map<T, T1>(model);
            return doc;
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray()).ToLower();
        }
        public static string GenerateUniqueSID(string prefix)
        {
            prefix.ToUpper();
            return (prefix + Guid.NewGuid().ToString()).ToUpper();
        }
        public static bool IsValidJson(this string stringValue)
        {
            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return false;
            }
            var value = stringValue.Trim();
            if ((value.StartsWith("{") && value.EndsWith("}")) || //For object
                (value.StartsWith("[") && value.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(value);
                    return true;
                }
                catch (JsonReaderException)
                {
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }
        public static String GetNameFromJsonProperty(object className, string jsonName)
        {
            string fldName = string.Empty;
            var stringarray = jsonName.Split('.');
            List<string> stringList = new List<string>();
            for (int k = 0; k < stringarray.Count(); k++)
            {
                var jsonArray = (className.GetType().GetProperties());
                foreach (var itemJson in jsonArray)
                {
                    if (itemJson.PropertyType.Name == typeof(List<>).Name)
                    {
                        var classType = itemJson.PropertyType.GetGenericArguments()[0].Name;
                        if (itemJson.GetCustomAttribute<JsonPropertyAttribute>() != null && itemJson.GetCustomAttribute<JsonPropertyAttribute>().PropertyName == stringarray[k])
                        {
                            stringList.Add(itemJson.Name);
                            string subResponse = string.Empty;




                            k = k + 1;
                            if (!string.IsNullOrEmpty(subResponse))
                                stringList.Add(subResponse);
                        }
                    }
                    else
                    {
                        if (itemJson.GetCustomAttribute<JsonPropertyAttribute>() != null && itemJson.GetCustomAttribute<JsonPropertyAttribute>().PropertyName == stringarray[k])
                        {
                            stringList.Add(itemJson.Name);
                        }
                    }
                }
            }
            if (stringList.Count > 1)
                return String.Join(".", stringList);
            else if (stringList.Count == 1)
                return stringList[0];
            else
                return string.Empty;
        }

        public static string DictionaryToXml(Dictionary<string, object> dic, string rootElement = "Root")
        {
            string strXMLResult = string.Empty;

            if (dic != null && dic.Count > 0)
            {
                foreach (KeyValuePair<string, object> pair in dic)
                {
                    strXMLResult += "<" + pair.Key + ">" + pair.Value + "</" + pair.Key + ">";
                }

                strXMLResult = "<" + rootElement + ">" + strXMLResult + "</" + rootElement + ">";
            }

            return strXMLResult;
        }
    }
}
