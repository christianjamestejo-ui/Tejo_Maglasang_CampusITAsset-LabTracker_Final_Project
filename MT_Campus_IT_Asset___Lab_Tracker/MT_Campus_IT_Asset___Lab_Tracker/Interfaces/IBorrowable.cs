using System;
namespace MT_Campus_IT_Asset___Lab_Tracker.Interfaces
{
    public interface IBorrowable
    {
        bool CheckOut(string borrowerId);

        bool ReturnAsset();

        bool IsCheckedOut();

        string GetBorrowerId();
    }
}

