using System;
using System.Collections.Generic;
using System.Linq;

namespace ExternalServices.Stubs
{
    public class DiscountService : IDiscountService
    {
        private readonly IUtil _util;

        public DiscountService(IUtil util)
        {
            _util = util;
        }

        public Discount GetBigSpenderDiscount(AccountHistory customerAccount)
        {
            var discountType = DiscountType.BigSpenderDiscount;
            decimal discountValue;

            if (_util.SpendOver5K(customerAccount.YearlySpend))
            {
                discountValue = 2;
            }
            else if (_util.Between2KAnd5K(customerAccount.YearlySpend))
            {
                discountValue = 1;
            }
            else if (_util.Between1KAnd2K(customerAccount.YearlySpend))
            {
                discountValue = 0.5M;
            }
            else
            {
                if (_util.Between500And1K(customerAccount.YearlySpend))
                    discountValue = 0.25M;
                else
                {
                    discountType = DiscountType.None;
                    discountValue = 0;
                }
            }
            
            return new Discount
            {
                DiscountType = discountType,
                DiscountValue = discountValue
            };
        }

        public Discount GetBigSpenderDiscount(AccountHistory customerAccount, CustomerType customerAccountCustomerType)
        {
            switch (customerAccountCustomerType)
            {
                case CustomerType.Bronze:
                    if (customerAccount.YearlySpend > 3000)
                        return new Discount {DiscountType = DiscountType.BigSpenderDiscount, DiscountValue = 1};
                    break;
                case CustomerType.Silver:
                    if (customerAccount.YearlySpend > 2000)
                        return new Discount { DiscountType = DiscountType.BigSpenderDiscount, DiscountValue = 2 };
                    break;
                case CustomerType.Gold:
                    if (customerAccount.YearlySpend > 1000)
                        return new Discount { DiscountType = DiscountType.BigSpenderDiscount, DiscountValue = 2 };
                    break;
            }

            return GetBigSpenderDiscount(customerAccount);
        }

        public Discount LongServiceDiscount(CustomerAccount account)
        {
            decimal discountValue;
            var discountType = DiscountType.LongServiceDiscount;

            if (_util.IsOver3Years(account.CreatedOn))
            {
                discountValue = 1;
            }
            else if(_util.IsOver2Years(account.CreatedOn))
            {
                discountValue = 0.5M;
            }
            else
            {
                if (_util.IsOver1Year(account.CreatedOn))
                    discountValue = 0.25M;
                else
                {
                    discountType = DiscountType.None;
                    discountValue = 0;
                }
            }

            return new Discount
            {
                DiscountType = discountType,
                DiscountValue = discountValue
            };
        }

        public Discount PackageDiscount(Package customerPackage)
        {
            decimal discountValue;
            var discountType = DiscountType.PackageDiscount;

            if ((customerPackage.BroadbandType == BroadbandType.Basic &&
                 customerPackage.FuelType == FuelType.DualFuel) ||
                (customerPackage.BroadbandType == BroadbandType.HighSpeed &&
                 customerPackage.FuelType == FuelType.Electricity) ||
                (customerPackage.BroadbandType == BroadbandType.HighSpeed && customerPackage.FuelType == FuelType.Gas))
            {
                discountValue = 5;
            }
            else if (customerPackage.FuelType == FuelType.DualFuel &&
                     customerPackage.BroadbandType == BroadbandType.HighSpeed)
            {
                discountValue = 10;
            }
            else
            {
                discountType = DiscountType.None;
                discountValue = 0;
            }

            return new Discount
            {
                DiscountType = discountType,
                DiscountValue = discountValue
            };
        }

        public Discount SelectAppropriateDiscount(List<Discount> allDiscounts)
        {
            return allDiscounts.Where(x => x.DiscountType != DiscountType.None).OrderByDescending(x => x.DiscountValue)
                .FirstOrDefault();
        }
    }
}