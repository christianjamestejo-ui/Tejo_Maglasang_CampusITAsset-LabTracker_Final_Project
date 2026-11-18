
using System;
using System.Text.Json.Serialization;
using MT_Campus_IT_Asset___Lab_Tracker.Functions;

namespace MT_Campus_IT_Asset___Lab_Tracker.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$assetType")]
    [JsonDerivedType(typeof(Workstation), "workstation")]
    [JsonDerivedType(typeof(NetworkingHardware), "networking")]
    [JsonDerivedType(typeof(Peripheral), "peripheral")]
    [JsonDerivedType(typeof(SoftwareLicense), "software")]
    public abstract class CampusAsset
    {
        [JsonInclude]
        public string AssetId { get; private set; }

        [JsonInclude]
        public string AssetName { get; private set; }

        [JsonInclude]
        public string AssetTag { get; private set; }

        [JsonInclude]
        public double PurchasePrice { get; private set; }

        [JsonInclude]
        public int UsefulLifeMonths { get; private set; }

        [JsonInclude]
        public DateTime PurchaseDate { get; private set; }

        [JsonInclude]
        public double SalvagePrice { get; private set; }

        [JsonInclude]
        public double _annualDepreciationExpense { get; private set; }

        [JsonInclude]
        public AssetStatus Status { get; private set; }
            = AssetStatus.Available;

        [JsonInclude]
        public AssetCondition Condition { get; private set; }
            = AssetCondition.Good;

        protected CampusAsset() { }

        protected CampusAsset(
            string assetID,
            string assetName,
            string assetTag,
            double purchasePrice,
            double salvagePrice,
            int usefulLifeMonths,
            DateTime purchaseDate)
        {
            AssetId = assetID;
            AssetName = assetName;
            AssetTag = assetTag;
            PurchasePrice = purchasePrice;
            SalvagePrice = salvagePrice;
            PurchaseDate = purchaseDate;
            UsefulLifeMonths = usefulLifeMonths;
        }

        protected void CalculateAndSetAnnualDepreciation(
     int usefulLifeMonths)
        {
            _annualDepreciationExpense =
                DepreciationCalculator.CalculateAnnualDepreciation(
                    PurchasePrice,
                    SalvagePrice,
                    usefulLifeMonths
                );
        }

        public abstract double CalculateDepreciation();

        public double CalculateCurrentValue()
        {
            double currentValue =
                PurchasePrice - CalculateDepreciation();

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

        public void UpdateDetails(string assetName)
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
            return $"{AssetTag} - {AssetName} | {Status} |";
        }
    }
}
