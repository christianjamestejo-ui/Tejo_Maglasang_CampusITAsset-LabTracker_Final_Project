using System;
namespace MT_Campus_IT_Asset___Lab_Tracker.Models
{
	public class SoftwareLicense : CampusAsset
	{
        //ATRIBUTES//
        private string _licenseKey;
        private string _licenseType;
        private string _licenseProvider;
        public double PPrice;
        public double RPrice;
        public double Life;

        public SoftwareLicense(string assetID, string assetName,
            double purchasePrice, double residualPrice, double usefullLife,
            string liscenseKey, string liscenseType, string liscnseProvider)
            : base(assetID, assetName, purchasePrice, residualPrice, usefullLife)
        {
            _licenseKey = liscenseKey;
            _licenseType = liscenseType;
            _licenseProvider = liscnseProvider;
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

