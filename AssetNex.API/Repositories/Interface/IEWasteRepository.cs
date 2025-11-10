using AssetNex.API.Models.DomainModel;
using AssetNex.API.Models.DTO.EWaste;

namespace AssetNex.API.Repositories.Interface
{
    public interface IEWasteRepository
    {
        Task<List<EWaste>> GetDisposedAssets();


        Task<IEnumerable<DisposedAssetDto>> GetDisposedAssetsAsync();

        Task AddEWasteAsync(EWaste ewaste);

        Task DisposeAssetAsync(DisposeAssetRequestDto request);

        Task<EWaste?> GetEWasteByIdAsync(Guid id);

        Task<EWaste?> GetById(Guid id);

        Task<EWaste?> UpdateDisposedAssetAsync(EWaste ewaste);

        Task DeleteDisposableAssetAsync(Guid assetId);

        Task<EWaste?> GetEWasteTypeByIdAsync(Guid assetTypeId);





    }
}
