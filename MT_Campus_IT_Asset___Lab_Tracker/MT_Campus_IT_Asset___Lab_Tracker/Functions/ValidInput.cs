using System;
using MT_Campus_IT_Asset___Lab_Tracker.Models;

namespace MT_Campus_IT_Asset___Lab_Tracker.Functions
{
    public class ValidInput
    {
        public bool IsValid(CampusAsset asset)
        {
            if (asset == null)
                return false;

            if (string.IsNullOrWhiteSpace(asset.AssetId))
                return false;

            if (string.IsNullOrWhiteSpace(asset.AssetTag))
                return false;

            if (string.IsNullOrWhiteSpace(asset.AssetName))
                return false;
            if (asset.PurchasePrice < 0)
                return false;

            if (asset.SalvagePrice < 0 ||
                asset.SalvagePrice > asset.PurchasePrice)
            {
                return false;
            }

            if (asset.PurchaseDate > DateTime.Today)
                return false;

            return true;

        }
    }
}

