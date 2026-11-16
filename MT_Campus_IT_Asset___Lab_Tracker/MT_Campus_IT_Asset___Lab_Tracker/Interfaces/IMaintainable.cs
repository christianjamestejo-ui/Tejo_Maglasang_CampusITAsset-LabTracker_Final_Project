using System;
using MT_Campus_IT_Asset___Lab_Tracker.Functions;
using MT_Campus_IT_Asset___Lab_Tracker.Models;
using MT_Campus_IT_Asset___Lab_Tracker.Interfaces;
namespace MT_Campus_IT_Asset___Lab_Tracker.Interfaces
{
    public interface IMaintainable
    {
        bool ScheduleMaintenance(DateTime maintenanceDate);

        bool StartMaintenance();

        bool CompleteMaintenance(string maintenanceNotes);

        MaintenanceStatus GetMaintenanceStatus();
    }
}

