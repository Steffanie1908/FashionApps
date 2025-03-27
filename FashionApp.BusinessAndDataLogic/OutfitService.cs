using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionApp.BusinessAndDataLogic
{
    public class OutfitService
    {
        public void DisplayOutfits(string[] outfits)
        {
            Console.WriteLine("\nAVAILABLE STYLES:");
            for (int i = 0; i < outfits.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {outfits[i]}");
            }
        }

        public void SelectOutfit(string[] outfits)
        {
            DisplayOutfits(outfits);
            Console.Write("Your choice: ");
            int outfitChoice = UserInputHelper.GetUserChoice(1, outfits.Length);
            string selectedStyle = outfits[outfitChoice - 1];
            Console.WriteLine($"\nYou selected the {selectedStyle} style!");
            DisplayRecommendation(selectedStyle);
        }


        private void DisplayRecommendation(string style)
        {
            switch (style)
            {
                case "Casual":
                    Console.WriteLine("Recommendation: Jeans, T-shirt, and Sneakers");
                    break;
                case "Business":
                    Console.WriteLine("Recommendation: Blazer, Button-up Shirt, and Slacks");
                    break;
                case "Formal":
                    Console.WriteLine("Recommendation: Suit/Dress and Formal Shoes");
                    break;
                case "Sporty":
                    Console.WriteLine("Recommendation: Athletic Shirt, Shorts, and Running Shoes");
                    break;
                default:
                    Console.WriteLine("No recommendations available for this style.");
                    break;
            }
        }
    }
}
