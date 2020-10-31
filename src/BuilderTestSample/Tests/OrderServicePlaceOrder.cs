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
            var order = _orderBuilder.WithTestValues().Id(123).Build();

            Assert.NotEqual(0, order.Id);
        }

        [Fact]
        public void OrderAmountMustBeGreaterThanZero()
        {

        }

        [Fact]
        public void OrderMustHaveACustomer()
        {

        }

        [Fact]
        public void CustomerMustHaveAnIdGreaterThan0()
        {

        }

        [Fact]
        public void CustomerMustHaveAnAddress()
        {

        }

        [Fact]
        public void CustomerMustHaveFirstAndLastName()
        {

        }

        [Fact]
        public void CustomerMustHaveCreditRatingOverThan200()
        {

        }

        [Fact]
        public void CustomerMustHaveTotalPurchaseGreaterThanZero()
        {

        }

        [Fact]
        public void CustomerStreetOneIsRequired()
        {

        }

        [Fact]
        public void CustomerCityIsRequired()
        {

        }

        [Fact]
        public void CustomerStateIsRequired()
        {

        }

        [Fact]
        public void CustomerPostCodeIsRequired()
        {

        }

        [Fact]
        public void CustomerCountryIsRequired()
        {

        }

        [Fact]
        public void CustomerIsExpeditedIsSetWhenConditionIsMet()
        {

        }

        [Fact]
        public void AddOrderToCustomer()
        {

        }

        [Fact]
        public void CustomersTotalPurchaseUpdatedProperly()
        {

        }


    }

}
