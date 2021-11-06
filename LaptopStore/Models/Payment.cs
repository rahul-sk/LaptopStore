using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStore.Models
{
    public class Payment
    {
        
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Expiry")]
        public string Expiry { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "CVV")]
        public string CVV { get; set; }
    }
}
