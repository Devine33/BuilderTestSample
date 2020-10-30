using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderTestSample.Builder
{
    public interface IAddressBuilder
    {
        void Reset();
        void Build();
    }
}
