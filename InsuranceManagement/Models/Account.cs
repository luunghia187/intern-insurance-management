using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InsuranceManagement.Models
{
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }


        [Required(ErrorMessage = "Account Name is required.")]
        public string AccountName { get; set; }

        [Required(ErrorMessage = "Account Passwork is required.")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Account Password must be between 5 and 15 characters.")]
        public string AccountPassWork { get; set; }



        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

    }
}

