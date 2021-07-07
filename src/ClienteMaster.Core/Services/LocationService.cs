using AutoMapper;
using ClientMaster.Core.Models;
using ClientMaster.Core.Models.Dtos.LocationDtos;
using ClientMaster.Core.Persistence;
using ClientMaster.Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ClientMaster.Core.Services
{
    public class LocationService : ILocationService
    {
        private readonly ClientMasterContext _context;
        private readonly IMapper _mapper;

        public LocationService(ClientMasterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<LocationViewDto> GetAllAsync(int customerId)
        {
            var locations = await _context.Locations

                .ToListAsync();

            return _mapper.Map<LocationViewDto>(locations);
        }

        public async Task<LocationViewDto> GetByIdAsync(int id)
        {
            var location = await _context.Locations
                .FirstOrDefaultAsync(filter => filter.Id == id);

            return _mapper.Map<LocationViewDto>(location);
        }

        public async Task<LocationViewDto> AddAsync(LocationPostDto locationPost)
        {
            var location = _mapper.Map<LocationPostDto, Location>(locationPost);

            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(location.Id);
        }

        public async Task<LocationViewDto> UpdateAsync(LocationUpdateDto locationUpdate)
        {
            var location = _mapper.Map<LocationUpdateDto, Location>(locationUpdate);

            _context.Locations.Update(location);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(location.Id);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var location = await _context.Locations
                .FirstOrDefaultAsync(filter => filter.Id == id);

            _context.Locations.Remove(location);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
