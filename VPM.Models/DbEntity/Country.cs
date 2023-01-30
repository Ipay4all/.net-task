using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace VPM.Models.DbEntity
{
    public partial class Country
    {
        public Country()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("countryId")]
        public int CountryId { get; set; }
        [Column("isoName")]
        [StringLength(50)]
        public string IsoName { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("flagurl")]
        [StringLength(500)]
        public string Flagurl { get; set; }

        [InverseProperty(nameof(Product.Country))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
