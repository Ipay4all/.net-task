using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace VPM.Models.DbEntity
{
    public partial class Product
    {
        public Product()
        {
            ProductLogoUrls = new HashSet<ProductLogoUrl>();
        }

        [Key]
        [Column("productId")]
        public int ProductId { get; set; }
        [Column("productName")]
        [StringLength(50)]
        public string ProductName { get; set; }
        [Column("global")]
        public bool? Global { get; set; }
        [Column("senderFee", TypeName = "numeric(18, 2)")]
        public decimal? SenderFee { get; set; }
        [Column("senderFeePercentage", TypeName = "numeric(18, 2)")]
        public decimal? SenderFeePercentage { get; set; }
        [Column("discountPercentage", TypeName = "numeric(18, 2)")]
        public decimal? DiscountPercentage { get; set; }
        [Column("denominationType")]
        public byte? DenominationType { get; set; }
        [Column("recipientCurrencyCode")]
        public int? RecipientCurrencyCode { get; set; }
        [Column("minRecipientDenomination")]
        [StringLength(50)]
        public string MinRecipientDenomination { get; set; }
        [Column("maxRecipientDenomination")]
        [StringLength(50)]
        public string MaxRecipientDenomination { get; set; }
        [Column("senderCurrencyCode")]
        public int? SenderCurrencyCode { get; set; }
        [Column("minSenderDenomination")]
        [StringLength(50)]
        public string MinSenderDenomination { get; set; }
        [Column("maxSenderDenomination")]
        [StringLength(50)]
        public string MaxSenderDenomination { get; set; }
        [Column("fixedRecipientDenominations")]
        [StringLength(50)]
        public string FixedRecipientDenominations { get; set; }
        [Column("fixedSenderDenominations")]
        [StringLength(50)]
        public string FixedSenderDenominations { get; set; }
        [Column("fixedRecipientToSenderDenominationsMap")]
        [StringLength(50)]
        public string FixedRecipientToSenderDenominationsMap { get; set; }
        [Column("brandId")]
        public int? BrandId { get; set; }
        [Column("countryId")]
        public int? CountryId { get; set; }
        [Column("redeemInstructionConcise")]
        [StringLength(500)]
        public string RedeemInstructionConcise { get; set; }
        [Column("redeemInstrunctionVerbose")]
        [StringLength(500)]
        public string RedeemInstrunctionVerbose { get; set; }

        [ForeignKey(nameof(BrandId))]
        [InverseProperty("Products")]
        public virtual Brand Brand { get; set; }
        [ForeignKey(nameof(CountryId))]
        [InverseProperty("Products")]
        public virtual Country Country { get; set; }
        [InverseProperty(nameof(ProductLogoUrl.Product))]
        public virtual ICollection<ProductLogoUrl> ProductLogoUrls { get; set; }

        [Column("status")]
        public byte? Status { get; set; }
    }
}
