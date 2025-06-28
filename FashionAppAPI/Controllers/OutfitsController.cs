using FashionApp_Business_Logic;
using FashionApp_Data_Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FashionAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OutfitsController : ControllerBase
    {
        private readonly OutfitService _outfitService;

        public OutfitsController(OutfitService outfitService)
        {
            _outfitService = outfitService;
        }

        // GET: api/Outfits
        [HttpGet]
        public ActionResult<IEnumerable<OutfitModel>> Get()
        {
            var outfits = _outfitService.GetAllOutfits();
            if (outfits == null || !outfits.Any())
            {
                return NotFound("No outfits found.");
            }
            return Ok(outfits);
        }

        // GET: api/Outfits/{id}
        [HttpGet("{id}")]
        public ActionResult<OutfitModel> Get(int id)
        {
            var outfit = _outfitService.GetOutfitDetails(id);
            if (outfit == null)
            {
                return NotFound($"Outfit with ID {id} not found.");
            }
            return Ok(outfit);
        }

        // GET: api/Outfits/AvailableNames
        [HttpGet("AvailableNames")]
        public ActionResult<IEnumerable<string>> GetAvailableNames()
        {
            var names = _outfitService.GetAvailableOutfitNames();
            if (names == null || !names.Any())
            {
                return NotFound("No available outfit names found.");
            }
            return Ok(names);
        }

        // POST: api/Outfits
        [HttpPost]
        public ActionResult<OutfitModel> Post([FromBody] OutfitModel newOutfit)
        {
            if (newOutfit == null)
            {
                return BadRequest("Outfit data is null.");
            }

            bool success = _outfitService.AddNewOutfit(newOutfit.Name, newOutfit.Recommendation);

            if (success)
            {
                return Ok("Outfit added successfully. You might need to retrieve it by ID or get all outfits to see its assigned ID.");
            }
            else
            {
                return Conflict("Failed to add outfit. It might already exist or name is invalid.");
            }
        }


        // PUT: api/Outfits/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OutfitModel updatedOutfit)
        {
            if (updatedOutfit == null || id != updatedOutfit.Id)
            {
                return BadRequest("Outfit ID mismatch or invalid data.");
            }

            bool success = _outfitService.UpdateOutfit(id, updatedOutfit.Name, updatedOutfit.Recommendation, updatedOutfit.IsAvailable);

            if (success)
            {
                return NoContent();
            }
            else
            {
                var existingOutfit = _outfitService.GetOutfitDetails(id);
                if (existingOutfit == null)
                {
                    return NotFound($"Outfit with ID {id} not found.");
                }
                return Conflict("Failed to update outfit. Name might be a duplicate or other validation failed.");
            }
        }

        // DELETE: api/Outfits/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool success = _outfitService.DeleteOutfit(id);
            if (success)
            {
                return NoContent();
            }
            else
            {
                return NotFound($"Outfit with ID {id} not found or could not be deleted.");
            }
        }

        // GET: api/Outfits/Search?searchTerm={term}
        [HttpGet("Search")]
        public ActionResult<IEnumerable<OutfitModel>> Search([FromQuery] string searchTerm)
        {
            var results = _outfitService.SearchOutfits(searchTerm);
            if (results == null || !results.Any())
            {
                return NotFound($"No outfits found matching '{searchTerm}'.");
            }
            return Ok(results);
        }
    }
}