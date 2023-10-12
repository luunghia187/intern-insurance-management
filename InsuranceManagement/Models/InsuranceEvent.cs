using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InsuranceManagement.Models
{
    public class InsuranceEvent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InsuranceEventId { get; set; }
        public int ContractId { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public decimal Refund { get; set; }

        public virtual Contract contract { get; set; }
    }
}