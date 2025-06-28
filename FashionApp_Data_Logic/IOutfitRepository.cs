using System.Collections.Generic;

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
        string[] GetAllOutfitNames(); 
    }
}