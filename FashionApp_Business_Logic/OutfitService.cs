using FashionApp_Data_Logic;
using System.Collections.Generic;
using System.Linq;

namespace FashionApp_Business_Logic
{
    public class OutfitService
    {
        private readonly IOutfitRepository _outfitRepository;

        public OutfitService(IOutfitRepository outfitRepository)
        {
            _outfitRepository = outfitRepository;
        }

        public string GetRecommendation(string outfitName)
        {
            var outfit = _outfitRepository.GetOutfitByName(outfitName);
            return outfit?.Recommendation ?? "No recommendation found for this style.";
        }

        public string[] GetAvailableOutfitNames()
        {
            return _outfitRepository.GetAvailableOutfitNames();
        }

        public bool AddNewOutfit(string name, string recommendation, bool isAvailable)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(recommendation))
            {
                return false;
            }

            var newOutfit = new OutfitModel
            {
                Name = name,
                Recommendation = recommendation,
                IsAvailable = isAvailable
            };

            return _outfitRepository.AddOutfit(newOutfit);
        }

        public List<OutfitModel> GetAllOutfits()
        {
            return _outfitRepository.GetAllOutfits();
        }

        public OutfitModel GetOutfitById(int id)
        {
            return _outfitRepository.GetOutfitById(id);
        }

        public bool UpdateOutfit(int id, string newName, string newRecommendation, bool isAvailable)
        {
            var outfitToUpdate = _outfitRepository.GetOutfitById(id);
            if (outfitToUpdate == null)
            {
                return false;
            }

            outfitToUpdate.Name = newName;
            outfitToUpdate.Recommendation = newRecommendation;
            outfitToUpdate.IsAvailable = isAvailable;

            return _outfitRepository.UpdateOutfit(outfitToUpdate);
        }

        public bool DeleteOutfit(int id)
        {
            return _outfitRepository.DeleteOutfit(id);
        }

        public List<OutfitModel> SearchOutfits(string searchTerm)
        {
            return _outfitRepository.SearchOutfits(searchTerm);
        }

        public OutfitModel GetOutfitDetails(int id)
        {
            return _outfitRepository.GetOutfitById(id);
        }

        public bool AddNewOutfit(string name, string recommendation)
        {

            return AddNewOutfit(name, recommendation, true);
        }
    }
}