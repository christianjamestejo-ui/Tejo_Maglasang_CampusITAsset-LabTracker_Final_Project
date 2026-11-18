using System;
using MT_Campus_IT_Asset___Lab_Tracker.Models;

namespace MT_Campus_IT_Asset___Lab_Tracker.Interfaces
{
    public interface IAssetRepository
    {
        void Add(CampusAsset asset);

        CampusAsset? GetById(string assetId);

        List<CampusAsset> GetAll();

        bool Update(CampusAsset asset);

        bool Delete(string assetId);

        void Save();
    }
}

