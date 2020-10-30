using BuilderTestSample.Model;

namespace BuilderTestSample.Builder
{
    internal class AddressBuilder : IAddressBuilder
    {
        private  Address _address;
        public void Reset()
        {
            _address = new Address();
        }

        public void Build()
        {
            _address.City = "CITY";
            _address.Country = "Ireland";
            _address.PostalCode = "BT564RT";
            _address.State = "N/A";
            _address.Street1 = "STREET1";
            _address.Street2 = "STREET2";
            _address.Street3 = "CITY";
        }

        public Address GetProduct()
        {
            return _address;
        }
    }
}
