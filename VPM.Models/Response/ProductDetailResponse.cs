using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VPM.Models.Response
{
    public class ProductDetailResponse
    {
        /// <summary>
        /// Id of the Product.
        /// </summary>
        [JsonProperty("productId")]
        public int ProductId { get; set; }
        /// <summary>
        /// Name of the Product.
        /// </summary>
        [JsonProperty("productName")]
        public string productName { get; set; }
        /// <summary>
        /// global.
        /// </summary>
        [JsonProperty("global")]
        public bool? Global { get; set; }
        /// <summary>
        /// SenderFee of the Product.
        /// </summary>
        [JsonProperty("senderFee")]
        public decimal? SenderFee { get; set; }
        /// <summary>
        /// SenderFeePercentage of the Product.
        /// </summary>
        [JsonProperty("senderFeePercentage")]
        public decimal? SenderFeePercentage { get; set; }

        /// <summary>
        /// SenderFeePercentage of the Product.
        /// </summary>
        [JsonProperty("discountPercentage")]
        public decimal? DiscountPercentage { get; set; }

        /// <summary>
        /// DenominationType of the Product.
        /// </summary>
        [JsonProperty("denominationType")]
        public byte? DenominationType { get; set; }

        /// <summary>
        /// RecipientCurrencyCode of the Product.
        /// </summary>
        [JsonProperty("recipientCurrencyCode")]
        public int? RecipientCurrencyCode { get; set; }

        /// <summary>
        /// MinRecipientDenomination of the Product.
        /// </summary>
        [JsonProperty("minRecipientDenomination")]
        public string MinRecipientDenomination { get; set; }

        /// <summary>
        /// MaxRecipientDenomination  of the Product.
        /// </summary>
        [JsonProperty("maxRecipientDenomination")]
        public string MaxRecipientDenomination { get; set; }

        /// <summary>
        /// SenderCurrencyCode  of the Product.
        /// </summary>
        [JsonProperty("senderCurrencyCode")]
        public int? SenderCurrencyCode { get; set; }

        /// <summary>
        /// MinSenderDenomination  of the Product.
        /// </summary>
        [JsonProperty("minSenderDenomination")]
        public string MinSenderDenomination { get; set; }

        /// <summary>
        /// MaxSenderDenomination   of the Product.
        /// </summary>
        [JsonProperty("maxSenderDenomination")]
        public string MaxSenderDenomination { get; set; }

        /// <summary>
        /// FixedRecipientDenominations  of the Product.
        /// </summary>
        [JsonProperty("fixedRecipientDenominations")]
        public string FixedRecipientDenominations { get; set; }

        /// <summary>
        /// FixedSenderDenominations   of the Product.
        /// </summary>
        [JsonProperty("fixedSenderDenominations")]
        public string FixedSenderDenominations { get; set; }

        /// <summary>
        /// FixedRecipientToSenderDenominationsMap of the Product.
        /// </summary>
        [JsonProperty("fixedRecipientToSenderDenominationsMap")]
        public string FixedRecipientToSenderDenominationsMap { get; set; }

        /// <summary>
        /// BrandId of the Product.
        /// </summary>
        [JsonProperty("brandId")]
        public int? BrandId { get; set; }

        /// <summary>
        /// CountryId  of the Product.
        /// </summary>
        [JsonProperty("countryId")]
        public int? CountryId { get; set; }

        /// <summary>
        /// RedeemInstructionConcise  of the Product.
        /// </summary>
        [JsonProperty("redeemInstructionConcise")]
        public string RedeemInstructionConcise { get; set; }

        /// <summary>
        /// RedeemInstrunctionVerbose   of the Product.
        /// </summary>
        [JsonProperty("redeemInstrunctionVerbose")]
        public string RedeemInstrunctionVerbose { get; set; }


        [JsonProperty("productLogoUrls")]
        public List<ProductLogoUrls> ProductLogoUrlsResponse { get; set; }

    }
    public class ProductLogoUrls
    {
        public int ProductLogoId { get; set; }
        public string LogoUrl { get; set; }
        public int? ProductId { get; set; }
    }
    public class ProductLogoUrlModel
    {
        /// <summary>
        /// logo of the Product.
        /// </summary>
        [JsonProperty("logoUrl")]
        public string LogoUrl { get; set; }
        /// <summary>
        /// id of the Product.
        /// </summary>
        [JsonProperty("logoProductId")]
        public int? LogoProductId { get; set; }
    }





}
