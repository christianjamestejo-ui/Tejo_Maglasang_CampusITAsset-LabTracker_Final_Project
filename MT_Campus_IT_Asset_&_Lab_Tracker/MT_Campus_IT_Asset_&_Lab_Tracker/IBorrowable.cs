using System;
using Microsoft.VisualBasic;

namespace MT_Campus_IT_Asset___Lab_Tracker
{
    public interface IBorrowable
    {
        bool IsCheckedOut { get; set; }
        string BorrowerId { get; set; }
        DateTime DueDate { get; set; }
        void CheckOut(string borrowerId, DateTime dueDate);
    }
}

