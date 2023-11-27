
using Moq;
using PaymentManagementApp.BusinessLayer.Interfaces;
using PaymentManagementApp.BusinessLayer.Services.Repository;
using PaymentManagementApp.BusinessLayer.Services;
using PaymentManagementApp.BusinessLayer.ViewModels;
using PaymentManagementApp.DataLayer;
using PaymentManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace PaymentManagementApp.Tests.TestCases
{
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly PaymentManagementAppDbContext _dbContext;

        private readonly IPaymentManagementService  _paymentService;
        public readonly Mock<IPaymentManagementRepository> paymentservice = new Mock<IPaymentManagementRepository>();

        private readonly Payment _payment;
        private readonly PaymentViewModel _paymentViewModel;

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
        {
             _paymentService = new PaymentManagementService(paymentservice.Object);

            _output = output;

            _payment = new Payment
            {
                PaymentId = 1,
                Reason = "Product not as described",
                Amount = 25.50m,
                RequestDate = DateTime.Now.AddDays(-5),
                Approved = true
            };

            _paymentViewModel = new PaymentViewModel
            {
                PaymentId = 1,
                Reason = "Product not as described",
                Amount = 25.50m,
                RequestDate = DateTime.Now.AddDays(-5),
                Approved = true
            };
        }
        
        [Fact]
        public async Task<bool> Testfor_Payment_Reason_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                paymentservice.Setup(repo => repo.CreatePayment(_payment)).ReturnsAsync(_payment);
                var result = await  _paymentService.CreatePayment(_payment);
                var actualLength = _payment.Reason.ToString().Length;
                if (result.Reason.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

       
        [Fact]
        public async Task<bool> Testfor_Payment_Amount_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                paymentservice.Setup(repo => repo.CreatePayment(_payment)).ReturnsAsync(_payment);
                var result = await  _paymentService.CreatePayment(_payment);
                var actualLength = _payment.Amount.ToString().Length;
                if (result.Amount.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Payment_Date_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                paymentservice.Setup(repo => repo.CreatePayment(_payment)).ReturnsAsync(_payment);
                var result = await  _paymentService.CreatePayment(_payment);
                var actualLength = _payment.RequestDate.ToString().Length;
                if (result.RequestDate.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_PaymentId_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                paymentservice.Setup(repo => repo.CreatePayment(_payment)).ReturnsAsync(_payment);
                var result = await  _paymentService.CreatePayment(_payment);
                var actualLength = _payment.PaymentId.ToString().Length;
                if (result.PaymentId.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


    }
}