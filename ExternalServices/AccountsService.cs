namespace ExternalServices
{
    public interface IAccountsService
    {
        AccountHistory GetAccountHistory(string accountId);
    }

    public class AccountHistory
    {
        public decimal YearlySpend { get; set; }
    }
}