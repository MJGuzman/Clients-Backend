using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClientMaster.Core.Models.Dtos;
using ClientMaster.Core.Persistence;
using ClientMaster.Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClientMaster.Core.Services
{
    public class ProvinceService : IProvinceService
    {
        private readonly ClientMasterContext _context;
        private readonly IMapper _mapper;

        public ProvinceService(ClientMasterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ICollection<ProvinceDto>> GetAllAsync()
        {
            var provinces = await _context.Provinces
                .ToListAsync();

            return _mapper.Map<ICollection<ProvinceDto>>(provinces);
        }

        public async Task<ProvinceDto> GetByIdAsync(int id)
        {
            var province = await _context.Provinces
                .FirstOrDefaultAsync(filter => filter.Id == id);

            return _mapper.Map<ProvinceDto>(province);
        }
    }
}
