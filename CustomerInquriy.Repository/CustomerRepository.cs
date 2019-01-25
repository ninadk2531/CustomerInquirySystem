using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerInquiry.DAL.Entities;
using CustomerInquiry.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerInquiry.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public  async Task<Customers> RetrieveCustomersByCustomerId(int customerId)
        {
            using (CustomerDbContext db = new CustomerDbContext())
            {
                return await db.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
                
            }
        }

        public async Task<Customers> RetrieveCustomersByCustomerEmail(string customerEmail)
        {
            using (CustomerDbContext db = new CustomerDbContext())
            {
                return await db.Customers.FirstOrDefaultAsync(x => x.ContactEmail == customerEmail);
            }
        }
    }
}
