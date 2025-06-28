using System;
using System.Collections.Generic;
using FashionApp_Data_Logic;

namespace FashionApp_Business_Logic
{
    public class OutfitService
    {
        private readonly IOutfitRepository _repository;

        public OutfitService(IOutfitRepository repository)
        {
            _repository = repository;
        }

        public string GetRecommendation(string style)
        {
            var outfits = _repository.GetAllOutfits();
            var outfit = outfits.FirstOrDefault(o =>
                o.Name.Equals(style, StringComparison.OrdinalIgnoreCase));

            return outfit?.Recommendation ?? "No recommendations available for this style.";
        }

        public string[] GetAvailableOutfits()
        {
            return _repository.GetAvailableOutfitNames();
        }

        public bool AddNewOutfit(string name, string recommendation)
        {
            var outfit = new OutfitModel
            {
                Name = name,
                Recommendation = recommendation,
                IsAvailable = true
            };
            return _repository.AddOutfit(outfit);
        }
        public bool AddOutfit(OutfitModel newOutfit)
        {
            if (newOutfit == null)
            {
                return false;
            }
            return _repository.AddOutfit(newOutfit);
        }

        public List<OutfitModel> GetAllOutfits()
        {
            return _repository.GetAllOutfits();
        }

        public List<OutfitModel> SearchOutfits(string searchTerm)
        {
            return _repository.SearchOutfits(searchTerm);
        }

        public OutfitModel GetOutfitDetails(int id)
        {
            return _repository.GetOutfitById(id);
        }

        public bool UpdateOutfit(int id, string name, string recommendation, bool isAvailable)
        {
            var existingOutfit = _repository.GetOutfitById(id);
            if (existingOutfit == null)
                return false;

            var updatedOutfit = new OutfitModel
            {
                Id = id,
                Name = name,
                Recommendation = recommendation,
                IsAvailable = isAvailable
            };

            return _repository.UpdateOutfit(updatedOutfit);
        }

        public string[] GetAllOutfitNames() 
        {
            return _repository.GetAllOutfitNames();
        }


        public bool DeleteOutfit(int id)
        {
            return _repository.DeleteOutfit(id);
        }
    }
}