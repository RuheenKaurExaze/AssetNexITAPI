using System.ComponentModel.DataAnnotations.Schema;

namespace AssetNex.API.Models.DTO.LiveTracking
{
    public class LiveLocationDto
    {

        public int Id { get; set; }
        public required string SerialNumber { get; set; }
        public Guid AssetTypeId { get; set; }
        public required string AssetType { get; set; }
        public required string status { get; set; }
        public required string Location { get; set; }
        public required string LastCheckedOut { get; set; }




    }

}


