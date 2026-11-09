using System;
using Microsoft.VisualBasic;

namespace MT_Campus_IT_Asset___Lab_Tracker.Interfaces
{
    public interface IBorrowable
    {
        //ATRIBUTES//
        bool IsCheckedIn { get; set; }
        bool IsCheckedOut { get; set; }
        string BorrowerId { get; set; }
        DateTime DueDate { get; set; }

        //METHODS//
        void CheckOut(string borrowerId, DateTime dueDate);
    }
}

