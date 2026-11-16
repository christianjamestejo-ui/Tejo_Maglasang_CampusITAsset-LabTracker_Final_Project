using System;
using MT_Campus_IT_Asset___Lab_Tracker.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using MT_Campus_IT_Asset___Lab_Tracker.Interfaces;

namespace MT_Campus_IT_Asset___Lab_Tracker.Functions
{
    public class JsonAssetRepository : IAssetRepository
    {
        private readonly string filePath;

        private List<CampusAsset> assets = new();

        private readonly JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        public JsonAssetRepository(string filePath)
        {
            this.filePath = filePath;

            Load();
        }

        private void Load()
        {
            if (!File.Exists(filePath))
            {
                assets = new List<CampusAsset>();
                return;
            }

            string json = File.ReadAllText(filePath);

            assets = JsonSerializer.Deserialize<List<CampusAsset>>(
                json,
                options
            ) ?? new List<CampusAsset>();
        }

        public void Add(CampusAsset asset)
        {
            if (assets.Any(a => a.AssetId == asset.AssetId))
                throw new InvalidOperationException("Asset ID already exists.");

            if (assets.Any(a => a.AssetTag == asset.AssetTag))
                throw new InvalidOperationException("Asset tag already exists.");

            assets.Add(asset);

            Save();
        }

        public CampusAsset? GetById(string assetId)
        {
            return assets.FirstOrDefault(
                a => a.AssetId == assetId
            );
        }

        public List<CampusAsset> GetAll()
        {
            return new List<CampusAsset>(assets);
        }

        public bool Update(CampusAsset asset)
        {
            int index = assets.FindIndex(
                a => a.AssetId == asset.AssetId
            );

            if (index == -1)
                return false;

            assets[index] = asset;

            Save();

            return true;
        }

        public bool Delete(string assetId)
        {
            CampusAsset? asset = GetById(assetId);

            if (asset == null)
                return false;

            assets.Remove(asset);

            Save();

            return true;
        }

        public void Save()
        {
            string? directory = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);

            string json = JsonSerializer.Serialize(
                assets,
                options
            );

            File.WriteAllText(filePath, json);
        }
    }
}
