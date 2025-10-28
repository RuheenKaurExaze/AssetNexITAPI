using AssetNex.API.Models.DomainModel;
using AssetNex.API.Models.DTO.SoftwareLicense;

namespace AssetNex.API.Repositories.Interface
{
    public interface ISoftwareLicenseRepository
    {

        Task<List<SoftwareLicenseInfo>>GetAllSoftwareLicense(); //get all


        Task<IEnumerable<SoftwareLicenseInfo>> GetSoftwareLicenseAsync();


        Task<SoftwareLicenseInfo?> GetBySoftwareLicenseIdAsync(Guid id); //by id get




        Task<SoftwareLicenseInfo?> CreateAsync(SoftwareLicenseInfo license); //post
        Task<SoftwareLicenseInfo?> DeleteAsync(Guid id); //delete

    

        Task<SoftwareLicenseInfo?> UpdateSoftwareLicenseAsync(SoftwareLicenseInfo softwareLicense); //put
      

    }
}


