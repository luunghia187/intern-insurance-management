using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InsuranceManagement.Models
{
    public enum ContractStatus
    {
        Buying,
        Pending,
        HoldOn,
        Approved
    }
    public class Contract
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractId { get; set; }
        [Required(ErrorMessage = "Customer is required.")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Agent is required.")]
        public int AgentId { get; set; }
        [Required(ErrorMessage = "Insurance is required.")]
        public int InsuranceId { get; set; }
        public DateTime SigningDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Proof { get; set; }
        public ContractStatus Status { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Agent Agent { get; set; }
        public virtual Insurance Insurance { get; set; }

        public virtual ICollection<InsuranceEvent> InsuranceEvents { get; set; }
    }
}