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

          
            AddSampleOutfits();
        }

        private void AddSampleOutfits()
        {
            
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

        
        public List<OutfitModel> GetAllOutfits()
        {
            return new List<OutfitModel>(outfits);
        }

        
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
        
        public List<OutfitModel> SearchOutfits(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return GetAllOutfits();
            }

            searchTerm = searchTerm.ToLower();

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

      
        public bool UpdateOutfit(int id, string name, string recommendation, bool isAvailable)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            var outfitToUpdate = GetOutfitById(id);
            if (outfitToUpdate == null)
            {
                return false;
            }

            if (outfits.Exists(o => o.Id != id && o.Name.ToLower() == name.ToLower()))
            {
                return false;
            }

            outfitToUpdate.Name = name;
            outfitToUpdate.Recommendation = recommendation;
            outfitToUpdate.IsAvailable = isAvailable;

            return true;
        }

        
        public bool DeleteOutfit(int id)
        {
            var outfitToDelete = GetOutfitById(id);
            if (outfitToDelete == null)
            {
                return false;
            }

            return outfits.Remove(outfitToDelete);
        }
    }
}