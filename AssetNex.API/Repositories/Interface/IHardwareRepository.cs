using AssetNex.API.Models.DomainModel;

namespace AssetNex.API.Repositories.Interface
{
    public interface IHardwareRepository
    {

        Task<List<Hardware>> getAllHardware();
        Task AddHardwareAsync(Hardware hardware);
        Task<Hardware?> GetHardwareByIdAsync(Guid id);
        Task<Hardware?> GetHardwareTypeByIdAsync(Guid id);
        Task<Hardware?> GetById(Guid id);

        Task<Hardware?> UpdateAsync(Hardware hardware);

        Task<Hardware?> DeleteAsync(Guid id);

    }
}
