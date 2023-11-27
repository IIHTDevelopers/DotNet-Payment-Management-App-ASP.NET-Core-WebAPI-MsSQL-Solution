using Microsoft.EntityFrameworkCore;
using PaymentManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentManagementApp.DataLayer
{
    public class PaymentManagementAppDbContext : DbContext
    {
        public PaymentManagementAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Payment> Payments { get; set; }
    }

}