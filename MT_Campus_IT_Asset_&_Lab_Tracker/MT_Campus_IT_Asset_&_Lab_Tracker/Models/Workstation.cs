using System;
namespace MT_Campus_IT_Asset___Lab_Tracker.Models
{
	public class Workstation : CampusAsset
    {
        //ATRIBUTES//
        private string _operatingSystem;
        private string _warrantyExpiration;
        public double PPrice;
        public double RPrice;
        public double Life;

        public Workstation(string assetID, string assetName,
            double purchasePrice, double residualPrice, double usefullLife,
            string operatingSystem, string warrantyExpiration)
            : base(assetID, assetName, purchasePrice, residualPrice, usefullLife)
        {
            _operatingSystem = operatingSystem;
            _warrantyExpiration = warrantyExpiration;
            PPrice = purchasePrice;
            RPrice = residualPrice;
            Life = usefullLife;
        }

        //METHODS//
        public override string GetMaintenanceStatus()
        {
            return "";
        }

        public override double CalculateAnnualDepreciation()
        {
            return (PPrice - RPrice) / Life;
        }
    }
}

