using AutoMapper;
using ClientMaster.Core.Models.Dtos;
using ClientMaster.Core.Persistence;
using ClientMaster.Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientMaster.Core.Services
{
    public class SectorService : ISectorService
    {
        private readonly ClientMasterContext _context;
        private readonly IMapper _mapper;

        public SectorService(ClientMasterContext client, IMapper mapper)
        {
            _context = client;
            _mapper = mapper;
        }
        public async Task<ICollection<SectorDto>> GetAllAsync(int provinceId, int municipalityId)
        {
            var serctors = await _context.Sectors
                .Where(filter => filter.ProvinceId == provinceId && filter.MunicipalityId == municipalityId)
                .ToListAsync();

            return _mapper.Map<ICollection<SectorDto>>(serctors);
        }

        public async Task<SectorDto> GetByIdAsync(int provinceId, int municipalityId, int id)
        {
            var serctor = await _context.Sectors
                .Where(filter => filter.ProvinceId == provinceId && filter.MunicipalityId == municipalityId)
                .FirstOrDefaultAsync(filter => filter.SectorId == id);

            return _mapper.Map<SectorDto>(serctor);
        }
    }
}
