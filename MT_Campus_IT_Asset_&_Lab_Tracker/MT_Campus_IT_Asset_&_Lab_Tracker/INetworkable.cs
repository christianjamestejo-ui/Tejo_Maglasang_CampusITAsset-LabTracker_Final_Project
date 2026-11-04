using System;
namespace MT_Campus_IT_Asset___Lab_Tracker
{
    public interface INetworkable
    {
        //ATRIBUTES//
        string AssignedTo { get; set; }

        //METHODS//
        void AssignTo(string userId);
        void Unassign();
    }
}

