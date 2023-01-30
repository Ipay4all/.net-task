using System;
using System.Collections.Generic;
using System.Text;

namespace VPM.Models.Constant
{
    public class CommonResponseCodeConstant
    {
        public const string TokenIsNotValidForApplication = "TokenIsNotValidForApplication";
        public const string InvalidPageStart = "InvalidPageStart";
        public const string InvalidPageSize = "InvalidPageSize";
        public const string RequestedModelIsNotValid = "RequestedModelIsNotValid";
        public const string PageSizeLessThan = "PageSizeLessThan";
        public const string SecretKeyIsNotValid = "SecretKeyIsNotValid";
        public const string SortingIsNotAllowed = "SortingIsNotAllowed";
        public const string RequestBodyRequired = "RequestBodyRequired";
        public const string ValueIsNotInAValidFormat = "ValueIsNotInAValidFormat";
        public const string InvalidToken = "InvalidToken";
        public const string PassAttributeNotProperFormat = "PassAttributeNotProperFormat";
        public const string FilterNotAllowedOnAttributeField = "FilterNotAllowedOnAttributeField";
        public const string FilterNotAllowedOnChannelField = "FilterNotAllowedOnChannelField";
        public const string BoolenInAValidFormat = "BoolenInAValidFormat";
        public const string PageSizeGreaterthen0 = "PageSizeGreaterthen0";
        public const string PageGreaterthen0 = "PageGreaterthen0";
        public const string InvalidJsonValue = "InvalidJsonValue";
        public const string InvalidTenantToken = "InvalidTenantToken";
        public const string Unauthorized = "Unauthorized";
        public const string InvalidFilterCondition = "InvalidFilterCondition";
    }


    public class MessengerCodeConstant
    {
        public const string MemberWithEmailAddressNotExists = "MemberWithEmailAddressNotExists";
        public const string MemberNotificationDeviceInfoNotExist = "MemberNotificationDeviceInfoNotExist";
        public const string MemberWithEmailAddressExists = "MemberWithEmailAddressExists";
        public const string MemberWithPhoneNumberExists = "MemberWithPhoneNumberExists";
        public const string InvalidUserOrPassword = "InvalidUserOrPassword";
        public const string SessionExpired = "SessionExpired";
        public const string CodeIsUsedOrInvalid = "CodeIsUsedOrInvalid";
        public const string WrongOtpEntered = "WrongOtpEntered";
        public const string OldPasswordIsWrong = "OldPasswordIsWrong";
        public const string Businessnotexist = "Businessnotexist";
        public const string BusinessnotActive = "BusinessnotActive";
        public const string NotAuthorizeMemberSID = "NotAuthorizeMemberSID";
        public const string Membernotexist = "Membernotexist";
        public const string Subscriptionplannotexist = "Subscriptionplannotexist";
        public const string FromMemberToMemberSame = "FromMemberToMemberSame";
        public const string MemberNotFound = "MemberNotFound";
        public const string InviteRequestExist = "InviteRequestExist";
        public const string InviteNotFound = "InviteNotFound";
        public const string InviteNotSentByMember = "InviteNotSentByMember";
        public const string InviteSentCanDelete = "InviteSentCanDelete";
        public const string InviteAlreadyacceptedrejected = "InviteAlreadyAcceptedRejected";
        public const string InviteNotSent = "InviteNotSent";
        public const string Businessisexist = "Businessisexist";
        public const string administratorexist = "administratorexist";
        public const string businessnamealreadyexist = "businessnamealreadyexist";
        public const string businesswebsitealreadyexist = "businesswebsitealreadyexist";
        public const string agentnotexist = "agentnotexist";
        public const string administratornotexist = "administratornotexist";
        public const string ConnectionNotFound = "ConnectionNotFound";
        public const string ConversationNotfound = "ConversationNotfound";
        public const string Invalidjsonforpersona = "Invalidjsonforpersona";
        public const string InvitationNotFound = "InvitationNotFound";
        public const string PaymentNotFound = "PaymentNotFound";
        public const string ErrorinStripeProductCreation = "ErrorinStripeProductCreation";
        public const string MemberisAddedAlready = "MemberisAddedAlready";
        public const string BusinessOfMember = "BusinessOfMember";
        public const string StripeSubscriptionNotFound = "StripeSubscriptionNotFound";
        public const string EndTimeMustLowerThanStartTime = "EndTimeMustLowerThanStartTime";
        public const string UploadLimitExceeded = "UploadLimitExceeded";
        public const string SubscriptionCoverageIsnotvalid = "SubscriptionCoverageIsnotvalid";
        public const string ValidSubscriptionIsNotExistInBusiness = "ValidSubscriptionIsNotExistInBusiness";
        public const string SubscribersExist = "SubscribersExist";
        public const string DeviceId = "DeviceId";
        public const string SuspendLogin = "SuspendLogin";
        public const string InvalidAccess = "InvalidAccess";
        public const string loginattempFail = "loginattempFail";
        public const string PasswordNotSet = "PasswordNotSet";
        public const string InvoiceAlreadyOpen = "InvoiceAlreadyOpen";

        public const string administratorrolenotexist = "administratorrolenotexist";
        public const string RegionNotExist = "RegionNotExist";
        public const string LanguageNotExist = "LanguageNotExist";
        public const string IndustryNotExist = "IndustryNotExist";
        public const string CurrencyNotExist = "CurrencyNotExist";
        public const string CountryNotExist = "CountryNotExist";
        public const string StateNotExist = "StateNotExist";
        public const string CityNotExist = "CityNotExist";
        public const string SubIndustryNotExist = "SubIndustryNotExist";
        public const string subscriptionpaymentnotexist = "subscriptionpaymentnotexist";
        public const string subscriptionpaymentsidnotvalid = "subscriptionpaymentsidnotvalid";
        public const string MemberAlreadyBlocked = "memberalreadyblocked";
        public const string MemberAlreadyMuted = "memberalreadymuted";
        public const string MemberNotMuted = "membernotmuted";
        public const string MemberNotBlocked = "membernotblocked";
        public const string MemberAddLimitexceeded = "MemberAddLimitexceeded";
        public const string AdministratorAddLimitexceeded = "MemberAddLimitexceeded";
        public const string MessageLimitexceeded = "MessageLimitexceeded";
        public const string MemberNotExistInGroup = "MemberNotExistInGroup";
        public const string MemberNotificationNotExist = "MemberNotificationNotExist";
        public const string BusinessGroupAlreadyExist = "MemberNotificationNotExist";
        public const string AdminOfAnotherBusiness = "AdminOfAnotherBusiness";
        public const string SetPAssword = "SetPassword";
        public const string PlanDelete = "PlanDelete";
        public const string PlanSuspend = "PlanSuspend";
        public const string RecureenceDuration = "RecureenceDuration";
        public const string BusinessAdminDelete = "BusinessAdminDelete";
        public const string PlanGradeExists = "PlanGradeExists";
        public const string MemberRequiredToCreateGroup = "MemberRequiredToCreateGroup";
    }
}
