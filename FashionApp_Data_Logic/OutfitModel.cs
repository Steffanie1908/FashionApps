using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionApp_Data_Logic
{
    public class OutfitModel
    {
        // Converted public fields to properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Recommendation { get; set; } // Changed from Description to Recommendation
        public bool IsAvailable { get; set; }
    }
}