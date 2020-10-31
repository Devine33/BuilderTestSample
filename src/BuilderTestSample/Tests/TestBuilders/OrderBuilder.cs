using BuilderTestSample.Builder;
using BuilderTestSample.Model;

namespace BuilderTestSample.Tests.TestBuilders
{
    /// <summary>
    /// Reference: https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data
    /// </summary>
    public class OrderBuilder
    {
        private readonly Order _order = new Order();

        public OrderBuilder Id(int id)
        {
            _order.Id = id;
            return this;
        }

        public Order Build()
        {
            return _order;
        }

        public OrderBuilder WithTestValues()
        {
            _order.TotalAmount = 100m;
            var addressBuilder = new AddressBuilder();
            var customerBuilder = new CustomerBuilder();

            var addressDirector = new Director.Director(addressBuilder);
            var customerDirector = new Director.Director(customerBuilder);

            customerDirector.MakeCustomer();
            addressDirector.MakeAddress();


            _order.Customer = customerBuilder.GetProduct();
            _order.Customer.HomeAddress = addressBuilder.GetProduct();

            return this;
        }
    }
}