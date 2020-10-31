using BuilderTestSample.Exceptions;
using BuilderTestSample.Model;

namespace BuilderTestSample.Services
{
    public class OrderService
    {
        public void PlaceOrder(Order order)
        {
            ValidateOrder(order);

            ExpediteOrder(order);

            AddOrderToCustomerHistory(order);
        }

        private void ValidateOrder(Order order)
        {
            // throw InvalidOrderException unless otherwise noted.

            // DONE: order ID must be zero (it's a new order)
            // DONE: order amount must be greater than zero
            // DONE: order must have a customer (customer is not null)

            if (order.Id != 0)
                throw new InvalidOrderException("Order ID must be 0.");

            if (order.TotalAmount <= 0)
                throw new InvalidOrderException("Order total must not be less than zero");

            if (order.Customer == null)
                throw new InvalidOrderException("Order must contain a valid customer");


            ValidateCustomer(order.Customer);
        }

        private void ValidateCustomer(Customer customer)
        {
            // throw InvalidCustomerException unless otherwise noted
            // create a CustomerBuilder to implement the tests for these scenarios

            // DONE: customer must have an ID > 0
            // DONE: customer must have an address (it is not null)
            // DONE: customer must have a first and last name
            // DONE: customer must have credit rating > 200 (otherwise throw InsufficientCreditException)
            // DONE: customer must have total purchases >= 0
            if (customer.Id <= 0)
                throw new InvalidCustomerException("Customer must have an ID greater than 0");

            if (customer.HomeAddress == null)
                throw new InvalidCustomerException("Customer must have an address");

            if (customer.FirstName == string.Empty || customer.LastName == string.Empty)
                throw new InvalidCustomerException("Customers must have a first and last name.");

            if (customer.CreditRating < 200)
                throw new InvalidCustomerException("Customer must have a credit rating greater than 200.");

            if (customer.TotalPurchases <= 0.0m)
                throw new InvalidCustomerException("Customer must have a total purchase greater than 0");

            ValidateAddress(customer.HomeAddress);
        }

        private void ValidateAddress(Address homeAddress)
        {
            // throw InvalidAddressException unless otherwise noted
            // create an AddressBuilder to implement the tests for these scenarios

            // DONE: street1 is required (not null or empty)
            // DONE: city is required (not null or empty)
            // DONE: state is required (not null or empty)
            // DONE: postalcode is required (not null or empty)
            // DONE: country is required (not null or empty)
        }

        private void ExpediteOrder(Order order)
        {
            // DONE: if customer's total purchases > 5000 and credit rating > 500 set IsExpedited to true
            if (order.Customer.TotalPurchases > 5000 && order.Customer.CreditRating > 500)
            {
                order.IsExpedited = true;
            }
        }

        private void AddOrderToCustomerHistory(Order order)
        {
            // DONE : add the order to the customer
            // DONE : update the customer's total purchases property

            order.Customer.OrderHistory.Add(order);
            order.Customer.TotalPurchases += order.TotalAmount;
        }
    }
}