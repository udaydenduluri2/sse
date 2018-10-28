using System.Collections.Generic;

namespace ExternalServices
{
    public interface ITariffService
    {
        TariffInfo GetTariffInfo(string accountNumber);
    }

    public class TariffInfo
    {
        public string PostCode { get; set; }
        public int AnnualGasUsage { get; set; }
        public int AnnualElectricUsage { get; set; }
        public IEnumerable<Tariff> Tariffs { get; set; }
        public string CustomerName { get; set; }
    }

    public class Tariff
    {
        public string TariffName { get; set; }
        public string TariffFriendlyName { get; set; }
        public IEnumerable<string> TariffTerms { get; set; }
        public decimal AnnualGasCost { get; set; }
        public decimal AnnualElectricCost { get; set; }
        public Discount Discount { get; set; }

        public decimal TotalCost
        {
            get { return AnnualGasCost + AnnualElectricCost; }
        }

        public decimal MonthlyGasCost
        {
            get { return TotalCost / 12; }
        }
        public decimal MonthlyElectricCost
        {
            get { return TotalCost / 12; }
        }

        public decimal MonthlyTotal
        {
            get
            {
                return (AnnualGasCost + AnnualElectricCost)/12;
            }
        }
    }

    public enum DiscountType
    {
        None,
        LongServiceDiscount,
        BigSpenderDiscount,
        PackageDiscount
    }
}
