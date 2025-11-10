namespace AssetNex.API.Models.DTO.NewSupport
{
    public class CreateNewSupportDto
    {
        public Guid Id { get; set; }
        public required string UserName { get; set; }
        public required string EmployeeId { get; set; }
        public required string Email { get; set; }

        public required string Department { get; set; }

        public required string RequestType { get; set; }


    }
}
