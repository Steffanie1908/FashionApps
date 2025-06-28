using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace FashionApp_Data_Logic
{
    public class JsonFileOutfitRepository : IOutfitRepository
    {
        private readonly string _filePath;
        private List<OutfitModel> _outfits;
        private int _nextId;

        public JsonFileOutfitRepository(string filePath)
        {
            _filePath = filePath;
            LoadOutfits();
        }

        private void LoadOutfits()
        {
            if (!File.Exists(_filePath))
            {
                _outfits = new List<OutfitModel>();
                _nextId = 1;
                return;
            }

            var json = File.ReadAllText(_filePath);
            _outfits = JsonSerializer.Deserialize<List<OutfitModel>>(json) ?? new List<OutfitModel>();
            _nextId = _outfits.Count > 0 ? _outfits.Max(o => o.Id) + 1 : 1;
        }

        private void SaveOutfits()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(_outfits, options);
            File.WriteAllText(_filePath, json);
        }

        public bool AddOutfit(OutfitModel outfit)
        {
            if (outfit == null || string.IsNullOrWhiteSpace(outfit.Name))
                return false;

            if (_outfits.Any(o => o.Name.Equals(outfit.Name, StringComparison.OrdinalIgnoreCase)))
                return false;

            outfit.Id = _nextId++;
            _outfits.Add(outfit);
            SaveOutfits();
            return true;
        }

        public List<OutfitModel> GetAllOutfits() => new List<OutfitModel>(_outfits);

        public OutfitModel GetOutfitById(int id) => _outfits.FirstOrDefault(o => o.Id == id);

        public bool UpdateOutfit(OutfitModel outfit)
        {
            var existing = GetOutfitById(outfit.Id);
            if (existing == null) return false;

            if (_outfits.Any(o => o.Id != outfit.Id &&
                o.Name.Equals(outfit.Name, StringComparison.OrdinalIgnoreCase)))
                return false;

            existing.Name = outfit.Name;
            existing.Recommendation = outfit.Recommendation;
            existing.IsAvailable = outfit.IsAvailable;
            SaveOutfits();
            return true;
        }

        public bool DeleteOutfit(int id)
        {
            var outfit = GetOutfitById(id);
            if (outfit == null) return false;

            var result = _outfits.Remove(outfit);
            if (result) SaveOutfits();
            return result;
        }

        public List<OutfitModel> SearchOutfits(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return GetAllOutfits();

            searchTerm = searchTerm.ToLower();
            return _outfits.Where(o =>
                o.Name.ToLower().Contains(searchTerm) ||
                o.Recommendation.ToLower().Contains(searchTerm))
                .ToList();
        }

        public string[] GetAvailableOutfitNames() =>
            _outfits.Where(o => o.IsAvailable).Select(o => o.Name).ToArray();

        public string[] GetAllOutfitNames()
        {
            return _outfits
                .OrderBy(o => o.Name)
                .Select(o => o.Name)
                .ToArray();
        }
        public OutfitModel GetOutfitDetails(int id)
        {
            return GetOutfitById(id);
        }

        public OutfitModel GetOutfitByName(string name)
        {
            return _outfits.FirstOrDefault(o => o.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}