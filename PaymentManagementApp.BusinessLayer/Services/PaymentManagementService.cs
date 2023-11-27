using PaymentManagementApp.BusinessLayer.Interfaces;
using PaymentManagementApp.BusinessLayer.Services.Repository;
using PaymentManagementApp.BusinessLayer.ViewModels;
using PaymentManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManagementApp.BusinessLayer.Services
{
    public class PaymentManagementService : IPaymentManagementService
    {
        private readonly IPaymentManagementRepository _repo;

        public PaymentManagementService(IPaymentManagementRepository repo)
        {
            _repo = repo;
        }

        public async Task<Payment> CreatePayment(Payment employeePayment)
        {
            return await _repo.CreatePayment(employeePayment);
        }

        public async Task<bool> DeletePaymentById(long id)
        {
            return await _repo.DeletePaymentById(id);
        }

        public List<Payment> GetAllPayments()
        {
            return  _repo.GetAllPayments();
        }

        public async Task<Payment> GetPaymentById(long id)
        {
            return await _repo.GetPaymentById(id);
        }

        public async Task<Payment> UpdatePayment(PaymentViewModel model)
        {
           return await _repo.UpdatePayment(model);
        }
    }
}
