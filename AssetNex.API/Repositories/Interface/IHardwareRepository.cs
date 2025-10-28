using AssetNex.API.Models;
using AssetNex.API.Models.DomainModel;

namespace AssetNex.API.Repositories.Interface
{
    public interface IHardwareRepository
    {

        Task<List<Hardware>> getAllHardware(); //getall

        Task AddHardwareAsync(Hardware hardware);  //post- adding new info
        Task<Hardware?> GetHardwareByIdAsync(Guid id); //post
        Task<Hardware?> GetHardwareTypeByIdAsync(Guid id); //post


        Task<Hardware?> GetById(Guid id); //get by id?

        Task<Hardware?> UpdateAsync(Hardware hardware); //update-put

        Task<Hardware?> DeleteAsync(Guid id);

    }
}
