using AssetNex.API.Data;
using AssetNex.API.Models.DomainModel;
using AssetNex.API.Models.DTO.LiveTracking;
using AssetNex.API.Repositories.Implementation;
using AssetNex.API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AssetNex.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class AssetLocationsController : ControllerBase

    {
        private readonly ILocationRepository locationRepository;


        public AssetLocationsController(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllAssetLocations()
        {
            var assets = await locationRepository.GetAssetLocationAsync();

            var response = assets.Select(asset => new AssetLocations
            {

                Id = asset.Id,
                SerialNumber = asset.SerialNumber,
                AssetTypeId = asset.AssetTypeId,
                AssetType = asset.AssetType,
                Status = asset.Status,
                Location = asset.Location,
                LastCheckedOut = asset.LastCheckedOut,
                Latitude = asset.Latitude,
                Longitude = asset.Longitude,
                Name = asset.Name,


            }).ToList();

            return Ok(response);
        }


        //[HttpPost]

        //public async Task<IActionResult> CreateAssetLocationDto([FromBody] AssetLocationDto assetLocationDto)


        //{
        //    var location = await locationRepository.GetLocationByIdAsync(dto Id);

        //    if (location == null)

        //    {
        //        return BadRequest("AssetType  not found");
        //    }

        //    var asset = new AssetLocationDto
        //    {

        //        Id = assetLocationDto.Id,
        //        SerialNumber = assetLocationDto.SerialNumber,
        //        AssetTypeId = assetLocationDto.AssetTypeId,
        //        AssetType = assetLocationDto.AssetType,
        //        Location = assetLocationDto.Location,
        //        LastCheckedOut = assetLocationDto.LastCheckedOut,
        //        Latitude = assetLocationDto.Latitude,
        //        Longitude = assetLocationDto.Longitude,
        //        Name = assetLocationDto.Name,




        //    };

        //    await locationRepository.AddAssetLocationAsync(asset);


        //    var location = new AssetLocationDto
        //    {
        //        Id = asset.Id,
        //        SerialNumber = asset.SerialNumber,
        //        AssetTypeId = asset.AssetTypeId,
        //        AssetType = asset.AssetType,
        //        Location = asset.Location,
        //        LastCheckedOut = asset.LastCheckedOut,
        //        Latitude = asset.Latitude,
        //        Longitude = asset.Longitude,
        //        Name = asset.Name,


//    };

//            return CreatedAtActionAsync(nameof(GetLocationById), new { id = dto.Id
//}, response);
//        });



//return CreatedAtAction(response);



//        }

        [HttpPost("assetlocations/create")]

        public async Task<IActionResult> CreateAssetLocation([FromBody] AssetLocations dto)

        {
            var location = await locationRepository.GetLocationByIdAsync(dto.Id);

        
            if (location == null)
                return BadRequest("Asset type not found");

        
            var asset = new AssetLocationDto
            {
                Id = dto.Id,
                SerialNumber = dto.SerialNumber,
                AssetTypeId = dto.AssetTypeId,
                AssetType = dto.AssetType,
                status = dto.Status,
                Location = dto.Location,
                LastCheckedOut = dto.LastCheckedOut,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                Name = dto.Name,
             

            };

            await locationRepository.AddAssetLocationAsync(asset);

            var response = new AssetLocationDto
            {

                Id = asset.Id,
                SerialNumber = asset.SerialNumber,
                AssetTypeId = asset.AssetTypeId,
                AssetType = asset.AssetType,
                status = asset.status,
                Location = asset.Location,
                LastCheckedOut = asset.LastCheckedOut,
                Latitude = asset.Latitude,
                Longitude = asset.Longitude,
                Name = asset.Name
            };


            return CreatedAtAction(nameof(GetByLocationId), new
            {
                id = dto.Id
            }, response);



            return CreatedAtAction(response);


        }

        private object GetByLocationId()
        {
            throw new NotImplementedException();
        }

        private IActionResult CreatedAtAction(AssetLocationDto response)
        {
            throw new NotImplementedException();
        }
    }

}

