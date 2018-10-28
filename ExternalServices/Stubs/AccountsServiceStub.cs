using System;

namespace ExternalServices.Stubs
{
    public class AccountsServiceStub : IAccountsService
    {
        public AccountHistory GetAccountHistory(string accountId)
        {
            switch (accountId)
            {
                case "1":
                    return new AccountHistory{YearlySpend = 100};
                case "2":
                    return new AccountHistory{YearlySpend = 500};
                case "3":
                    return new AccountHistory{YearlySpend = 1000};
                case "4":
                    return new AccountHistory{YearlySpend = 2000};
                case "5":
                    return new AccountHistory{YearlySpend = 3000};
                case "6":
                    return new AccountHistory{YearlySpend = 5000};
                case "7":
                    return new AccountHistory{YearlySpend = 5001};
                default:
                    return new AccountHistory();
            }
        }
    }
}