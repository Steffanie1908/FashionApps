using System;
using System.Collections.Generic;

namespace FashionApp.BusinessAndDataLogic
{
    public class OutfitService
    {
        // gets the clothing recommendation for a specific style
        public string GetRecommendation(string style)
        {
            switch (style)
            {
                case "Casual":
                    return "Jeans, T-shirt, and Sneakers";
                case "Business":
                    return "Blazer, Button-up Shirt, and Slacks";
                case "Formal":
                    return "Suit/Dress and Formal Shoes";
                case "Sporty":
                    return "Athletic Shirt, Shorts, and Running Shoes";
                default:
                    return "No recommendations available for this style.";
            }
        }
    }
}