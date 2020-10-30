using System.Collections.Generic;
using BuilderTestSample.Model;

namespace BuilderTestSample.Builder
{
    public class CustomerBuilder : ICustomerBuilder
    {
        private Customer _customer;
        public void Reset()
        {
            _customer = new Customer(1);
        }

        public void Build()
        {
            _customer.HomeAddress = new Address();
            _customer.CreditRating = 1;
            _customer.FirstName = "Ted";
            _customer.LastName = "Crilly";
            _customer.OrderHistory = new List<Order>();
            _customer.TotalPurchases = 3.4m;
        }

        public Customer GetProduct()
        {
            return _customer;
        }
    }
}
