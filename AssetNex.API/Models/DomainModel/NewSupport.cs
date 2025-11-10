using System.ComponentModel.DataAnnotations;

namespace AssetNex.API.Models.DomainModel
{
    public class NewSupport
    {
        [Key]
        public Guid Id { get; set; }

        public required string UserName { get; set; }
       
        public required string Email { get; set; }

        public required string EmployeeId { get; set; }

        public required string Department { get; set; }

        public required string RequestType { get; set; }


    }
}
