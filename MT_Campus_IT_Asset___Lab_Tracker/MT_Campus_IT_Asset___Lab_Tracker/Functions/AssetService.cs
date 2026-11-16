using System;
using MT_Campus_IT_Asset___Lab_Tracker.Interfaces;
using MT_Campus_IT_Asset___Lab_Tracker.Models;
using MT_Campus_IT_Asset___Lab_Tracker.Functions;

namespace MT_Campus_IT_Asset___Lab_Tracker.Functions
{
    public class AssetService
    {
        private readonly IAssetRepository repository;

        private readonly ValidInput validator;

        public AssetService(
            IAssetRepository repository,
            ValidInput validator)
        {
            this.repository = repository;
            this.validator = validator;
        }

        public void RegisterAsset(CampusAsset asset)
        {
            if (!validator.IsValid(asset))
                throw new ArgumentException("Invalid asset information.");

            repository.Add(asset);
        }

        public CampusAsset? FindAsset(string assetId)
        {
            return repository.GetById(assetId);
        }

        public List<CampusAsset> GetAllAssets()
        {
            return repository.GetAll();
        }

        public bool UpdateAsset(CampusAsset asset)
        {
            if (!validator.IsValid(asset))
                return false;

            return repository.Update(asset);
        }

        public bool DeleteAsset(string assetId)
        {
            return repository.Delete(assetId);
        }

        public List<CampusAsset> GetAvailableAssets()
        {
            return repository.GetAll()
                .Where(a => a.Status == AssetStatus.Available)
                .ToList();
        }

        //public List<CampusAsset> GetAssetsByType<T>()
          //  where T : CampusAsset
        //{
          //  return repository.GetAll()
            //    .OfType<T>()
              //  .ToList();
        //}

        public List<CampusAsset> GetAssetsInRepair()
        {
            return repository.GetAll()
                .Where(a => a.Status == AssetStatus.InRepair)
                .ToList();
        }

        public List<CampusAsset> GetAssetsByValue(
            double minimumValue)
        {
            return repository.GetAll()
                .Where(a => a.CalculateCurrentValue() >= minimumValue)
                .ToList();
        }
    }
}

