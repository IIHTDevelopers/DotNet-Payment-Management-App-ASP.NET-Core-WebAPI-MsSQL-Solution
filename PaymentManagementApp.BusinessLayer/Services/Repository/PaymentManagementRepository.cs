using Microsoft.EntityFrameworkCore;
using PaymentManagementApp.BusinessLayer.ViewModels;
using PaymentManagementApp.DataLayer;
using PaymentManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PaymentManagementApp.BusinessLayer.Services.Repository
{
    public class PaymentManagementRepository : IPaymentManagementRepository
    {
        private readonly PaymentManagementAppDbContext _dbContext;
        public PaymentManagementRepository(PaymentManagementAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Payment> CreatePayment(Payment PaymentModel)
        {
            try
            {
                var result = await _dbContext.Payments.AddAsync(PaymentModel);
                await _dbContext.SaveChangesAsync();
                return PaymentModel;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeletePaymentById(long id)
        {
            try
            {
                _dbContext.Remove(_dbContext.Payments.Single(a => a.PaymentId== id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Payment> GetAllPayments()
        {
            try
            {
                var result = _dbContext.Payments.
                OrderByDescending(x => x.PaymentId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Payment> GetPaymentById(long id)
        {
            try
            {
                return await _dbContext.Payments.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

       
        public async Task<Payment> UpdatePayment(PaymentViewModel model)
        {
            var Payment = await _dbContext.Payments.FindAsync(model.PaymentId);
            try
            {

                _dbContext.Payments.Update(Payment);
                await _dbContext.SaveChangesAsync();
                return Payment;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}