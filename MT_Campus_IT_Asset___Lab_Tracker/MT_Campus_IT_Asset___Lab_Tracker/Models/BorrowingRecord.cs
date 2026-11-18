using System;
namespace MT_Campus_IT_Asset___Lab_Tracker.Models
{
    public class BorrowingRecord
    {
        public string RecordId { get; set; } = "";

        public string AssetId { get; set; } = "";

        public string BorrowerId { get; set; } = "";

        public DateTime CheckoutDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public bool IsReturned => ReturnDate.HasValue;
    }
}

