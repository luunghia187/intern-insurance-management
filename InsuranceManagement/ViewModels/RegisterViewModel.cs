using InsuranceManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceManagement.ViewModels
{
    public class RegisterViewModel
    {
        public Account Account { get; set; }
        public Customer Customer { get; set; }
        public Agent Agent { get; set; }
    }
}