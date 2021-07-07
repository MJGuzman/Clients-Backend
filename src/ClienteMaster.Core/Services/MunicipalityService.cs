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
    public class MunicipalityService : IMunicipalityService
    {
        private readonly ClientMasterContext _context;
        private readonly IMapper _mapper;

        public MunicipalityService(ClientMasterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ICollection<MunicipalityDto>> GetAllAsync(int provinceId)
        {
            var municipalities = await _context.Municipalities
                .Where(filter => filter.ProvinceId == provinceId)
                .ToListAsync();

            return _mapper.Map<ICollection<MunicipalityDto>>(municipalities);
        }

        public async Task<MunicipalityDto> GetByIdAsync(int provinceId, int id)
        {
            var municipality = await _context.Municipalities
                .Include(i => i.Province)
                .Where(filter => filter.ProvinceId == provinceId)
                .FirstOrDefaultAsync(filter => filter.MunicipalityId == id);

            return _mapper.Map<MunicipalityDto>(municipality);
        }
    }
}
