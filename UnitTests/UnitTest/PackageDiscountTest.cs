using ExternalServices;
using ExternalServices.Stubs;
using NUnit.Framework;

namespace SSE.Tests.UnitTest
{
    public class PackageDiscountTest
    {
        private readonly IDiscountService _discountService = new DiscountService(new Util());

        [Test]
        public void Customers_WithBasicBroadband_Only1Fuel()
        {
            var customerPackage = new PackageServiceStub().GetPackage("1");
            var discount = _discountService.PackageDiscount(customerPackage);
            Assert.AreEqual(0, discount.DiscountValue);
            Assert.AreEqual(DiscountType.None, discount.DiscountType);

            customerPackage = new PackageServiceStub().GetPackage("2");
            discount = _discountService.PackageDiscount(customerPackage);
            Assert.AreEqual(0, discount.DiscountValue);
            Assert.AreEqual(DiscountType.None, discount.DiscountType);
        }

        [Test]
        public void Customers_WithBasicBroadband_DualFuel()
        {
            var customerPackage = new PackageServiceStub().GetPackage("3");
            var discount = _discountService.PackageDiscount(customerPackage);
            Assert.AreEqual(5, discount.DiscountValue);
            Assert.AreEqual(DiscountType.PackageDiscount, discount.DiscountType);
        }

        [Test]
        public void Customers_WithHighSpeedBroadband_Only1Fuel()
        {
            var customerPackage = new PackageServiceStub().GetPackage("4");
            var discount = _discountService.PackageDiscount(customerPackage);
            Assert.AreEqual(5, discount.DiscountValue);
            Assert.AreEqual(DiscountType.PackageDiscount, discount.DiscountType);

            customerPackage = new PackageServiceStub().GetPackage("5");
            discount = _discountService.PackageDiscount(customerPackage);
            Assert.AreEqual(5, discount.DiscountValue);
            Assert.AreEqual(DiscountType.PackageDiscount, discount.DiscountType);
        }

        [Test]
        public void Customers_WithHighSpeedBroadband_DualFuel()
        {
            var customerPackage = new PackageServiceStub().GetPackage("6");
            var discount = _discountService.PackageDiscount(customerPackage);
            Assert.AreEqual(10, discount.DiscountValue);
            Assert.AreEqual(DiscountType.PackageDiscount, discount.DiscountType);
        }
    }
}
