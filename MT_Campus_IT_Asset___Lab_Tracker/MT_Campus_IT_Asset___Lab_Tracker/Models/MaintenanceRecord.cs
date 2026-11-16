using System;
using MT_Campus_IT_Asset___Lab_Tracker.Functions;
using MT_Campus_IT_Asset___Lab_Tracker.Interfaces;
namespace MT_Campus_IT_Asset___Lab_Tracker.Models
{
    public class MaintenanceRecord
    {
        public string RecordId { get; set; } = "";

        public string AssetId { get; set; } = "";

        public string TechnicianId { get; set; } = "";

        public string MaintenanceNotes { get; set; } = "";

        public DateTime ScheduledDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        public MaintenanceStatus Status { get; set; }
    }
}

