using AssetNex.API.Models.DomainModel;
using AssetNex.API.Models.DTO.LiveTracking;

namespace AssetNex.API.Repositories.Interface
{
    public interface ILocationRepository
    {
        Task<IEnumerable<LiveLocation>> GetAllLocationAsync();
        Task<IEnumerable<AssetLocations>> GetAssetLocationAsync();
        Task AddLocationAsync(LiveLocation location);

        Task AddAssetLocationAsync(AssetLocations location);

        Task<LiveLocation?> GetLocationByIdAsync(int Id);

        Task<LiveLocation?> GetById(int Id);

        Task<AssetLocations?> GetByLocationId(int Id);


        Task<LiveLocation?> UpdateAsync(LiveLocation location);
        Task AddAssetLocationAsync(AssetLocationDto asset);
    }
}
