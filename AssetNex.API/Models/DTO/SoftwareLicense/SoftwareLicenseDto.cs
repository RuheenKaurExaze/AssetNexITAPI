
namespace AssetNex.API.Models.DTO.SoftwareLicense
{
    public class SoftwareLicenseDto
    {
        public Guid Id { get; set; }

        public required string UserName { get; set; }

        public required string Request { get; set; }

        public required string EmployeeId { get; set; }

        public required string SoftwareName { get; set; }


        public required string? OtherSoftware { get; set; }


        public DateTime DateApplied { get; set; }

    }
}
