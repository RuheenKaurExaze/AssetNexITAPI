


using AssetNex.API.Models.DomainModel;
using AssetNex.API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using AssetNex.API.Models.DTO.NewSupport;



namespace AssetNex.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


        public class NewSupportController : ControllerBase
    {
        private readonly ISupportRepository supportRepository;

        public NewSupportController(ISupportRepository supportRepository)
        {
            this.supportRepository = supportRepository;
        }

       


        [HttpPost()] 
        public async Task<IActionResult> CreateNewSupportDto([FromBody] CreateNewSupportDto dto)
        {
            var supportType = await supportRepository.GetSupportTypeByIdAsync(dto.Id);

            //VALIDATING ASSET TYPE

            if (supportType == null)
                return BadRequest("Support type not found");
            // Mapping from DTO to Domain Model
            var support = new NewSupport
            {
                Id = dto.Id,
                UserName = dto.UserName,
                EmployeeId = dto.EmployeeId,
                Email = dto.Email,
                Department = dto.Department,
                RequestType = dto.RequestType,
                
            };

            support = await supportRepository.CreateAsync(support);

            // Mapping back to DTO for response
            var response = new CreateNewSupportDto
            {

                Id = support.Id,
                UserName = support.UserName,
                EmployeeId = support.EmployeeId,
                Email = support.Email,
                Department = support.Department,
                RequestType = support.RequestType,
              

            };

            return CreatedAtAction(nameof(GetSupportTypeByIdAsync), new { id = support.Id }, response);
        }



        [HttpGet]
        public async Task<IActionResult> getAllSupport()
        {
            var getsupport = await supportRepository.getAllSupport();

            // Convert domain model to DTO
            var response = getsupport.Select(support => new NewSupport
            {
                Id = support.Id,
                UserName = support.UserName,
                EmployeeId = support.EmployeeId,
                Email = support.Email,
                Department = support.Department,
                RequestType = support.RequestType,
            }).ToList();

            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupportTypeByIdAsync(Guid id)
        {
            var support = await supportRepository.GetSupportByIdAsync(id);
            if (support == null)
                return NotFound();

            var response = new CreateNewSupportDto
            {
                Id = support.Id,
                UserName = support.UserName,
                EmployeeId = support.EmployeeId,
                Email = support.Email,
                Department = support.Department,
                RequestType = support.RequestType,
               

            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateSupport([FromRoute] Guid id, CreateNewSupportDto request)
        {
            var support = new NewSupport
            {

                Id = request.Id,
                UserName = request.UserName,
                EmployeeId = request.EmployeeId,
                Email = request.Email,
                Department = request.Department,
                RequestType = request.RequestType,
               


            };

            support = await supportRepository.UpdateAsync(support);

            {
                if (support == null)
                {
                    return NotFound();

                }
                //convert domain model to dto 

                var response = new CreateNewSupportDto
                {
                    Id = support.Id,
                    UserName = support.UserName,
                    EmployeeId = support.EmployeeId,
                    Email = support.Email,
                    Department = support.Department,
                    RequestType = support.RequestType,


                };


                return Ok(response);
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteSupport([FromRoute] Guid id)
        {
            var currentSupport = await supportRepository.GetById(id);

            if (currentSupport == null)
            {
                return NotFound();
            }

            await supportRepository.DeleteAsync(id);
            return NoContent();


        }


    }

}













//cover jwt today as well













