namespace ExternalServices
{
    public interface IPackageService
    {
        Package GetPackage(string id);
    }

    public class Package
    {
        public FuelType FuelType;
        public BroadbandType? BroadbandType;
    }

    public enum BroadbandType
    {
        Basic,
        HighSpeed
    }

    public enum FuelType
    {
        DualFuel,
        Electricity,
        Gas
    }
}
