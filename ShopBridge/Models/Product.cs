using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage ="Name can only be 50 Character long")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

    }
}
