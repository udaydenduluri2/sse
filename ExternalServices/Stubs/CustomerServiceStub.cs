using System;

namespace ExternalServices.Stubs
{
    public class CustomerServiceStub : ICustomerService
    {
        private readonly IUtil _util;

        public CustomerServiceStub(IUtil util)
        {
            _util = util;
        }

        public CustomerAccount GetAccount(string id)
        {
            DateTime createdOn;
            switch (id)
            {
                case "1":
                    // < 1year
                    createdOn = DateTime.Today.AddMonths(-11);
                    break;
                case "2":
                    // 1 - 2 years
                    createdOn = DateTime.Today.AddYears(-1).AddDays(-1);
                    break;
                case "3":
                    // 1 - 2 years
                    createdOn = DateTime.Today.AddYears(-1).AddMonths(-1);
                    break;
                case "4":
                    // 1 - 2 years
                    createdOn = DateTime.Today.AddYears(-2);
                    break;
                case "5":
                    // 2 - 3 years
                    createdOn = DateTime.Today.AddYears(-2).AddDays(-1);
                    break;
                case "6":
                    // 2-3 years
                    createdOn = DateTime.Today.AddYears(-3);
                    break;
                case "7":
                    // 3 years
                    createdOn = DateTime.Today.AddYears(-3).AddDays(-1);
                    break;
                default:
                    return new CustomerAccount();
            }

            return new CustomerAccount { CreatedOn = createdOn, CustomerType = _util.GetCustomerType(createdOn) };
        }

       
    }
}