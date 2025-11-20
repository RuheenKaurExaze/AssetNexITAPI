namespace AssetNex.API.Models.DomainModel
{
    public class Assign
    {

        public Guid Id { get; set; }
        public Guid AssetId { get; set; }
        public required AssetInfo AssetInfo { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Status { get; set; }





    }
}
