using System;
namespace MT_Campus_IT_Asset___Lab_Tracker
{
	public class Peripheral : CampusAsset
	{
        private string _peripheralType;
        private string _connectionType;
        private string _compatibility;

        public Peripheral(string peripheralType, string connectionType, string compatibility) : base(assetID, assetTag, assetName)
        {
            _peripheralType = peripheralType;
            _connectionType = connectionType;
            _compatibility = compatibility;
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

