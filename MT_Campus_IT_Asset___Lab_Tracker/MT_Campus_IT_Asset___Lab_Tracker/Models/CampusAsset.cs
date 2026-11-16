using System;
using System.Text.Json.Serialization;

namespace MT_Campus_IT_Asset___Lab_Tracker.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$assetType")]
    [JsonDerivedType(typeof(Workstation), "Workstation")]
    [JsonDerivedType(typeof(NetworkingHardware), "NetworkingHardware")]
    [JsonDerivedType(typeof(Peripheral), "Peripheral")]
    [JsonDerivedType(typeof(SoftwareLicense), "SoftwareLicense")]
    public abstract class CampusAsset
	{
        public string AssetId { get; private set; }
        public string AssetName { get; private set; }
        public string AssetTag { get; private set; }
        public double PurchasePrice { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public double SalvagePrice { get; private set; }
        public double _annualDepreciationExpense { get; private set; }

        [JsonInclude]
        public AssetStatus Status { get; private set; }
        = AssetStatus.Available;

        public AssetCondition Condition { get; private set; }
        = AssetCondition.Good;

        protected CampusAsset() { }

        protected CampusAsset(string assetID, string assetName, string assetTag,
            double purchasePrice, double salvagePrice, DateTime purchaseDate)
        {
            AssetId = assetID;
            AssetName = assetName;
            AssetTag = assetTag;
            PurchasePrice = purchasePrice;
            SalvagePrice = salvagePrice;
            PurchaseDate = purchaseDate;
        }

        public abstract double CalculateDepreciation();

        public double CalculateCurrentValue()
        {
            double currentValue = PurchasePrice - CalculateDepreciation();

            return Math.Max(SalvagePrice, currentValue);
        }

        public int GetAssetAgeInMonths()
        {
            DateTime today = DateTime.Today;

            return Math.Max(
                0,
                ((today.Year - PurchaseDate.Year) * 12)
                + today.Month - PurchaseDate.Month
            );
        }

        public void UpdateDetails(
            string assetName)
        {
            if (string.IsNullOrWhiteSpace(assetName))
                throw new ArgumentException("Asset name is required.");

            AssetName = assetName;
        }

        public void UpdateCondition(AssetCondition condition)
        {
            Condition = condition;
        }

        public bool ChangeStatus(AssetStatus newStatus)
        {
            if (Status == AssetStatus.Retired ||
                Status == AssetStatus.Expired)
            {
                return false;
            }

            if (newStatus == AssetStatus.Borrowed)
                return false;

            if (newStatus == AssetStatus.Available &&
                Status == AssetStatus.InRepair)
            {
                return false;
            }

            Status = newStatus;

            return true;
        }

        public override string ToString()
        {
            return $"{AssetTag} - {AssetName} | " +
                   $"{Status} |";
        }
    }
}

