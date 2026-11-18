using System;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using MT_Campus_IT_Asset___Lab_Tracker.Functions;
using MT_Campus_IT_Asset___Lab_Tracker.Interfaces;

namespace MT_Campus_IT_Asset___Lab_Tracker.Models
{
    public class NetworkingHardware : CampusAsset, IMaintainable, INetworkable
    {
        //ATRIBUTES//
        public string DeviceType { get; private set; }
        public string IpAddress { get; private set; }
        public string MacAddress { get; private set; }

        public string? BorrowerId { get; private set; }

        private MaintenanceStatus maintenanceStatus =
        MaintenanceStatus.Completed;

        public NetworkingHardware(string assetID, string assetName, string assetTag,
            double purchasePrice, double salvagePrice, int usefulLifeMonths, DateTime purchaseDate,
            string deviceType, string ipAddress, string macAddress)
            : base(assetID, assetName, assetTag, purchasePrice, salvagePrice, usefulLifeMonths, purchaseDate)
        {
            DeviceType = deviceType;
            IpAddress = ipAddress;
            MacAddress = macAddress;

            CalculateAndSetAnnualDepreciation(usefulLifeMonths);

        }

        //METHODS//
        public override double CalculateDepreciation()
        {
            return DepreciationCalculator.CalculateStraightLine(
                PurchasePrice,
                SalvagePrice,
                PurchaseDate,
                UsefulLifeMonths
            );
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

        public bool CompleteMaintenance(string notes)
        {
            if (maintenanceStatus != MaintenanceStatus.InProgress)
                return false;

            maintenanceStatus = MaintenanceStatus.Completed;

            return ChangeStatus(AssetStatus.Available);
        }

        public MaintenanceStatus GetMaintenanceStatus()
            => maintenanceStatus;
    }
}

