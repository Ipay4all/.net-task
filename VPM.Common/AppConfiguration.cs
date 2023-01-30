using System;
using System.Collections.Generic;
using System.Text;

namespace VPM.Common
{
    public static class AppConfiguration
    {
        public static string ValidIssuer = string.Empty;
        public static string ValidAudience = string.Empty;
        public static string IssuerSigningKeyBytes = string.Empty;

        public static int ExpiryMins = 600;
        public static int SuperExpiryMins = 600;
        public static int InternalExpiryMins = 600;
        public static string SaltKey { get; set; }
        public static string RadisCacheKeyForAppId { get; set; }
        public static string RadisCacheKeyForIATACode { get; set; }
        public static string BlobStorageConnectionString = "";
        public static string BlobstorageContainers = "";
        public static string DocumentsCDNStoragePath = "";
        public static string BlobStorageBaseURL = "";
        public static long AllowedDocumentMaxFileSize = 0;

        public static string SendGridApiKey = "";
        public static string SendGridFromEmail = "";
        public static string SendGridFromName = "";
        public static string SendGridCCEmail = "";
        public static string CommonDateFormat = "";
        public static string CommonDateTimeFormat = "";
        public static string superGlobalAdminUrl = "";
        public static string superGlobalPostfix = "";
        public static string Version = "";
        public static string PartsApiBaseUrl = "";
        public static TimeZoneInfo time_zone_info { get; set; }

        public static string JwtKey = "";
        public static string JwtIssuer = "";
        public static string JwtAudience = "";
        public static string token = "";

        public static string MessangerEngineBaseUrl = "";
        public static string MessangerEngineVersion = "";
        public static string MessangerEngineSendMessageUrl = "";
        public static string MessangerEngineCreateChannelUrl = "";
        public static string MessangerEngineAddMemberUrl = "";

        public static string ApplicationID = "";
        public static string TenantID = "";
        public static string OrganisationID = "";
        public static string GalleryCDNStoragePath = "";

        public static string XMPPServerUrl = "";
        public static string XMPPVirtaulHost = "";
        public static string XMPPMCService = "";
        public static string FromEmailAddress = "";

        public static string FirebaseSenderId { get; set; }
        public static string FirebaseServerKey { get; set; }
        public static string FirebaseURL { get; set; }

        public static string TextAnyWhereAPIURL { get; set; }
        public static string TextAnyWhereUsername { get; set; }
        public static string TextAnyWherePassword { get; set; }

        public static int ResetLoginAttempsInHrs { get; set; }
        public static int NoFailedLoginAttemps { get; set; }


        public static string StripeSuccessUrl { get; set; }
        public static string StripeCancelUrl { get; set; }

        public static int ExpireReminderDays = 7;

        public static string SupportEmail = "";
        public static string SupportPhone = "";
        public static string AzureTableStorageAccount = "";
        public static string tableStorageName = "";
        public static string MongoDBUrl = "";
        public static bool IsInsertInMongoDB { get; set; }

