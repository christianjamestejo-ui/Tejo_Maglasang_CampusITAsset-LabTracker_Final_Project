using System;
namespace MT_Campus_IT_Asset___Lab_Tracker
{
	public abstract class CampusAsset
	{
       private string _assetId;
       private string _assetTag;
       private string _assetName;


        public CampusAsset(string assetID,string assetTag, string assetName)
		{
			_assetId = assetID;
			_assetName = assetName;
			_assetTag = assetTag;
		}

		public abstract string GetMaintenanceStatus();

		public abstract double CalculateDepreciation();
    }
}

