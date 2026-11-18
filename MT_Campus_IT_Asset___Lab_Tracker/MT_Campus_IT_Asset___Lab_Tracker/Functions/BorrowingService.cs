using System;
using MT_Campus_IT_Asset___Lab_Tracker.Interfaces;
using MT_Campus_IT_Asset___Lab_Tracker.Models;
using MT_Campus_IT_Asset___Lab_Tracker.Functions;
namespace MT_Campus_IT_Asset___Lab_Tracker.Functions
{
    public class BorrowingService
    {
        private readonly IAssetRepository repository;

        private readonly List<BorrowingRecord> records = new();

        public BorrowingService(IAssetRepository repository)
        {
            this.repository = repository;
        }

        public bool CheckOutAsset(
            string assetId,
            string borrowerId)
        {
            CampusAsset? asset = repository.GetById(assetId);

            if (asset == null)
                return false;

            if (asset is not IBorrowable borrowable)
                return false;

            if (!borrowable.CheckOut(borrowerId))
                return false;

            records.Add(new BorrowingRecord
            {
                RecordId = Guid.NewGuid().ToString(),
                AssetId = assetId,
                BorrowerId = borrowerId,
                CheckoutDate = DateTime.Now
            });

            repository.Update(asset);

            return true;
        }

        public bool ReturnAsset(string assetId)
        {
            CampusAsset? asset = repository.GetById(assetId);

            if (asset is not IBorrowable borrowable)
                return false;

            if (!borrowable.ReturnAsset())
                return false;

            BorrowingRecord? record = records
                .LastOrDefault(r =>
                    r.AssetId == assetId && !r.IsReturned);

            if (record == null)
                return false;

            record.ReturnDate = DateTime.Now;

            repository.Update(asset);

            return true;
        }

        public List<BorrowingRecord> GetBorrowingHistory(
            string assetId)
        {
            return records
                .Where(r => r.AssetId == assetId)
                .ToList();
        }

        public List<BorrowingRecord> GetActiveBorrowings()
        {
            return records
                .Where(r => !r.IsReturned)
                .ToList();
        }
    }
}

