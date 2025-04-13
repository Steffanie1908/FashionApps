using System;
using System.Collections.Generic;
using FashionApp_Data_Logic;

namespace FashionApp_Business_Logic
{
    public class OutfitService
    {
        private OutfitRepository repository;

        public OutfitService()
        {
            repository = new OutfitRepository();
        }

        // Get recommendation for a style
        public string GetRecommendation(string style)
        {
            List<OutfitModel> outfits = repository.GetAllOutfits();

            foreach (OutfitModel outfit in outfits)
            {
                if (outfit.Name.ToLower() == style.ToLower())
                {
                    return outfit.Recommendation;
                }
            }

            return "No recommendations available for this style.";
        }

        // Get array of available outfit names
        public string[] GetAvailableOutfits()
        {
            return repository.GetAvailableOutfitNames();
        }

        // CREATE: Adds a new outfit
        public bool AddNewOutfit(string name, string recommendation)
        {
            return repository.AddOutfit(name, recommendation);
        }

        // RETRIEVE: Get all outfits
        public List<OutfitModel> GetAllOutfits()
        {
            return repository.GetAllOutfits();
        }

        // SEARCH: Find outfits by search term
        public List<OutfitModel> SearchOutfits(string searchTerm)
        {
            return repository.SearchOutfits(searchTerm);
        }

        // RETRIEVE: Get outfit details by ID
        public OutfitModel GetOutfitDetails(int id)
        {
            return repository.GetOutfitById(id);
        }

        // UPDATE: Modify an existing outfit
        public bool UpdateOutfit(int id, string name, string recommendation, bool isAvailable)
        {
            return repository.UpdateOutfit(id, name, recommendation, isAvailable);
        }

        // DELETE: Remove an outfit
        public bool DeleteOutfit(int id)
        {
            return repository.DeleteOutfit(id);
        }
    }
}