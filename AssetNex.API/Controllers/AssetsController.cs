using System.ComponentModel.DataAnnotations.Schema;
using AssetNex.API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using AssetNex.API.Models.DomainModel;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Hosting;
using AssetNex.API.Repositories.Implementation;
using Azure;
using System;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Identity.Client;
using AssetNex.API.Models.DTO.Asset;
using Microsoft.AspNetCore.Authorization;

namespace AssetNex.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class AssetsController : ControllerBase

    {
        private readonly IAssetsRepository assetsRepository;

        public AssetsController(IAssetsRepository assetsRepository)
        {
            this.assetsRepository = assetsRepository;
        }

        //GET : apibasedurl/api/assets
        [HttpGet]
        
            public async Task<IActionResult> getAllAssets()
            {
                var assets = await assetsRepository.getAllAssets();

            // Convert domain model to DTO
            var response = assets.Select(asset => new AssetInfo
            {
                Id = asset.Id,
                Name = asset.Name,
                SerialNumber = asset.SerialNumber,
                Department = asset.Department,
                DateOfIssue = asset.DateOfIssue,
                WarrantyDate = asset.WarrantyDate,
                User = asset.User,
                UserId = asset.UserId,
                Status = asset.Status,
               
                AssetTypeId = asset.AssetTypeId,
            })
            .ToList();

                return Ok(response);
            }

        [HttpPost]

        //post =
        public async Task<IActionResult> CreateAsset([FromBody] CreateAssetDto dto)

        //convert dto to domain model , mapping, //save via db to repository,
        //convert back to dto , map back to it for response 
        {
            var assetType = await assetsRepository.GetAssetTypeByIdAsync(dto.AssetTypeId);

            //VALIDATING ASSET TYPE

            if (assetType == null)
                return BadRequest("Asset type not found");

            //create domain model
            var asset = new AssetInfo
            {

                Id= Guid.NewGuid(),
                Name= dto.Name,
                SerialNumber = dto.SerialNumber,
                Department = dto.Department,
                DateOfIssue= dto.DateOfIssue,
                WarrantyDate= dto.WarrantyDate,
                AssetTypeId= dto.AssetTypeId,
                Status= dto.Status,
                UserId= dto.UserId,

            };

            await assetsRepository.AddAssetAsync(asset);

            //create reposnse dto, domain to dto

            var response = new AssetDto
            {
                Id = asset.Id,
                Name = asset.Name,
                SerialNumber = asset.SerialNumber,
                Department = asset.Department,
                DateOfIssue = asset.DateOfIssue,
                WarrantyDate = asset.WarrantyDate,
                Status = asset.Status,
                UserId = asset.UserId,
                AssetTypeName = assetType.Name
            };

            return CreatedAtAction(nameof(GetAssetById), new { id = asset.Id }, response);

            //return Ok(asset);

            //public Guid Id { get; set; }

            //post AssetTypeId = CreateInventoryDto.assetTypeId;

            //    }
        }

    
 // GET by Id 

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssetById(Guid id)
        {
            var asset = await assetsRepository.GetAssetByIdAsync(id);

            if (asset == null)
                return NotFound();

            var response = new AssetDto
            {
                Id = asset.Id,
                Name = asset.Name,
                SerialNumber = asset.SerialNumber,
                Department = asset.Department,
                DateOfIssue = asset.DateOfIssue,
                WarrantyDate = asset.WarrantyDate,
                Status = asset.Status,
                UserId = asset.UserId,
                AssetTypeName = asset.AssetType?.Name,

            };

            return Ok(response);
        }


       
       //PUT

        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> EditAsset([FromRoute] Guid id, UpdateAssetRequestDto request)
        {
            var asset = new AssetInfo
            {

                Name = request.Name,
                SerialNumber = request.SerialNumber,
                Department = request.Department,
                DateOfIssue = request.DateOfIssue,
                WarrantyDate = request.WarrantyDate,
                AssetTypeId = request.AssetTypeId,
                Status = request.Status,
                UserId = request.UserId,


            };

            asset = await assetsRepository.UpdateAsync(asset);

            {
                if (asset == null)
                {
                    return NotFound();

                }
                //convert domain model to dto 

                var response = new AssetDto
                {
                    Id= asset.Id,
                    Name = asset.Name,
                    SerialNumber = asset.SerialNumber,
                    Department = asset.Department,
                    DateOfIssue =asset.DateOfIssue,
                    WarrantyDate = asset.WarrantyDate,
                    Status = asset.Status,
                    UserId = asset.UserId,

                };

                return Ok(response);

            }

        }

        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteAsset([FromRoute] Guid id)
        {
            {
                var currentAsset = await assetsRepository.GetById(id);

                if (currentAsset == null)
                {
                    return NotFound();
                }

                await assetsRepository.DeleteAsync(id);

                return NoContent();

            }
        }
    }

}






