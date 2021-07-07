using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientMaster.Core.Models.Dtos;

namespace ClientMaster.Core.Services.Interfaces
{
    public interface ISectorService
    {
        Task<ICollection<SectorDto>> GetAllAsync(int provinceId, int municipalityId);
        Task<SectorDto> GetByIdAsync(int provinceId, int municipalityId, int id);
    }
}
