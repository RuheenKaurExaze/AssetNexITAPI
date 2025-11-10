using AssetNex.API.Models.DomainModel;

namespace AssetNex.API.Repositories.Interface
{
    public interface ISupportRepository
    {
        Task<NewSupport?> GetSupportByIdAsync(Guid id);
        Task<NewSupport?> GetSupportTypeByIdAsync(Guid id);

        Task<NewSupport?> CreateAsync(NewSupport support);

        Task<List<NewSupport>> getAllSupport();

        Task<NewSupport?> UpdateAsync(NewSupport support);
        Task<NewSupport?> GetById(Guid id);
        Task<NewSupport?> DeleteAsync(Guid id);

    }
}
