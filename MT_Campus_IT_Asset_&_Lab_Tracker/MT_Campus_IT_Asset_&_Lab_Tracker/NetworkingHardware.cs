using System;
namespace MT_Campus_IT_Asset___Lab_Tracker
{
	public class NetworkingHardware : CampusAsset
	{
        private string _deviceType;
        private string _ipAddress;
        private string _macAddress;

        public NetworkingHardware(string deviceType, string ipAddress, string macAddress) : base(assetID, assetTag, assetName)
		{
            _deviceType = deviceType;
            _ipAddress = ipAddress;
            _macAddress = macAddress;
		}

        public override string GetMaintenanceStatus()
        {
            return ;
        }

        public override double CalculateDepreciation()
        {
            return ;
        }
    }
}

