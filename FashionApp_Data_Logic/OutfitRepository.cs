using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionApp_Data_Logic
{
    public class OutfitRepository
    {
        // list to store outfits
        private readonly List<OutfitModel> outfits;
        private int nextId;

        public OutfitRepository()
        {
            outfits = new List<OutfitModel>();
            nextId = 1;

            // Sample outfits added 
            AddSampleOutfits();
        }

        private void AddSampleOutfits()
        {
            // Add initial outfit styles with recommendations
            outfits.Add(new OutfitModel
            {
                Id = nextId++,
                Name = "Casual",
                Recommendation = "Jeans, T-shirt, and Sneakers",
                IsAvailable = true
            });

            outfits.Add(new OutfitModel
            {
                Id = nextId++,
                Name = "Business",
                Recommendation = "Blazer, Button-up Shirt, and Slacks",
                IsAvailable = true
            });

            outfits.Add(new OutfitModel
            {
                Id = nextId++,
                Name = "Formal",
                Recommendation = "Suit/Dress and Formal Shoes",
                IsAvailable = true
            });

            outfits.Add(new OutfitModel
            {
                Id = nextId++,
                Name = "Sporty",
                Recommendation = "Athletic Shirt, Shorts, and Running Shoes",
                IsAvailable = true
            });
        }

        // CREATE: Add a new outfit
        public bool AddOutfit(string name, string recommendation)
        {
            // Check for empty name
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            // Check for duplicate name
            if (outfits.Exists(o => o.Name.ToLower() == name.ToLower()))
            {
                return false;
            }

            // Create and add new outfit
            outfits.Add(new OutfitModel
            {
                Id = nextId++,
                Name = name,
                Recommendation = recommendation,
                IsAvailable = true
            });

            return true;
        }

        // RETRIEVE: Get all outfits
        public List<OutfitModel> GetAllOutfits()
        {
            return new List<OutfitModel>(outfits);
        }

        // RETRIEVE: Get available outfit names as array
        public string[] GetAvailableOutfitNames()
        {
            List<string> names = new List<string>();

            foreach (var outfit in outfits)
            {
                if (outfit.IsAvailable)
                {
                    names.Add(outfit.Name);
                }
            }

            return names.ToArray();
        }

        // RETRIEVE: Finds outfit by ID
        public OutfitModel GetOutfitById(int id)
        {
            foreach (OutfitModel outfit in outfits)
            {
                if (outfit.Id == id)
                {
                    return outfit;
                }
            }

            return null;
        }
        // SEARCH: Find outfits by search term
        public List<OutfitModel> SearchOutfits(string searchTerm)
        {
            // If search term is empty, return all outfits
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return GetAllOutfits();
            }

            searchTerm = searchTerm.ToLower();

            // Search through outfits for matching name or recommendation
            List<OutfitModel> results = new List<OutfitModel>();
            foreach (var outfit in outfits)
            {
                if (outfit.Name.ToLower().Contains(searchTerm) ||
                    outfit.Recommendation.ToLower().Contains(searchTerm))
                {
                    results.Add(outfit);
                }
            }

            return results;
        }

        // UPDATE: Modifies an existing outfit
        public bool UpdateOutfit(int id, string name, string recommendation, bool isAvailable)
        {
            // Checks for empty name
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            // Find the outfit to update
            var outfitToUpdate = GetOutfitById(id);
            if (outfitToUpdate == null)
            {
                return false;
            }

            // Checks for duplicate name (that isn't this outfit)
            if (outfits.Exists(o => o.Id != id && o.Name.ToLower() == name.ToLower()))
            {
                return false;
            }

            // Updates the outfit
            outfitToUpdate.Name = name;
            outfitToUpdate.Recommendation = recommendation;
            outfitToUpdate.IsAvailable = isAvailable;

            return true;
        }

        // DELETE: Removes an outfit
        public bool DeleteOutfit(int id)
        {
            // Finds the outfit to delete
            var outfitToDelete = GetOutfitById(id);
            if (outfitToDelete == null)
            {
                return false;
            }

            // Removes the outfit
            return outfits.Remove(outfitToDelete);
        }
    }
}