using AssetNex.API.Models.DomainModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetNex.API.Models.DTO.Hardware
{
    public class CreateHardwareDto
    {
        public Guid Id { get; set; }    
        public required string ProblemDescription { get; set; } //problem explain

        public Guid AssetTypeId { get; set; } //number

        public required string SerialNumber { get; set; }
        public required string AssetName { get; set; }   //dell
        public required string AssetType { get; set; } //laptop
        public DateTime DateSubmitted { get; set; } = DateTime.UtcNow;

        public DateTime DateOfIssue { get; set; }

        public DateTime WarrantyDate { get; set; }


    }
}
