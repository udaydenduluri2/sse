using System;

namespace ExternalServices
{
    public interface ICustomerService
    {
        CustomerAccount GetAccount(string id);
    }

    public class CustomerAccount
    {
        public string AccountId { get; set; }
        public DateTime CreatedOn { get; set; }
        public CustomerType CustomerType { get; set; }
    }

    public class Discount
    {
        public decimal DiscountValue { get; set; }
        public DiscountType DiscountType { get; set; }
    }

    public enum CustomerType
    {
        None,
        Bronze,
        Silver,
        Gold
    }
}