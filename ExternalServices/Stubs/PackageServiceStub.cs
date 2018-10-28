using System;

namespace ExternalServices.Stubs
{
    public class PackageServiceStub : IPackageService
    {
        public Package GetPackage(string id)
        {
            switch (id)
            {
                case "1":
                    return new Package{BroadbandType = BroadbandType.Basic, FuelType = FuelType.Gas};
                case "2":
                    return new Package { BroadbandType = BroadbandType.Basic, FuelType = FuelType.Electricity };
                case "3":
                    return new Package { BroadbandType = BroadbandType.Basic, FuelType = FuelType.DualFuel };
                case "4":
                    return new Package { BroadbandType = BroadbandType.HighSpeed, FuelType = FuelType.Electricity };
                case "5":
                    return new Package { BroadbandType = BroadbandType.HighSpeed, FuelType = FuelType.Gas };
                case "6":
                    return new Package { BroadbandType = BroadbandType.HighSpeed, FuelType = FuelType.DualFuel };
                default:
                    return new Package();
            }
        }
    }
}