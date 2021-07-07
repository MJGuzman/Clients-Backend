using ClientMaster.Core.Models.Dtos.CustomerDtos;
using System.Threading.Tasks;

namespace ClientMaster.Core.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerViewDto> GetAllAsync();
        Task<CustomerViewDto> GetByIdAsync(int id);
        Task<CustomerViewDto> AddAsync(CustomerPostDto customerPost);
        Task<CustomerViewDto> UpdateAsync(CustomerUpdateDto customerUpdate);
        Task<bool> RemoveAsync(int id);
    }
}
