using System.Collections.Generic;

namespace ExternalServices
{
    public interface IDiscountService
    {
        Discount GetBigSpenderDiscount(AccountHistory customerAccount);
        Discount GetBigSpenderDiscount(AccountHistory customerAccount, CustomerType customerAccountCustomerType);
        Discount LongServiceDiscount(CustomerAccount account);
        Discount PackageDiscount(Package customerPackage);
        Discount SelectAppropriateDiscount(List<Discount> allDiscounts);
    }
}