using System;
using MT_Campus_IT_Asset___Lab_Tracker.Interfaces;
using MT_Campus_IT_Asset___Lab_Tracker.Models;
using MT_Campus_IT_Asset___Lab_Tracker.Functions;
namespace MT_Campus_IT_Asset___Lab_Tracker.Functions
{
    public class MaintenanceService
    {
        private readonly IAssetRepository repository;

        private readonly List<MaintenanceRecord> records = new();
        public MaintenanceService(IAssetRepository repository)
        {
            this.repository = repository;
        }

        public bool ScheduleMaintenance(
        string assetId,
        string technicianId,
        DateTime scheduledDate)
        {
            CampusAsset? asset = repository.GetById(assetId);

            if (asset is not IMaintainable maintainable)
                return false;

            if (!maintainable.ScheduleMaintenance(scheduledDate))
                return false;

            records.Add(new MaintenanceRecord
            {
                RecordId = Guid.NewGuid().ToString(),
                AssetId = assetId,
                TechnicianId = technicianId,
                ScheduledDate = scheduledDate,
                Status = Models.MaintenanceStatus.Scheduled
            });

            repository.Update(asset);

            return true;
        }

        public bool StartMaintenance(string assetId)
        {
            CampusAsset? asset = repository.GetById(assetId);

            if (asset is not IMaintainable maintainable)
                return false;

            if (!maintainable.StartMaintenance())
                return false;

            MaintenanceRecord? record = records.LastOrDefault(
                r => r.AssetId == assetId &&
                     r.Status == Models.MaintenanceStatus.Scheduled
            );

            if (record != null)
                record.Status = Models.MaintenanceStatus.InProgress;

            repository.Update(asset);

            return true;
        }

        public bool CompleteMaintenance(
            string assetId,
            string notes)
        {
            CampusAsset? asset = repository.GetById(assetId);

            if (asset is not IMaintainable maintainable)
                return false;

            if (!maintainable.CompleteMaintenance(notes))
                return false;

            MaintenanceRecord? record = records.LastOrDefault(
                r => r.AssetId == assetId &&
                     r.Status == Models.MaintenanceStatus.InProgress
            );

            if (record != null)
            {
                record.Status = Models.MaintenanceStatus.Completed;
                record.MaintenanceNotes = notes;
                record.CompletedDate = DateTime.Now;
            }

            repository.Update(asset);

            return true;
        }

        public List<MaintenanceRecord> GetMaintenanceHistory(
            string assetId)
        {
            return records
                .Where(r => r.AssetId == assetId)
                .ToList();
        }
    }
}

