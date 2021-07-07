using ClientMaster.Core.Models.Dtos.CustomerDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientMaster.Core.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<ICollection<CustomerViewDto>> GetAllAsync();
        Task<CustomerViewDto> GetByIdAsync(int id);
        Task<CustomerViewDto> AddAsync(CustomerPostDto customerPost);
        Task<CustomerViewDto> UpdateAsync(CustomerUpdateDto customerUpdate);
        Task<bool> RemoveAsync(int id);
    }
}
