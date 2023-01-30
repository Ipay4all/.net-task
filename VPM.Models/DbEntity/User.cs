using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace VPM.Models.DbEntity
{
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        [Column("SId")]
        public Guid Sid { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(500)]
        public string Password { get; set; }
        [StringLength(50)]
        public string RefreshToken { get; set; }
    }
}
