using AssetNex.API.Models.DomainModel;

namespace AssetNex.API.Repositories.Interface
{


    public interface IAssetsRepository
    {
        Task<List<AssetInfo>> getAllAssets();

        Task AddAssetAsync(AssetInfo asset);
        Task<AssetInfo?> GetAssetByIdAsync(Guid id);
        Task<AssetType?> GetAssetTypeByIdAsync(Guid id);
        Task<AssetInfo?> GetById(Guid id);
        Task<AssetInfo?> UpdateAsync(AssetInfo asset);
        Task<AssetInfo?> DeleteAsync(Guid id);


    }



}
