using System;
namespace MT_Campus_IT_Asset___Lab_Tracker
{
	public class SoftwareLicense : CampusAsset
	{
        private string _licenseKey;
        private string _licenseType;
        private string _licenseProvider;

        public SoftwareLicense(string liscenseKey, string liscenseType, string liscnseProvider) : base(assetID, assetTag, assetName)
        {
            _licenseKey = liscenseKey;
            _licenseType = liscenseType;
            _licenseProvider = liscnseProvider;
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

