using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KPMG.TaxCalculator.Model
{
    public class Transaction 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 2)]
        public string Account { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Description { get; set; }
        [Required]
        [StringLength(3, MinimumLength = 3)]
        [Display(Name="Currency Code")]
        public string CurrencyCode { get; set; }
        [Required]
        public decimal Amount { get; set; }

    }
}
