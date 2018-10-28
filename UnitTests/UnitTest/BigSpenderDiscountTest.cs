using ExternalServices;
using ExternalServices.Stubs;
using NUnit.Framework;

namespace SSE.Tests.UnitTest
{
    public class BigSpenderDiscountTest
    {
        private IDiscountService _discountService;
        [SetUp]
        public void Initialise()
        {
            _discountService = new DiscountService(new Util());
        }

        [TestCase]
        public void BigSpenderDiscountTest_LessThanOrEqual500PerYear()
        {
            var accountHistory = new AccountsServiceStub().GetAccountHistory("1");
            var discount = _discountService.GetBigSpenderDiscount(accountHistory);
            Assert.AreEqual(0, discount.DiscountValue);
            Assert.AreEqual(DiscountType.None, discount.DiscountType);

            accountHistory = new AccountsServiceStub().GetAccountHistory("2");
            discount = _discountService.GetBigSpenderDiscount(accountHistory);
            Assert.AreEqual(0, discount.DiscountValue);
            Assert.AreEqual(DiscountType.None, discount.DiscountType);
        }

        [TestCase]
        public void BigSpenderDiscountTest_GreaterThan500PerYearButLessThanOrEqual1000()
        {
            var accountHistory = new AccountsServiceStub().GetAccountHistory("3");
            var discount = _discountService.GetBigSpenderDiscount(accountHistory);
            Assert.AreEqual(0.25, discount.DiscountValue);
            Assert.AreEqual(DiscountType.BigSpenderDiscount, discount.DiscountType);
        }

        [TestCase]
        public void BigSpenderDiscountTest_GreaterThan1000PerYearButLessThanOrEqual2000()
        {
            var accountHistory = new AccountsServiceStub().GetAccountHistory("4");
            var discount = _discountService.GetBigSpenderDiscount(accountHistory);
            Assert.AreEqual(0.5, discount.DiscountValue);
            Assert.AreEqual(DiscountType.BigSpenderDiscount, discount.DiscountType);
        }

        [TestCase]
        public void BigSpenderDiscountTest_GreaterThan2000PerYearButLessThanOrEqual5000()
        {
            var accountHistory = new AccountsServiceStub().GetAccountHistory("5");
            var discount = _discountService.GetBigSpenderDiscount(accountHistory);
            Assert.AreEqual(1, discount.DiscountValue);
            Assert.AreEqual(DiscountType.BigSpenderDiscount, discount.DiscountType);

            accountHistory = new AccountsServiceStub().GetAccountHistory("6");
            discount = _discountService.GetBigSpenderDiscount(accountHistory);
            Assert.AreEqual(1, discount.DiscountValue);
            Assert.AreEqual(DiscountType.BigSpenderDiscount, discount.DiscountType);
        }

        [TestCase]
        public void BigSpenderDiscountTest_Greater5000()
        {
            var accountHistory = new AccountsServiceStub().GetAccountHistory("7");
            var discount = _discountService.GetBigSpenderDiscount(accountHistory);
            Assert.AreEqual(2, discount.DiscountValue);
            Assert.AreEqual(DiscountType.BigSpenderDiscount, discount.DiscountType);
        }

        #region New Requirement Tests - With Customer Types

        [TestCase]
        public void GoldCustomerType_GreaterThan1000()
        {
            var accountHistory = new AccountsServiceStub().GetAccountHistory("4");
            var discount = _discountService.GetBigSpenderDiscount(accountHistory, CustomerType.Gold);
            Assert.AreEqual(2, discount.DiscountValue);
            Assert.AreEqual(DiscountType.BigSpenderDiscount, discount.DiscountType);
        }

        [Test]
        public void SilverCustomerType_GreaterThan2000()
        {
            var accountHistory = new AccountsServiceStub().GetAccountHistory("5");
            var discount = _discountService.GetBigSpenderDiscount(accountHistory, CustomerType.Silver);
            Assert.AreEqual(2, discount.DiscountValue);
            Assert.AreEqual(DiscountType.BigSpenderDiscount, discount.DiscountType);
        }

        [Test]
        public void BronzeCustomerType_GreaterThan3000()
        {
            var accountHistory = new AccountsServiceStub().GetAccountHistory("6");
            var discount = _discountService.GetBigSpenderDiscount(accountHistory, CustomerType.Bronze);
            Assert.AreEqual(1, discount.DiscountValue);
            Assert.AreEqual(DiscountType.BigSpenderDiscount, discount.DiscountType);
        }

        #endregion

    }
}
