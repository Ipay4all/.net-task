using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace VPM.Models.DbEntity
{
    public partial class ProductLogoUrl
    {
        [Key]
        public int ProductLogoId { get; set; }
        [StringLength(500)]
        public string LogoUrl { get; set; }
        public int? ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductLogoUrls")]
        public virtual Product Product { get; set; }

        [Column("status")]
        public byte? Status { get; set; }
        
    }
}
