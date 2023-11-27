using PaymentManagementApp.BusinessLayer.ViewModels;
using PaymentManagementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentManagementApp.BusinessLayer.Interfaces
{
    public interface IPaymentManagementService
    {
        List<Payment> GetAllPayments();
        Task<Payment> CreatePayment(Payment payment);
        Task<Payment> GetPaymentById(long id);
        Task<bool> DeletePaymentById(long id);
        Task<Payment> UpdatePayment(PaymentViewModel model);
    }
}
