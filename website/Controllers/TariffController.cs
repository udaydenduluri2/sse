using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ExternalServices;
using WebGrease.Css.Extensions;

namespace website.Controllers
{
    public class TariffController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IAccountsService _accountsService;
        private readonly IPackageService _packageService;
        private readonly IDiscountService _discountService;
        private readonly ITariffService _tariffService;

        public TariffController(ICustomerService customerService, IAccountsService accountsService,
            IPackageService packageService, IDiscountService discountService, ITariffService tariffService)
        {
            _customerService = customerService;
            _accountsService = accountsService;
            _packageService = packageService;
            _discountService = discountService;
            _tariffService = tariffService;
        }

        [HttpGet]
        [Route("customers/{id}/tariffs")]
        public ViewResult GetCustomerTariffs(string id)
        {
            var customerAccount = _customerService.GetAccount(id);
            var accountPaymentHistory = _accountsService.GetAccountHistory(customerAccount.AccountId);
            var tariffInfo = _tariffService.GetTariffInfo(customerAccount.AccountId);
            var customerPackage = _packageService.GetPackage(id);

            var longServiceDiscount = _discountService.LongServiceDiscount(customerAccount);
            var bigSpenderDiscount = _discountService.GetBigSpenderDiscount(accountPaymentHistory, customerAccount.CustomerType);
            var packageDiscount = _discountService.PackageDiscount(customerPackage);

            var allDiscounts = new List<Discount>{bigSpenderDiscount, longServiceDiscount, packageDiscount};

            //Assuming that only 1 discount of the three discount Types is applied to the customer
            //Logic to choose the maximum Discount if available is the method SelectAppropriateDiscount
            var discount = _discountService.SelectAppropriateDiscount(allDiscounts);
            tariffInfo.Tariffs.ForEach(x => x.Discount = discount);
            tariffInfo.CustomerName = customerAccount.AccountId;

            return View("GetCustomerTariffs", tariffInfo);
        }
    }
}