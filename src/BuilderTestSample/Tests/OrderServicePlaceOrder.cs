using BuilderTestSample.Exceptions;
using BuilderTestSample.Services;
using BuilderTestSample.Tests.TestBuilders;
using Xunit;

namespace BuilderTestSample.Tests
{
    public class OrderServicePlaceOrder
    {
        private readonly OrderService _orderService = new OrderService();
        private readonly OrderBuilder _orderBuilder = new OrderBuilder();


        [Fact]
        public void ThrowsExceptionGivenOrderWithExistingId()
        {
            var order = _orderBuilder
                .WithTestValues()
                .Id(123)
                .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }



        [Fact]
        public void OrderIDShouldBeZeroOnNewOrder()
        {
            var order = _orderBuilder.WithTestValues().Id(0).Build();

            Assert.Equal(0, order.Id);
        }

        [Fact]
        public void OrderAmountMustBeGreaterThanZero()
        {
            var order = _orderBuilder.WithTestValues().Id(123).Build();

            Assert.NotEqual(0, order.TotalAmount);
        }

        [Fact]
        public void OrderMustHaveACustomer()
        {
            var order = _orderBuilder.WithTestValues().Id(123).Build();

            Assert.NotNull(order.Customer);
        }

        [Fact]
        public void CustomerMustHaveAnIdGreaterThan0()
        {
            var order = _orderBuilder.WithTestValues().Id(123).Build();


            Assert.NotEqual(0, order.Customer.Id);
        }

        [Fact]
        public void CustomerMustHaveAnAddress()
        {
            var order = _orderBuilder.WithTestValues().Id(123).Build();

            Assert.NotNull(order.Customer.HomeAddress);
        }

        [Fact]
        public void CustomerMustHaveFirstAndLastName()
        {
            var order = _orderBuilder.WithTestValues().Id(123).Build();

            Assert.NotEqual(string.Empty, order.Customer.FirstName);
            Assert.NotEqual(string.Empty, order.Customer.LastName);
        }

        [Fact]
        public void CustomerMustHaveCreditRatingOverThan200()
        {
            var order = _orderBuilder.WithTestValues().Id(123).Build();

            Assert.True(order.Customer.CreditRating > 200);
        }

        [Fact]
        public void CustomerMustHaveTotalPurchaseGreaterThanZero()
        {
            var order = _orderBuilder.WithTestValues().Id(123).Build();

            Assert.True(order.Customer.TotalPurchases > 0);
        }

        [Fact]
        public void CustomerStreetOneIsRequired()
        {
            var order = _orderBuilder.WithTestValues().Id(123).Build();

            Assert.NotEqual(string.Empty, order.Customer.HomeAddress.Street1);
        }

        [Fact]
        public void CustomerCityIsRequired()
        {
            var order = _orderBuilder.WithTestValues().Id(123).Build();

            Assert.NotEqual(string.Empty, order.Customer.HomeAddress.City);
        }

        [Fact]
        public void CustomerStateIsRequired()
        {
            var order = _orderBuilder.WithTestValues().Id(123).Build();

            Assert.NotEqual(string.Empty, order.Customer.HomeAddress.State);
        }

        [Fact]
        public void CustomerPostCodeIsRequired()
        {
            var order = _orderBuilder.WithTestValues().Id(123).Build();

            Assert.NotEqual(string.Empty, order.Customer.HomeAddress.PostalCode);
        }

        [Fact]
        public void CustomerCountryIsRequired()
        {
            var order = _orderBuilder.WithTestValues().Id(123).Build();
            
            Assert.NotEqual(string.Empty, order.Customer.HomeAddress.Country);
        }

        [Fact]
        public void OrderIsExpeditedIsSetWhenConditionIsMet()
        {
            var order = _orderBuilder.WithTestValues().Id(0).Build();
            _orderService.PlaceOrder(order);
            Assert.True(order.IsExpedited);
        }

        [Fact]
        public void OrderIsntExpeditedWhenCondtionIsntMet()
        {
            var order = _orderBuilder.WithTestValues().Id(0).Build();
            order.Customer.CreditRating = 250;
            _orderService.PlaceOrder(order);
            Assert.False(order.IsExpedited);
        }


        [Fact]
        public void AddOrderToCustomer()
        {
            var order = _orderBuilder.WithTestValues().Id(0).Build();

            _orderService.PlaceOrder(order);

            Assert.NotEmpty(order.Customer.OrderHistory);
        }

        [Fact]
        public void CustomersTotalPurchaseUpdatedProperly()
        {
            var order = _orderBuilder.WithTestValues().Id(0).Build();
            var cost = order.Customer.TotalPurchases;
            _orderService.PlaceOrder(order);
            var newCost = order.Customer.TotalPurchases;
            Assert.NotEqual(cost,newCost);
        }
    }
}