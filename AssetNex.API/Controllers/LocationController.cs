
using AssetNex.API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using AssetNex.API.Models.DTO.LiveTracking;
using AssetNex.API.Data;

namespace AssetNex.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class LocationController : ControllerBase

    {
        private readonly ILocationRepository locationRepository;
        private object GetById;

        private readonly ApplicationDbContext applicationDbContext;

   public LocationController(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

      
        [HttpGet("locations")]

        public async Task<IActionResult> GetAllLocations()
        {
            var assets = await locationRepository.GetAllLocationAsync();

            
            var response = assets.Select(asset => new LiveLocationDto

            {

                Id = asset.Id,
                SerialNumber = asset.SerialNumber,
                AssetTypeId = asset.AssetTypeId,
                AssetType = asset.AssetType,
                status = asset.Status,
                Location = asset.Location,
                LastCheckedOut = asset.LastCheckedOut,

            })
            .ToList();

            return Ok(response);
        }

        [HttpPost("locations/create")]

    
        public async Task<IActionResult> CreateLocation([FromBody] LiveLocationDto dto)

        {

            
            var location = await locationRepository.GetLocationByIdAsync(dto.Id);

           
            if (location == null)
                return BadRequest("Asset type not found");


            if (string.IsNullOrEmpty(dto.SerialNumber))
                return BadRequest("Serial Number cannot be empty");

            if (string.IsNullOrEmpty(dto.AssetType))
                return BadRequest("Asset Type cannot be empty");

            if (string.IsNullOrEmpty(dto.status))
                return BadRequest("Status cannot be empty");

            if (string.IsNullOrEmpty(dto.Location))
                return BadRequest("Location cannot be empty");

          
            var asset = new LiveLocationDto
            {
                Id = dto.Id,
                SerialNumber = dto.SerialNumber,
                AssetTypeId = dto.AssetTypeId,
                AssetType = dto.AssetType,
                status = dto.status,
                Location = dto.Location,
                LastCheckedOut = dto.LastCheckedOut,

            };

            await locationRepository.AddLocationAsync(location);

            var response = new LiveLocationDto
            {

                Id = asset.Id,
                SerialNumber = asset.SerialNumber,
                AssetTypeId = asset.AssetTypeId,
                AssetType = asset.AssetType,
                status = asset.status,
                Location = asset.Location,
                LastCheckedOut = asset.LastCheckedOut,
            };

            return CreatedAtAction(nameof(GetById), new { id = asset.Id }, response);


        }


       


    }

}






