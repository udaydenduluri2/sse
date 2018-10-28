using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using ExternalServices;
using NSubstitute;
using NUnit.Framework;
using website.Controllers;

namespace SSE.Tests.UnitTest
{
    public class TariffControllerTest
    {
        private TariffController _controller;
        private ICustomerService _customerService;
        private IAccountsService _accountsService;
        private IPackageService _packageService;
        private IDiscountService _discountService;
        private ITariffService _tariffService;

        [SetUp]
        public void Initialise()
        {
            _customerService = Substitute.For<ICustomerService>();
            _packageService = Substitute.For<IPackageService>();
            _discountService = Substitute.For<IDiscountService>();
            _tariffService = Substitute.For<ITariffService>();
            _accountsService = Substitute.For<IAccountsService>();

            _controller = new TariffController(_customerService, _accountsService, _packageService, _discountService,
                _tariffService);
            _customerService.GetAccount(Arg.Any<string>()).Returns(new CustomerAccount());
            _tariffService.GetTariffInfo(Arg.Any<string>()).Returns(new TariffInfo { Tariffs = new List<Tariff>() });
        }

        [Test]
        public void GetCustomerTariffsTest_BigSpender()
        {
            _discountService.GetBigSpenderDiscount(Arg.Any<AccountHistory>()).Returns(new Discount
                {DiscountType = DiscountType.BigSpenderDiscount, DiscountValue = 2});
            _discountService.LongServiceDiscount(Arg.Any<CustomerAccount>()).Returns(new Discount
                { DiscountType = DiscountType.LongServiceDiscount, DiscountValue = 1 });
            _discountService.PackageDiscount(Arg.Any<Package>()).Returns(new Discount
                { DiscountType = DiscountType.None, DiscountValue = 0 });

            var viewResult =  _controller.GetCustomerTariffs("1");
            var tariffInfo = viewResult.Model as TariffInfo;


            Assert.IsNotNull(tariffInfo);
            Assert.IsTrue(tariffInfo.Tariffs.All(x =>
                x.Discount != null && x.Discount.DiscountType == DiscountType.BigSpenderDiscount &&
                x.Discount.DiscountValue == 2));
        }

        [Test]
        public void GetCustomerTariffsTest_LongService()
        {
            _discountService.GetBigSpenderDiscount(Arg.Any<AccountHistory>()).Returns(new Discount
                { DiscountType = DiscountType.BigSpenderDiscount, DiscountValue = 2 });
            _discountService.LongServiceDiscount(Arg.Any<CustomerAccount>()).Returns(new Discount
                { DiscountType = DiscountType.LongServiceDiscount, DiscountValue = 2.5M });
            _discountService.PackageDiscount(Arg.Any<Package>()).Returns(new Discount
                { DiscountType = DiscountType.None, DiscountValue = 0 });

            var viewResult = _controller.GetCustomerTariffs("1");
            var tariffInfo = viewResult.Model as TariffInfo;


            Assert.IsNotNull(tariffInfo);
            Assert.IsTrue(tariffInfo.Tariffs.All(x =>
                x.Discount != null && x.Discount.DiscountType == DiscountType.LongServiceDiscount &&
                x.Discount.DiscountValue == 2.5M));
        }

        [Test]
        public void GetCustomerTariffsTest_PackageDiscount()
        {
            _discountService.GetBigSpenderDiscount(Arg.Any<AccountHistory>()).Returns(new Discount
                { DiscountType = DiscountType.BigSpenderDiscount, DiscountValue = 2 });
            _discountService.LongServiceDiscount(Arg.Any<CustomerAccount>()).Returns(new Discount
                { DiscountType = DiscountType.LongServiceDiscount, DiscountValue = 2.5M });
            _discountService.PackageDiscount(Arg.Any<Package>()).Returns(new Discount
                { DiscountType = DiscountType.PackageDiscount, DiscountValue = 10 });

            var viewResult = _controller.GetCustomerTariffs("1");
            var tariffInfo = viewResult.Model as TariffInfo;


            Assert.IsNotNull(tariffInfo);
            Assert.IsTrue(tariffInfo.Tariffs.All(x =>
                x.Discount != null && x.Discount.DiscountType == DiscountType.PackageDiscount &&
                x.Discount.DiscountValue == 10));
        }
    }
}
