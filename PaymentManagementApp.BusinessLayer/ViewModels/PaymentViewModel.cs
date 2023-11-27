using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentManagementApp.BusinessLayer.ViewModels
{
    public class PaymentViewModel
    {
        public int PaymentId { get; set; }
        public string Reason { get; set; }
        public decimal Amount { get; set; }
        public DateTime RequestDate { get; set; }
        public bool Approved { get; set; }
    }
}
