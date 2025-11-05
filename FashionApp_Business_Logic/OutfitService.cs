using FashionApp_Data_Logic;
using System.Collections.Generic;
using System.Linq;

namespace FashionApp_Business_Logic
{
    public class OutfitService
    {
        private readonly IOutfitRepository _outfitRepository;
        private readonly EmailService _emailService;
        private string _userEmail;

        public OutfitService(IOutfitRepository outfitRepository, EmailService emailService)
        {
            _outfitRepository = outfitRepository;
            _emailService = emailService;
            _userEmail = null;
        }

        public OutfitService(IOutfitRepository outfitRepository)
        {
            _outfitRepository = outfitRepository;
            _emailService = new EmailService();
            _userEmail = null;
        }

        public void SetUserEmail(string userEmail)
        {
            _userEmail = userEmail;
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

        public bool AddNewOutfit(string name, string recommendation)
        {
            return AddNewOutfit(name, recommendation, true);
        }

        public bool AddNewOutfitWithEmail(string name, string recommendation, string recipientEmail)
        {
            bool success = AddNewOutfit(name, recommendation, true);
            if (success && !string.IsNullOrWhiteSpace(recipientEmail))
            {
                _emailService.SendOutfitAddedEmail(recipientEmail, name, recommendation);
            }
            return success;
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

        public bool UpdateOutfitWithEmail(int id, string newName, string newRecommendation, bool isAvailable, string recipientEmail)
        {
            var oldOutfit = _outfitRepository.GetOutfitById(id);
            if (oldOutfit == null)
                return false;

            string oldName = oldOutfit.Name;
            string oldRec = oldOutfit.Recommendation;

            bool success = UpdateOutfit(id, newName, newRecommendation, isAvailable);

            if (success && !string.IsNullOrWhiteSpace(recipientEmail))
            {
                _emailService.SendOutfitUpdatedEmail(recipientEmail, oldName, newName, oldRec, newRecommendation);
            }

            return success;
        }

        public bool DeleteOutfit(int id)
        {
            return _outfitRepository.DeleteOutfit(id);
        }
        public bool DeleteOutfitWithEmail(int id, string recipientEmail)
        {
            var outfit = _outfitRepository.GetOutfitById(id);
            if (outfit == null)
                return false;

            string outfitName = outfit.Name;
            bool success = DeleteOutfit(id);

            if (success && !string.IsNullOrWhiteSpace(recipientEmail))
            {
                _emailService.SendOutfitDeletedEmail(recipientEmail, outfitName);
            }

            return success;
        }

        public List<OutfitModel> SearchOutfits(string searchTerm)
        {
            return _outfitRepository.SearchOutfits(searchTerm);
        }

        public OutfitModel GetOutfitDetails(int id)
        {
            return _outfitRepository.GetOutfitById(id);
        }

        public void SendOutfitRecommendationEmail(string outfitName)
        {
            if (string.IsNullOrWhiteSpace(_userEmail))
            {
                return;
            }
            var outfit = _outfitRepository.GetOutfitByName(outfitName);
            if (outfit != null)
            {
                _emailService.SendOutfitRecommendationEmail(_userEmail, outfit.Name, outfit.Recommendation);
            }
        }
        public bool SendOutfitRecommendationEmail(int id, string recipientEmail)
        {
            if (string.IsNullOrWhiteSpace(recipientEmail))
                return false;

            var outfit = _outfitRepository.GetOutfitById(id);
            if (outfit == null)
                return false;

            return _emailService.SendOutfitRecommendationEmail(recipientEmail, outfit.Name, outfit.Recommendation);
        }
    }
}