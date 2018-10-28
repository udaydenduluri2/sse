using ExternalServices;
using ExternalServices.Stubs;
using NUnit.Framework;

namespace SSE.Tests.UnitTest
{
    public class IdentifyCustomerTest
    {
        [Test]
        public void CustomerIdentificationTest()
        {
            var customer = new CustomerServiceStub(new Util()).GetAccount("1");
            Assert.AreEqual(CustomerType.None, customer.CustomerType);

            customer = new CustomerServiceStub(new Util()).GetAccount("2");
            Assert.AreEqual(CustomerType.Bronze, customer.CustomerType);

            customer = new CustomerServiceStub(new Util()).GetAccount("3");
            Assert.AreEqual(CustomerType.Bronze, customer.CustomerType);

            customer = new CustomerServiceStub(new Util()).GetAccount("4");
            Assert.AreEqual(CustomerType.Silver, customer.CustomerType);

            customer = new CustomerServiceStub(new Util()).GetAccount("5");
            Assert.AreEqual(CustomerType.Silver, customer.CustomerType);

            customer = new CustomerServiceStub(new Util()).GetAccount("6");
            Assert.AreEqual(CustomerType.Gold, customer.CustomerType);

            customer = new CustomerServiceStub(new Util()).GetAccount("7");
            Assert.AreEqual(CustomerType.Gold, customer.CustomerType);

        }
    }
}
