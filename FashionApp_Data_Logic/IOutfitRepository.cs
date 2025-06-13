using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionApp_Data_Logic
{
    public interface IOutfitRepository
    {
        bool AddOutfit(OutfitModel outfit);
        List<OutfitModel> GetAllOutfits();
        OutfitModel GetOutfitById(int id);
        bool UpdateOutfit(OutfitModel outfit);
        bool DeleteOutfit(int id);
        List<OutfitModel> SearchOutfits(string searchTerm);
        string[] GetAvailableOutfitNames();
    }
}

