using AssetNex.API.Models.DomainModel;

namespace AssetNex.API.Repositories.Interface
{
    public interface ISoftwareLicenseRepository
    {

        Task<List<SoftwareLicenseInfo>> GetAllSoftwareLicense();
        Task<IEnumerable<SoftwareLicenseInfo>> GetSoftwareLicenseAsync();
        Task<SoftwareLicenseInfo?> GetBySoftwareLicenseIdAsync(Guid id);


        Task<SoftwareLicenseInfo?> CreateAsync(SoftwareLicenseInfo license);
        Task<SoftwareLicenseInfo?> DeleteAsync(Guid id);

        Task<SoftwareLicenseInfo?> UpdateSoftwareLicenseAsync(SoftwareLicenseInfo softwareLicense);


    }
}


