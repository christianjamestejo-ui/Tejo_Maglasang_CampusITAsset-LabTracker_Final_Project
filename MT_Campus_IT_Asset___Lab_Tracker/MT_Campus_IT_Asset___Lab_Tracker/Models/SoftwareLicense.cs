using System;
using MT_Campus_IT_Asset___Lab_Tracker.Functions;

namespace MT_Campus_IT_Asset___Lab_Tracker.Models
{
    public class SoftwareLicense : CampusAsset
    {
        //ATRIBUTES//
        public string LicenseKey { get; private set; }
        public string LicenseType { get; private set; }
        public string LicenseProvider { get; private set; }
        public DateTime LicenseStartDate { get; private set; }
        public DateTime LicenseExpiryDate { get; private set; }

        public string? BorrowerId { get; private set; }

        public SoftwareLicense(string assetID, string assetName, string assetTag,
            double purchasePrice, double salvagePrice, int usefulLifeMonths, DateTime purchaseDate,
            string liscenseKey, string liscenseType, string liscnseProvider,
            DateTime licenseStartDate, DateTime licenseExpiryDate)
            : base(assetID, assetName, assetTag, purchasePrice, salvagePrice, usefulLifeMonths, purchaseDate)
        {
            LicenseKey = liscenseKey;
            LicenseType = liscenseType;
            LicenseProvider = liscnseProvider;
            LicenseStartDate = licenseStartDate;
            LicenseExpiryDate = licenseExpiryDate;
        }

        //METHODS//
        public override double CalculateDepreciation()
        {
            return DepreciationCalculator.CalculateAmortization(
                PurchasePrice,
                SalvagePrice,
                LicenseStartDate,
                LicenseExpiryDate
            );
        }
    }
}

