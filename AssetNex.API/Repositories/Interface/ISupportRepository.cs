using AssetNex.API.Models.DomainModel;

namespace AssetNex.API.Repositories.Interface
{
    public interface ISupportRepository
    {
        Task<NewSupport?> GetSupportByIdAsync(Guid id);// getbyid
        Task<NewSupport?> GetSupportTypeByIdAsync(Guid id); //getbyid

        Task<NewSupport?> CreateAsync( NewSupport support);//post

        Task<List<NewSupport>> getAllSupport(); //getall

        Task<NewSupport?> UpdateAsync( NewSupport support); //put

        Task<NewSupport?> GetById(Guid id);//delete
        Task<NewSupport?> DeleteAsync(Guid id); //delete

    }
}
