using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System;

namespace PaymentManagementApp.Entities
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }
        public string Reason { get; set; }
        public decimal Amount { get; set; }
        public DateTime RequestDate { get; set; }
        public bool Approved { get; set; }
    }
}
