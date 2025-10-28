using AssetNex.API.Models.DomainModel;
using AssetNex.API.Models.DTO.EWaste;

namespace AssetNex.API.Repositories.Interface
{
    public interface IEWasteRepository
    {
        Task<List<EWaste>> GetDisposedAssets();//getall//GET
 

        Task<IEnumerable<DisposedAssetDto>> GetDisposedAssetsAsync();

        Task AddEWasteAsync(EWaste ewaste);//POST

        Task DisposeAssetAsync(DisposeAssetRequestDto request);

        Task<EWaste?> GetEWasteByIdAsync(Guid id);// for POST 

        Task<EWaste?> GetById(Guid id);

        Task<EWaste?> UpdateDisposedAssetAsync(EWaste ewaste);

        Task DeleteDisposableAssetAsync(Guid assetId);//DeleteEDisposeAssetRequestDto 

        Task<EWaste?> GetEWasteTypeByIdAsync(Guid assetTypeId);

        //Task<EWaste?> UpdateAsync(EWaste eWaste);

   

    }
}
