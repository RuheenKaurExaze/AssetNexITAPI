
using AssetNex.API.Models.DomainModel;
using AssetNex.API.Models.DTO.Hardware;
using AssetNex.API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AssetNex.API.Controllers

{
    [ApiController]
    [Route("api/[controller]")]


    public class HardwareController : ControllerBase
    {
        private readonly IHardwareRepository hardwareRepository;

        public HardwareController(IHardwareRepository hardwareRepository)
        {
            this.hardwareRepository = hardwareRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getAllHardware()
        {
            var assets = await hardwareRepository.getAllHardware();


            var response = assets.Select(asset => new Hardware
            {
                Id = asset.Id,
                ProblemDescription = asset.ProblemDescription,
                AssetTypeId = asset.AssetTypeId,
                SerialNumber = asset.SerialNumber,
                AssetName = asset.AssetName,
                AssetType = asset.AssetType,
                DateSubmitted = asset.DateSubmitted,
                DateOfIssue = asset.DateOfIssue,
                WarrantyDate = asset.DateSubmitted
            }).ToList();

            return Ok(response);


        }

        [HttpPost]

        public async Task<IActionResult> CreateHardware([FromBody] CreateHardwareDto dto)


        {
            var assetType = await hardwareRepository.GetHardwareTypeByIdAsync(dto.AssetTypeId);

            if (assetType == null)
                return BadRequest("Asset type not found");

            var asset = new Hardware
            {
                Id = Guid.NewGuid(),
                ProblemDescription = dto.ProblemDescription,


                AssetTypeId = dto.AssetTypeId,

                SerialNumber = dto.SerialNumber,
                AssetName = dto.AssetName,
                AssetType = dto.AssetType,

                DateSubmitted = dto.DateSubmitted,

                DateOfIssue = dto.DateOfIssue,

                WarrantyDate = dto.WarrantyDate,
            };

            await hardwareRepository.AddHardwareAsync(asset);


            var response = new CreateHardwareDto
            {
                Id = asset.Id,
                ProblemDescription = asset.ProblemDescription,


                AssetTypeId = asset.AssetTypeId,

                SerialNumber = asset.SerialNumber,
                AssetName = asset.AssetName,
                AssetType = asset.AssetType,

                DateSubmitted = asset.DateSubmitted,

                DateOfIssue = asset.DateOfIssue,

                WarrantyDate = asset.WarrantyDate,

            };

            return CreatedAtAction(nameof(GetHardwareById), new { id = asset.Id }, response);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHardwareById(Guid id)
        {
            var asset = await hardwareRepository.GetHardwareByIdAsync(id);

            if (asset == null)
                return NotFound();

            var response = new CreateHardwareDto
            {
                Id = asset.Id,
                ProblemDescription = asset.ProblemDescription,
                AssetTypeId = asset.AssetTypeId,
                SerialNumber = asset.SerialNumber,
                AssetName = asset.AssetName,
                AssetType = asset.AssetType,
                DateSubmitted = asset.DateSubmitted,
                DateOfIssue = asset.DateOfIssue,
                WarrantyDate = asset.WarrantyDate,


            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> EditHardware([FromRoute] Guid id, CreateHardwareDto request)
        {
            var asset = new Hardware
            {

                Id = request.Id,
                ProblemDescription = request.ProblemDescription,


                AssetTypeId = request.AssetTypeId,

                SerialNumber = request.SerialNumber,
                AssetName = request.AssetName,
                AssetType = request.AssetType,

                DateSubmitted = request.DateSubmitted,

                DateOfIssue = request.DateOfIssue,

                WarrantyDate = request.WarrantyDate,



            };

            asset = await hardwareRepository.UpdateAsync(asset);

            {
                if (asset == null)
                {
                    return NotFound();

                }

                var response = new CreateHardwareDto
                {
                    Id = asset.Id,
                    ProblemDescription = asset.ProblemDescription,
                    AssetTypeId = asset.AssetTypeId,
                    SerialNumber = asset.SerialNumber,
                    AssetName = asset.AssetName,
                    AssetType = asset.AssetType,
                    DateSubmitted = asset.DateSubmitted,
                    DateOfIssue = asset.DateOfIssue,
                    WarrantyDate = asset.WarrantyDate,


                };

                return Ok(response);

            }

        }

        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteAsset([FromRoute] Guid id)
        {
            {
                var currentAsset = await hardwareRepository.GetById(id);

                if (currentAsset == null)
                {
                    return NotFound();
                }

                await hardwareRepository.DeleteAsync(id);

                return NoContent();

            }
        }
    }
}

