using ClientMaster.Core.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientMaster.Core.Services.Interfaces
{
    public interface IMunicipalityService
    {
        Task<ICollection<MunicipalityDto>> GetAllAsync(int provinceId);
        Task<MunicipalityDto> GetByIdAsync(int provinceId, int id);
    }
}
