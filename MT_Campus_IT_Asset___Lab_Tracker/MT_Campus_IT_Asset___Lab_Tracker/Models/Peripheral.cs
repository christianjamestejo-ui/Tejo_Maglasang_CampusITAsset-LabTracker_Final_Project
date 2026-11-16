using System;
using MT_Campus_IT_Asset___Lab_Tracker.Functions;
using MT_Campus_IT_Asset___Lab_Tracker.Interfaces;

namespace MT_Campus_IT_Asset___Lab_Tracker.Models
{
    public class Peripheral : CampusAsset , IBorrowable , IMaintainable
    {
        //ATRIBUTES//
        public string PeripheralType { get; private set; }
        public string ConnectionType { get; private set; }
        public string Compatibility { get; private set; }

        public string? BorrowerId { get; private set; }

        private MaintenanceStatus maintenanceStatus =
        MaintenanceStatus.Completed;

        public Peripheral(string assetID, string assetName, string assetTag,
            double purchasePrice, double salvagePrice, DateTime purchaseDate,
            string peripheralType, string connectionType, string compatibility)
            : base(assetID, assetName, assetTag, purchasePrice, salvagePrice, purchaseDate)
        {
            PeripheralType = peripheralType;
            ConnectionType = connectionType;
            Compatibility = compatibility;
        }

        //METHODS//
        public bool ScheduleMaintenance(DateTime maintenanceDate)
        {
            if (maintenanceDate.Date < DateTime.Today)
                return false;

            if (Status == AssetStatus.Retired)
                return false;

            maintenanceStatus = MaintenanceStatus.Scheduled;

            return true;
        }

        public bool StartMaintenance()
        {
            if (maintenanceStatus != MaintenanceStatus.Scheduled ||
                Status == AssetStatus.Borrowed)
            {
                return false;
            }

            maintenanceStatus = MaintenanceStatus.InProgress;

            return ChangeStatus(AssetStatus.InRepair);
        }

        public bool CompleteMaintenance(string notes)
        {
            if (maintenanceStatus != MaintenanceStatus.InProgress)
                return false;

            return ChangeStatus(AssetStatus.Available);
        }

        public MaintenanceStatus GetMaintenanceStatus()
            => maintenanceStatus;

        public override double CalculateDepreciation()
        {
            return DepreciationCalculator.CalculateStraightLine(
                PurchasePrice,
                SalvagePrice,
                PurchaseDate,
                36
            );
        }

        public bool CheckOut(string borrowerId)
        {
            if (string.IsNullOrWhiteSpace(borrowerId) ||
                Status != AssetStatus.Available)
            {
                return false;
            }

            BorrowerId = borrowerId;

            return ChangeStatus(AssetStatus.Borrowed);
        }

        public bool ReturnAsset()
        {
            if (Status != AssetStatus.Borrowed)
                return false;

            BorrowerId = "";

            return ChangeStatus(AssetStatus.Available);
        }

        public bool IsCheckedOut()
            => Status == AssetStatus.Borrowed;

        public string GetBorrowerId()
            => BorrowerId;
    }
}
