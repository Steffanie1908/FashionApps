using System.Collections.Generic;
using System.Linq;

namespace FashionApp_Data_Logic
{
    public class InMemoryOutfitRepository : IOutfitRepository
    {
        private readonly List<OutfitModel> _outfits;
        private int _nextId;

        public InMemoryOutfitRepository()
        {
            _outfits = new List<OutfitModel>();
            _nextId = 1;
            SeedData();
        }

        private void SeedData()
        {
            AddOutfit(new OutfitModel { Name = "Casual Chic", Recommendation = "Pair with white sneakers and a crossbody bag.", IsAvailable = true });
            AddOutfit(new OutfitModel { Name = "Formal Evening", Recommendation = "Accessorize with a clutch and high heels.", IsAvailable = true });
            AddOutfit(new OutfitModel { Name = "Sporty Look", Recommendation = "Combine with athletic shoes and a cap.", IsAvailable = true });
            AddOutfit(new OutfitModel { Name = "Boho Vibes", Recommendation = "Wear with sandals and layered jewelry.", IsAvailable = true });
            AddOutfit(new OutfitModel { Name = "Winter Comfort", Recommendation = "Layer with a warm scarf and boots.", IsAvailable = true });
            AddOutfit(new OutfitModel { Name = "Summer Breeze", Recommendation = "Light fabric and open-toe shoes.", IsAvailable = true });
        }

        public OutfitModel GetOutfitById(int id)
        {
            return _outfits.FirstOrDefault(o => o.Id == id);
        }

        public OutfitModel GetOutfitByName(string name)
        {
            return _outfits.FirstOrDefault(o => o.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
        }

        public List<OutfitModel> GetAllOutfits()
        {
            return new List<OutfitModel>(_outfits);
        }

        public bool AddOutfit(OutfitModel outfit)
        {
            if (_outfits.Any(o => o.Name.Equals(outfit.Name, System.StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }
            outfit.Id = _nextId++;
            _outfits.Add(outfit);
            return true;
        }

        public bool UpdateOutfit(OutfitModel outfit)
        {
            var existingOutfit = GetOutfitById(outfit.Id);
            if (existingOutfit == null)
            {
                return false;
            }
            if (_outfits.Any(o => o.Id != outfit.Id && o.Name.Equals(outfit.Name, System.StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            existingOutfit.Name = outfit.Name;
            existingOutfit.Recommendation = outfit.Recommendation;
            existingOutfit.IsAvailable = outfit.IsAvailable;
            return true;
        }

        public bool DeleteOutfit(int id)
        {
            var outfitToRemove = GetOutfitById(id);
            if (outfitToRemove == null)
            {
                return false;
            }
            _outfits.Remove(outfitToRemove);
            return true;
        }

        public string[] GetAvailableOutfitNames()
        {
            return _outfits.Where(o => o.IsAvailable).Select(o => o.Name).ToArray();
        }

        public List<OutfitModel> SearchOutfits(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return new List<OutfitModel>(_outfits);
            }

            string lowerSearchTerm = searchTerm.ToLower();
            return _outfits
                .Where(o => o.Name.ToLower().Contains(lowerSearchTerm) ||
                            o.Recommendation.ToLower().Contains(lowerSearchTerm))
                .ToList();
        }

        public OutfitModel GetOutfitDetails(int id)
        {
            return GetOutfitById(id); 
        }

        public string[] GetAllOutfitNames()
        {
            return _outfits.Select(o => o.Name).OrderBy(name => name).ToArray();
        }
    }
}