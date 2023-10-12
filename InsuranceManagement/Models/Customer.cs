using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InsuranceManagement.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Customer Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Phone Number is required.")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Phone Number is invalid.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Phone Number is invalid.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Mail { get; set; }


        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}