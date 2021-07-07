using AutoMapper;
using ClientMaster.Core.Models;
using ClientMaster.Core.Models.Dtos.CustomerDtos;
using ClientMaster.Core.Persistence;
using ClientMaster.Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientMaster.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ClientMasterContext _context;
        private readonly IMapper _mapper;

        public CustomerService(ClientMasterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ICollection<CustomerViewDto>> GetAllAsync()
        {
            var customers = await _context.Customers
                .Include(i => i.Addresses)
                .ThenInclude(i => i.Sector)
                .ThenInclude(i => i.Municipality)
                .ThenInclude(i => i.Province)
                .Where(filter => filter.Active)
                .ToListAsync();

            return _mapper.Map<ICollection<CustomerViewDto>>(customers);
        }

        public async Task<CustomerViewDto> GetByIdAsync(int id)
        {
            var customer = await _context.Customers
                .Include(i => i.Addresses)
                .ThenInclude(i => i.Sector)
                .ThenInclude(i => i.Municipality)
                .ThenInclude(i => i.Province)
                .Where(filter => filter.Active)
                .FirstOrDefaultAsync(filter => filter.Id == id);

            return _mapper.Map<CustomerViewDto>(customer);
        }

        public async Task<CustomerViewDto> AddAsync(CustomerPostDto customerPost)
        {
            var customer = _mapper.Map<CustomerPostDto, Customer>(customerPost);

            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(customer.Id);
        }

        public async Task<CustomerViewDto> UpdateAsync(CustomerUpdateDto customerUpdate)
        {
            var customer = _mapper.Map<CustomerUpdateDto, Customer>(customerUpdate);

            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(customer.Id);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(filter => filter.Id == id);

            customer.Active = false;

            _context.Customers.Update(customer);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
