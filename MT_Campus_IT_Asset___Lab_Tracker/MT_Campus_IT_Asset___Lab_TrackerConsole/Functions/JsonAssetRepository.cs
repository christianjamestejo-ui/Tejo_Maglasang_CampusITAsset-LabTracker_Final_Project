
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

using MT_Campus_IT_Asset___Lab_Tracker.Models;
using MT_Campus_IT_Asset___Lab_Tracker.Interfaces;

namespace MT_Campus_IT_Asset___Lab_Tracker.Functions
{
    public class JsonAssetRepository : IAssetRepository
    {
        private readonly string filePath;

        private List<CampusAsset> assets = new();

        // JSON Serializer Configuration
        private readonly JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };

        // Constructor
        public JsonAssetRepository(string filePath)
        {
            this.filePath = filePath;

            Load();
        }

        // Load assets from JSON file
        private void Load()
        {
            if (!File.Exists(filePath))
            {
                assets = new List<CampusAsset>();
                return;
            }

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                assets = new List<CampusAsset>();
                return;
            }

            assets = JsonSerializer.Deserialize<List<CampusAsset>>(
                json,
                options
            ) ?? new List<CampusAsset>();
        }

        // Add new asset
        public void Add(CampusAsset asset)
        {
            if (assets.Any(a =>
                a.AssetId.Equals(
                    asset.AssetId,
                    StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException(
                    "Asset ID already exists.");
            }

            if (assets.Any(a =>
                a.AssetTag.Equals(
                    asset.AssetTag,
                    StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException(
                    "Asset tag already exists.");
            }

            assets.Add(asset);

            Save();
        }

        // Get asset by ID
        public CampusAsset? GetById(string assetId)
        {
            return assets.FirstOrDefault(
                a => a.AssetId.Equals(
                    assetId,
                    StringComparison.OrdinalIgnoreCase)
            );
        }

        // Get all assets
        public List<CampusAsset> GetAll()
        {
            return new List<CampusAsset>(assets);
        }

        // Update asset
        public bool Update(CampusAsset asset)
        {
            int index = assets.FindIndex(
                a => a.AssetId.Equals(
                    asset.AssetId,
                    StringComparison.OrdinalIgnoreCase)
            );

            if (index == -1)
                return false;

            assets[index] = asset;

            Save();

            return true;
        }

        // Delete asset
        public bool Delete(string assetId)
        {
            CampusAsset? asset = GetById(assetId);

            if (asset == null)
                return false;

            assets.Remove(asset);

            Save();

            return true;
        }

        // Save assets to JSON file
        public void Save()
        {
            string? directory = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string json = JsonSerializer.Serialize(
                assets,
                options
            );

            File.WriteAllText(filePath, json);
        }
    }
}
