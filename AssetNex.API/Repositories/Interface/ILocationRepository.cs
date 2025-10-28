using System.Collections;
using System.Threading.Tasks;
using AssetNex.API.Models;
using AssetNex.API.Models.DomainModel;
using AssetNex.API.Models.DTO.LiveTracking;

namespace AssetNex.API.Repositories.Interface
{
    public interface ILocationRepository
    {
        Task<IEnumerable<LiveLocation>> GetAllLocationAsync();
        Task<IEnumerable<AssetLocations>> GetAssetLocationAsync();
        Task AddLocationAsync(LiveLocation location);
        Task AddAssetLocationAsync (AssetLocations location);   
        Task AddAssetLocationAsync(AssetLocationDto location);  //post- adding new info
        Task<LiveLocation?> GetLocationByIdAsync(int Id); //post
       
        Task<LiveLocation?> GetById(int Id); //get by id?

        Task<AssetLocations?> GetByLocationId(int Id);


        Task<LiveLocation?> UpdateAsync(LiveLocation location); //update-put


    }
}
