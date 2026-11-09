using System;
namespace MT_Campus_IT_Asset___Lab_Tracker.Models
{
	public class NetworkingHardware : CampusAsset
	{
        //ATRIBUTES//
        private string _deviceType;
        private string _ipAddress;
        private string _macAddress;
        public double PPrice;
        public double RPrice;
        public double Life;

        public NetworkingHardware(string assetID, string assetName,
            double purchasePrice, double residualPrice, double usefullLife,
            string deviceType, string ipAddress, string macAddress)
            : base(assetID, assetName, purchasePrice, residualPrice, usefullLife)
		{
            _deviceType = deviceType;
            _ipAddress = ipAddress;
            _macAddress = macAddress;
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
            return (PPrice - RPrice)/Life;
        }
    }
}

