using Microsoft.AspNetCore.Mvc;
using AssetNex.API.Repositories.Interface;
using AssetNex.API.Models.DomainModel;
using AssetNex.API.Models.DTO.SoftwareLicense;

namespace AssetNex.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

        public class SoftwareLicenseController : ControllerBase
            {

             private readonly ISoftwareLicenseRepository licenseRepository;
       
           public SoftwareLicenseController(ISoftwareLicenseRepository licenseRepository)
        {
            this.licenseRepository = licenseRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllSoftwareLicense()
        {
            var licenses = await licenseRepository.GetAllSoftwareLicense();

            var response = licenses.Select(license => new SoftwareLicenseInfo
            {
                Id = license.Id,
                UserName = license.UserName,
                Request = license.Request,
                EmployeeId = license.EmployeeId,
                SoftwareName = license.SoftwareName,
                OtherSoftware = license.OtherSoftware,
                DateApplied = license.DateApplied,


            }).ToList();

            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var license = await licenseRepository.GetBySoftwareLicenseIdAsync(id);

            if (license == null)
                return NotFound();

            var response = new SoftwareLicenseDto
            {
                Id = license.Id,
                UserName = license.UserName,
                Request = license.Request,
                EmployeeId = license.EmployeeId,
                SoftwareName = license.SoftwareName,
                OtherSoftware = license.OtherSoftware,
                DateApplied = license.DateApplied,
              

                
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSoftwareLicenseDto dto)
        {
    
            var license = new SoftwareLicenseInfo

            {
                Id = Guid.NewGuid(),
                SoftwareName = dto.SoftwareName,
                OtherSoftware = dto.OtherSoftware,
                DateApplied = dto.DateApplied,
                Request= dto.Request,
                UserName= dto.UserName,
                EmployeeId= dto.EmployeeId

            };

            await licenseRepository.CreateAsync(license);

            var response = new SoftwareLicenseDto
            {
                Id = license.Id,
                SoftwareName = license.SoftwareName,
                OtherSoftware = license.OtherSoftware,
                DateApplied = license.DateApplied,
                Request = license.Request,
                UserName = license.UserName,
                EmployeeId = license.EmployeeId,


            };

            return CreatedAtAction(nameof(GetById), new { id = license.Id }, response);
        }

        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateSoftwareLicense([FromRoute]Guid id, SoftwareLicenseDto request)
        {

            {
                var license = new SoftwareLicenseInfo
                {

                    Id = Guid.NewGuid(),
                  
                    SoftwareName = request.SoftwareName,
                    OtherSoftware = request.OtherSoftware,
                    DateApplied = request.DateApplied,
                    Request = request.Request,
                    UserName = request.UserName,
                    EmployeeId = request.EmployeeId,



                };

               license = await licenseRepository.UpdateSoftwareLicenseAsync(license);

                {
                    if (license == null)
                    {
                        return NotFound();

                    }

                    var response = new SoftwareLicenseDto
                    {
                        Id = license.Id,
                        SoftwareName = license.SoftwareName,
                        OtherSoftware=license.OtherSoftware,
                        DateApplied= license.DateApplied,
                        Request = license.Request,
                        UserName = license.UserName,
                        EmployeeId = license.EmployeeId,




                    };

                    return Ok(response);

                }

            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
    

        public async Task<IActionResult> Delete(Guid id)
        {
            var existingCategory = await licenseRepository.GetBySoftwareLicenseIdAsync(id);

            if(existingCategory == null)
                return NotFound();

            await licenseRepository.DeleteAsync(id);

            return NoContent();
        }
    }



}



