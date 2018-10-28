using System;

namespace ExternalServices
{
    public interface IUtil
    {
        bool IsOver1Year(DateTime fromDate, DateTime? toDate = null);
        bool IsOver2Years(DateTime fromDate, DateTime? toDate = null);
        bool IsOver3Years(DateTime fromDate, DateTime? toDate = null);
        bool SpendOver5K(decimal actualValue);
        bool Between2KAnd5K(decimal actualValue);
        bool Between1KAnd2K(decimal actualValue);
        bool Between500And1K(decimal actualValue);
        CustomerType GetCustomerType(DateTime createdOn);
    }
}