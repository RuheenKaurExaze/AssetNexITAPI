

namespace AssetNex.API.Models.DomainModel
{
    public class User
    {

        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }

        public required string Name { get; set; }
        public required string Email { get; set; }

        public required string Contact { get; set; }

        public required string Department { get; set; }

    }
}