        public static string SmtpSenderId { get; set; }
        public static string SmtpHost { get; set; }
        public static int SmtpPort { get; set; }
        public static string SmtpPassword { get; set; }
        static AppConfiguration()
        {
            var Configuration = ConfigHelper.GetConfig();


            ValidIssuer = !string.IsNullOrWhiteSpace(Configuration["ValidIssuer"]) ? Configuration["ValidIssuer"] : "";
            ValidAudience = !string.IsNullOrWhiteSpace(Configuration["ValidAudience"]) ? Configuration["ValidAudience"] : "";
            IssuerSigningKeyBytes = !string.IsNullOrWhiteSpace(Configuration["IssuerSigningKeyBytes"]) ? Configuration["IssuerSigningKeyBytes"] : "";
            ExpiryMins = !string.IsNullOrWhiteSpace(Configuration["ExpiryMins"]) ? Convert.ToInt32(Configuration["ExpiryMins"]) : 600;
            SuperExpiryMins = !string.IsNullOrWhiteSpace(Configuration["SuperExpiryMins"]) ? Convert.ToInt32(Configuration["SuperExpiryMins"]) : 600;
            InternalExpiryMins = !string.IsNullOrWhiteSpace(Configuration["InternalExpiryMins"]) ? Convert.ToInt32(Configuration["InternalExpiryMins"]) : 600;
            SaltKey = !string.IsNullOrWhiteSpace(Configuration["saltKey"]) ? Configuration["saltKey"] : "";
            RadisCacheKeyForAppId = !string.IsNullOrWhiteSpace(Configuration["RadisCacheKeyForAppId"]) ? Configuration["RadisCacheKeyForAppId"] : "Glo_Account_";
            BlobStorageConnectionString = !string.IsNullOrWhiteSpace(Configuration["BlobStorageConnection"]) ? Configuration["BlobStorageConnection"] : "";
            BlobstorageContainers = !string.IsNullOrWhiteSpace(Configuration["BlobStorageContainer"]) ? Configuration["BlobStorageContainer"] : "";

            MessangerEngineBaseUrl = !string.IsNullOrWhiteSpace(Configuration["MessangerEngineBaseUrl"]) ? Configuration["MessangerEngineBaseUrl"] : "";
            MessangerEngineVersion = !string.IsNullOrWhiteSpace(Configuration["MessangerEngineVersion"]) ? Configuration["MessangerEngineVersion"] : "";
            MessangerEngineSendMessageUrl = !string.IsNullOrWhiteSpace(Configuration["MessangerEngineSendMessageUrl"]) ? Configuration["MessangerEngineSendMessageUrl"] : "";
            MessangerEngineCreateChannelUrl = !string.IsNullOrWhiteSpace(Configuration["MessangerEngineCreateChannelUrl"]) ? Configuration["MessangerEngineCreateChannelUrl"] : "";
            MessangerEngineAddMemberUrl = !string.IsNullOrWhiteSpace(Configuration["MessangerEngineCreateChannelUrl"]) ? Configuration["MessangerEngineCreateChannelUrl"] : "";


            DocumentsCDNStoragePath = !string.IsNullOrWhiteSpace(Configuration["DocumentsCDNStoragePath"]) ? Configuration["DocumentsCDNStoragePath"] : "";
            BlobStorageBaseURL = !string.IsNullOrWhiteSpace(Configuration["BlobStorageBaseURL"]) ? Configuration["BlobStorageBaseURL"] : "";
            AllowedDocumentMaxFileSize = !string.IsNullOrWhiteSpace(Configuration["AllowedDocumentMaxFileSize"]) ? Convert.ToInt64(Configuration["AllowedDocumentMaxFileSize"]) : 51200;
            RadisCacheKeyForIATACode = !string.IsNullOrWhiteSpace(Configuration["RadisCacheKeyForIATACode"]) ? Configuration["RadisCacheKeyForIATACode"] : "Glo_SystemIATACode_";
            SendGridApiKey = !string.IsNullOrWhiteSpace(Configuration["SendGridApiKey"]) ? Configuration["SendGridApiKey"] : "";
            SendGridFromEmail = !string.IsNullOrWhiteSpace(Configuration["SendGridFromEmail"]) ? Configuration["SendGridFromEmail"] : "";
            SendGridCCEmail = !string.IsNullOrWhiteSpace(Configuration["SendGridCCEmail"]) ? Configuration["SendGridCCEmail"] : "";
            SendGridFromName = !string.IsNullOrWhiteSpace(Configuration["SendGridFromName"]) ? Configuration["SendGridFromName"] : "";
            CommonDateFormat = !string.IsNullOrWhiteSpace(Configuration["CommonDateFormat"]) ? Configuration["CommonDateFormat"] : "dd-MM-yyyy";
            CommonDateTimeFormat = !string.IsNullOrWhiteSpace(Configuration["CommonDateTimeFormat"]) ? Configuration["CommonDateTimeFormat"] : "dd-MM-yyyy hh:mm:sss";
            superGlobalAdminUrl = !string.IsNullOrWhiteSpace(Configuration["superGlobalAdminUrl"]) ? Configuration["superGlobalAdminUrl"] : "";
            superGlobalPostfix = !string.IsNullOrWhiteSpace(Configuration["superGlobalPostfix"]) ? Configuration["superGlobalPostfix"] : "global-admin/";
            Version = !string.IsNullOrWhiteSpace(Configuration["Version"]) ? Configuration["Version"] : "v1/";
            PartsApiBaseUrl = !string.IsNullOrWhiteSpace(Configuration["PartsApiBaseUrl"]) ? Configuration["PartsApiBaseUrl"] : "";

            JwtIssuer = !string.IsNullOrWhiteSpace(Configuration["JwtIssuer"]) ? Configuration["JwtIssuer"] : "";
            JwtKey = !string.IsNullOrWhiteSpace(Configuration["JwtKey"]) ? Configuration["JwtKey"] : "";
            JwtAudience = !string.IsNullOrWhiteSpace(Configuration["JwtAudience"]) ? Configuration["JwtAudience"] : "";
            token = !string.IsNullOrWhiteSpace(Configuration["token"]) ? Configuration["token"] : "";

        }
    }
}
