
using Moq;
using PaymentManagementApp.BusinessLayer.Interfaces;
using PaymentManagementApp.BusinessLayer.Services;
using PaymentManagementApp.BusinessLayer.Services.Repository;
using PaymentManagementApp.BusinessLayer.ViewModels;
using PaymentManagementApp.DataLayer;
using PaymentManagementApp.Entities;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace PaymentManagementApp.Tests.TestCases
{
     public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly PaymentManagementAppDbContext _dbContext;

        private readonly IPaymentManagementService  _paymentService;
        public readonly Mock<IPaymentManagementRepository> paymentservice= new Mock<IPaymentManagementRepository >();

        private readonly Payment _payment;
        private readonly PaymentViewModel _paymentViewModel;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
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
        public async Task<bool> Testfor_Create_Payment()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                paymentservice.Setup(repos => repos.CreatePayment(_payment)).ReturnsAsync(_payment);
                var result = await  _paymentService.CreatePayment(_payment);
                //Assertion
                if (result != null)
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
        public async Task<bool> Testfor_Update_Payment()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
           
            //Action
            try
            {
                paymentservice.Setup(repos => repos.UpdatePayment(_paymentViewModel)).ReturnsAsync(_payment); 
                var result = await  _paymentService.UpdatePayment(_paymentViewModel);
                if (result != null)
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
        public async Task<bool> Testfor_GetPaymentById()
        {
            //Arrange
            var res = false;
            int id = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                paymentservice.Setup(repos => repos.GetPaymentById(id)).ReturnsAsync(_payment);
                var result = await  _paymentService.GetPaymentById(id);
                //Assertion
                if (result != null)
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
        public async Task<bool> Testfor_DeletePaymentById()
        {
            //Arrange
            var res = false;
            int id = 1;
            bool response = true;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                paymentservice.Setup(repos => repos.DeletePaymentById(id)).ReturnsAsync(response);
                var result = await  _paymentService.DeletePaymentById(id);
                //Assertion
                if (result != null)
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