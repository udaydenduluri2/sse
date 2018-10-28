using ExternalServices;
using ExternalServices.Stubs;
using NUnit.Framework;
using DiscountService = ExternalServices.Stubs.DiscountService;

namespace SSE.Tests.UnitTest
{
    [TestFixture]
    public class LongServiceDiscountTest
    {
        private IDiscountService _discountService;
        [SetUp]
        public void Initialise()
        {
            _discountService = new DiscountService(new Util());
        }

        [TestCase]
        public void LongServiceDiscountTest_LessThan1Year()
        {
            var customer = new CustomerServiceStub(new Util()).GetAccount("1");
            var discount = _discountService.LongServiceDiscount(customer);
            Assert.AreEqual(0, discount.DiscountValue);
            Assert.AreEqual(DiscountType.None, discount.DiscountType);
        }

        [TestCase]
        public void LongServiceDiscountTest_1To2Years()
        {
            var customer = new CustomerServiceStub(new Util()).GetAccount("2");
            var discount = _discountService.LongServiceDiscount(customer);
            Assert.AreEqual(0.25, discount.DiscountValue);
            Assert.AreEqual(DiscountType.LongServiceDiscount, discount.DiscountType);

            customer = new CustomerServiceStub(new Util()).GetAccount("3");
            discount = _discountService.LongServiceDiscount(customer);
            Assert.AreEqual(0.25, discount.DiscountValue);
            Assert.AreEqual(DiscountType.LongServiceDiscount, discount.DiscountType);
        }

        [TestCase]
        public void LongServiceDiscountTest_2To3Years()
        {
            var customer = new CustomerServiceStub(new Util()).GetAccount("4");
            var discount = _discountService.LongServiceDiscount(customer);
            Assert.AreEqual(0.5, discount.DiscountValue);
            Assert.AreEqual(DiscountType.LongServiceDiscount, discount.DiscountType);

            customer = new CustomerServiceStub(new Util()).GetAccount("5");
            discount = _discountService.LongServiceDiscount(customer);
            Assert.AreEqual(0.5, discount.DiscountValue);
            Assert.AreEqual(DiscountType.LongServiceDiscount, discount.DiscountType);
        }

        [TestCase]
        public void LongServiceDiscountTest_MoreThan3Years()
        {
            var customer = new CustomerServiceStub(new Util()).GetAccount("6");
            var discount = _discountService.LongServiceDiscount(customer);
            Assert.AreEqual(1, discount.DiscountValue);
            Assert.AreEqual(DiscountType.LongServiceDiscount, discount.DiscountType);
        }
    }
}
