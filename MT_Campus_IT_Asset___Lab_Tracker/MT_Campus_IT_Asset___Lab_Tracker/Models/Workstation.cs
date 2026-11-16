using System;
using System.Net;
using System.Net.Mail;
using MT_Campus_IT_Asset___Lab_Tracker.Functions;
using MT_Campus_IT_Asset___Lab_Tracker.Interfaces;

namespace MT_Campus_IT_Asset___Lab_Tracker.Models
{
	public class Workstation : CampusAsset , IBorrowable , INetworkable , IMaintainable
	{
        //ATRIBUTES//
        public string OperatingSystem { get; private set; }
        public string IpAddress { get; private set; }
        public string MacAddress { get; private set; }

        public string? BorrowerId { get; private set; }

        private MaintenanceStatus maintenanceStatus =
        MaintenanceStatus.Completed;

        public Workstation(string assetID, string assetName, string assetTag,
            double purchasePrice, double salvagePrice, DateTime purchaseDate,
            string operatingSystem)
            : base(assetID, assetName, assetTag, purchasePrice, salvagePrice, purchaseDate)
        {
            OperatingSystem = operatingSystem;
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
            if (maintenanceStatus != MaintenanceStatus.Scheduled)
                return false;

            if (Status == AssetStatus.Borrowed)
                return false;

            maintenanceStatus = MaintenanceStatus.InProgress;

            return ChangeStatus(AssetStatus.InRepair);
        }

        public bool CompleteMaintenance(string maintenanceNotes)
        {
            if (maintenanceStatus != MaintenanceStatus.InProgress)
                return false;

            maintenanceStatus = MaintenanceStatus.Completed;

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
                60
            );
        }

        public bool CheckOut(string borrowerId)
        {
            if (string.IsNullOrWhiteSpace(borrowerId))
                return false;

            if (Status != AssetStatus.Available)
                return false;

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
        {
            return Status == AssetStatus.Borrowed;
        }

        public string GetBorrowerId()
        {
            return BorrowerId;
        }

        public bool UpdateIPAddress(string ipAddress)
        {
            if (!System.Net.IPAddress.TryParse(ipAddress, out _))
                return false;

            IpAddress = ipAddress;

            return true;
        }

        public bool UpdateMACAddress(string macAddress)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(
                macAddress,
                @"^([0-9A-Fa-f]{2}[:-]){5}[0-9A-Fa-f]{2}$"))
            {
                return false;
            }

            MacAddress = macAddress;

            return true;
        }

        public string GetIPAddress() => IpAddress;

        public string GetMACAddress() => MacAddress;
    }
}

