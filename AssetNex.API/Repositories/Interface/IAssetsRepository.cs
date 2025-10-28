
using AssetNex.API.Models.DomainModel;
using AssetNex.API.Models.DTO;

namespace AssetNex.API.Repositories.Interface
{
   
      
    public interface IAssetsRepository 
    {
        Task<List<AssetInfo>> getAllAssets(); //getall

        Task AddAssetAsync(AssetInfo asset);  //post- adding new info
        Task<AssetInfo?> GetAssetByIdAsync(Guid id); //post
        Task<AssetType?> GetAssetTypeByIdAsync(Guid id); //post


        Task<AssetInfo?> GetById(Guid id); //get by id?

        Task<AssetInfo?> UpdateAsync(AssetInfo asset); //update-put

        Task<AssetInfo?> DeleteAsync(Guid id);




       
        //post= creation, getbyidasync, addassetasync, return createdataction . 

        //for steps of null, first call, null then send bad request ,
        //otherwise call dto, dto to DM, THEN DM TO dto 


    }



}
