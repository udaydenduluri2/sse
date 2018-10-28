using System;

namespace ExternalServices
{
    public class Util : IUtil
    {
        public bool Between1KAnd2K(decimal actualValue)
        {
            return actualValue > 1000 && actualValue <= 2000;
        }

        public bool Between2KAnd5K(decimal actualValue)
        {
            return actualValue > 2000 && actualValue <= 5000;
        }

        public bool Between500And1K(decimal actualValue)
        {
            return actualValue > 500 && actualValue <= 1000;
        }

        public CustomerType GetCustomerType(DateTime created)
        {
            if (IsOver3Years(created))
            {
                return CustomerType.Gold;
            }
            else if (IsOver2Years(created))
            {
                return CustomerType.Silver;
            }
            else if (IsOver1Year(created))
            {
                return CustomerType.Bronze;
            }

            return CustomerType.None;
        }

        public bool IsOver1Year(DateTime fromDate, DateTime? toDate = null)
        {
            if (!toDate.HasValue)
                toDate = DateTime.Today;
            return NumberOfYearsAndOver(fromDate, 1, toDate.Value, true);
        }

        public bool IsOver2Years(DateTime fromDate, DateTime? toDate = null)
        {
            if (!toDate.HasValue)
                toDate = DateTime.Today;
            return NumberOfYearsAndOver(fromDate, 2, toDate.Value, true);
        }

        public bool IsOver3Years(DateTime fromDate, DateTime? toDate = null)
        {
            if(!toDate.HasValue)
                toDate = DateTime.Today;
            return NumberOfYearsAndOver(fromDate, 3, toDate.Value, true);
        }

        internal bool NumberOfYearsAndOver(DateTime fromDate, int years, DateTime toDate, bool inclusive)
        {
            return inclusive ? toDate.AddYears(-years) >= fromDate : toDate.AddYears(-years) > fromDate;
        }

        public bool SpendOver5K(decimal actualValue)
        {
            return actualValue > 5000;
        }
    }
}