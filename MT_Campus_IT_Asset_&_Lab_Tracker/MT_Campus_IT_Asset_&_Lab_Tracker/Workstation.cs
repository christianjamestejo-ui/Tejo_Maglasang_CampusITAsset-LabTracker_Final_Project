using System;
namespace MT_Campus_IT_Asset___Lab_Tracker
{
	public class Workstation : CampusAsset
	{
        private string _operatingSystem;
        private DateTime _warrantyExpiration;

        public Workstation(string operatingSystem, DateTime warrantyExpiration) : base(assetID, assetTag, assetName)
        {
            _operatingSystem = operatingSystem;
            _warrantyExpiration = warrantyExpiration;
		}

        public override string GetMaintenanceStatus()
        {
            return;
        }

        public override double CalculateDepreciation()
        {
            return;
        }
    }
}

