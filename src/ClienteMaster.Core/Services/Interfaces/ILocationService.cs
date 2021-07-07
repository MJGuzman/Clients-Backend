using ClientMaster.Core.Models.Dtos.LocationDtos;
using System.Threading.Tasks;

namespace ClientMaster.Core.Services.Interfaces
{
    public interface ILocationService
    {
        Task<LocationViewDto> GetAllAsync(int userId);
        Task<LocationViewDto> GetByIdAsync(int id);
        Task<LocationViewDto> AddAsync(LocationPostDto locationPost);
        Task<LocationViewDto> UpdateAsync(LocationUpdateDto locationUpdate);
        Task<bool> RemoveAsync(int id);
    }
}
