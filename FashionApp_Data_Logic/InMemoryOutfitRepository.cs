using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionApp_Data_Logic
{
    public class InMemoryOutfitRepository : IOutfitRepository
    {
        private readonly List<OutfitModel> _outfits = new();
        private int _nextId = 1;

        public InMemoryOutfitRepository()
        {
            // sample data
            AddOutfit(new OutfitModel { Name = "Casual", Recommendation = "Jeans, T-shirt, and Sneakers", IsAvailable = true });
            AddOutfit(new OutfitModel { Name = "Business", Recommendation = "Blazer, Button-up Shirt, and Slacks", IsAvailable = true });
            AddOutfit(new OutfitModel { Name = "Formal", Recommendation = "Suit/Dress and Formal Shoes", IsAvailable = true });
            AddOutfit(new OutfitModel { Name = "Sporty", Recommendation = "Athletic Shirt, Shorts, and Running Shoes", IsAvailable = true });
        }

        public bool AddOutfit(OutfitModel outfit)
        {
            if (outfit == null || string.IsNullOrWhiteSpace(outfit.Name))
                return false;

            if (_outfits.Any(o => o.Name.Equals(outfit.Name, StringComparison.OrdinalIgnoreCase)))
                return false;

            outfit.Id = _nextId++;
            _outfits.Add(outfit);
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
            return true;
        }

        public bool DeleteOutfit(int id)
        {
            var outfit = GetOutfitById(id);
            return outfit != null && _outfits.Remove(outfit);
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
    }
}