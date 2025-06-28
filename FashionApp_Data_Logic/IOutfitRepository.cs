using System.Collections.Generic;

namespace FashionApp_Data_Logic
{
    public interface IOutfitRepository
    {
        OutfitModel GetOutfitById(int id);
        List<OutfitModel> GetAllOutfits();
        bool AddOutfit(OutfitModel outfit);
        bool UpdateOutfit(OutfitModel outfit);
        bool DeleteOutfit(int id);
        string[] GetAvailableOutfitNames();
        List<OutfitModel> SearchOutfits(string searchTerm);
        OutfitModel GetOutfitByName(string name);
        OutfitModel GetOutfitDetails(int id); 
        string[] GetAllOutfitNames();     }
}