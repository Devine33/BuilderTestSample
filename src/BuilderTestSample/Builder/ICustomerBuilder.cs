using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderTestSample.Builder
{
    public interface ICustomerBuilder
    {
        void Reset();
        void Build();
    }
}
