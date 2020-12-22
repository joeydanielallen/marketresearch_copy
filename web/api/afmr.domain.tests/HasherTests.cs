using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace afmr.domain.tests
{
    public class HasherTests
    {
        [Fact]
        public void TestHash()
        {
            var hash = domain.Security.Hasher.ComputeHash("bret.boyd@sustainment.tech", "bret.boyd@sustainment.tech");
            System.Diagnostics.Debug.WriteLine(hash);
            Assert.True(hash.Length > 0, "Hashed value should exist");
        }
    }
}
