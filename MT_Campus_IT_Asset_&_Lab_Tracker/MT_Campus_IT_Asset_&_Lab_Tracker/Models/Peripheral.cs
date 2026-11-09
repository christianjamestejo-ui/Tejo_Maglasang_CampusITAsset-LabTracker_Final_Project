using System;
namespace MT_Campus_IT_Asset___Lab_Tracker.Models
{
	public class Peripheral : CampusAsset
	{
        //ATRIBUTES//
        private string _peripheralType;
        private string _connectionType;
        private string _compatibility;
        public double PPrice;
        public double RPrice;
        public double Life;

        public Peripheral(string assetID, string assetName,
            double purchasePrice, double residualPrice, double usefullLife,
            string peripheralType, string connectionType, string compatibility)
            : base(assetID, assetName, purchasePrice, residualPrice, usefullLife)
        {
            _peripheralType = peripheralType;
            _connectionType = connectionType;
            _compatibility = compatibility;
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

