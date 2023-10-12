using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InsuranceManagement.Models
{
    public class Insurance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InsuranceId { get; set; }
        [Required(ErrorMessage = "Insurance Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Year Of Payment is required.")]
        public int YearsOfPayment { get; set; }
        [Required(ErrorMessage = "Payment Per Year is required.")]
        public decimal PaymentPerYear { get; set; }
        [Required(ErrorMessage = "Account Name is required.")]
        public decimal Refund { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}