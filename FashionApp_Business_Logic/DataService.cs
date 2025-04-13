using System;
using System.Collections.Generic;

namespace FashionApp_Business_Logic
{
    public class DataService
    {
        private readonly OutfitService outfitService;

        public DataService()
        {
            outfitService = new OutfitService();
        }

        public string[] GetAvailableOutfits()
        {
            return outfitService.GetAvailableOutfits();
        }

        public string[] GetAvailableActions()
        {
            return new string[]
            {
                "[1] View Available Styles",
                "[2] Select Outfit",
                "[3] Add New Style",
                "[4] Search Styles",
                "[5] Update Style",
                "[6] Delete Style",
                "[7] Exit"
            };
        }
        public OutfitService GetOutfitService()
        {
            return outfitService;
        }
    }
}