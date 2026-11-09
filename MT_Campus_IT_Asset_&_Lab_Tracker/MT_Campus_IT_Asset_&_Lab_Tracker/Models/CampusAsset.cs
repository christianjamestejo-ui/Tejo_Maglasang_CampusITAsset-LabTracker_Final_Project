using System;
namespace MT_Campus_IT_Asset___Lab_Tracker.Models
{
	public abstract class CampusAsset
	{
		//ATRIBUTES//
		private string _assetId;
		private string _assetName;
		private double _purchasePrice;
		private double _usefullLife;
		private double _residualPrice;
		private double _annualDepreciationExpense;


        public CampusAsset(string assetID, string assetName,
			double purchasePrice, double residualPrice, double usefullLife)
		{
			_assetId = assetID;
			_assetName = assetName;
			_purchasePrice = purchasePrice;
			_residualPrice = residualPrice;
			_usefullLife = usefullLife;
		}

		public double CalculateAnnualDepreciationExpense() => _purchasePrice ;

		//METHODS//
		public abstract string GetMaintenanceStatus();
		public abstract double CalculateAnnualDepreciation();
    }
}

