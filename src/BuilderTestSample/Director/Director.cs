using System;
using System.Collections.Generic;
using System.Text;
using BuilderTestSample.Builder;
using BuilderTestSample.Model;

namespace BuilderTestSample.Director
{

    public class Director
    {
        private readonly IAddressBuilder _addressBuilder;
        private readonly ICustomerBuilder _customerBuilder;

        public Director(IAddressBuilder builder)
        {
            _addressBuilder = builder;
        }

        public Director(ICustomerBuilder builder)
        {
            _customerBuilder = builder;
        }

        public void MakeAddress()
        {
            _addressBuilder.Reset();
            _addressBuilder.Build();
        }

        public void MakeCustomer()
        {
            _customerBuilder.Reset();
            _customerBuilder.Build();
        }
    }
}
