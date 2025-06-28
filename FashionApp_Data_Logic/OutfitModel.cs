using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionApp_Data_Logic
{
    public class OutfitModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Recommendation { get; set; }
        public bool IsAvailable { get; set; }
    }
}