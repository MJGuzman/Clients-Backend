using ClientMaster.Core.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientMaster.Core.Services.Interfaces
{
    public interface IProvinceService
    {
        Task<ICollection<ProvinceDto>> GetAllAsync();
        Task<ProvinceDto> GetByIdAsync(int id);
    }
}
