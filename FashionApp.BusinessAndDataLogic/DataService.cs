using System;
using System.Collections.Generic;

namespace FashionApp.BusinessAndDataLogic
{
    public class DataService
    {
        public string[] GetAvailableOutfits() => new string[] { "Casual", "Business", "Formal", "Sporty" };

        public string[] GetAvailableActions() => new string[] { "[1] View Available Styles", "[2] Select Outfit", "[3] Exit" };
    }
}