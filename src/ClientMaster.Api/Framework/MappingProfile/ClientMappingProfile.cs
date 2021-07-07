using AutoMapper;
using ClientMaster.Core.Models;
using ClientMaster.Core.Models.Dtos;
using ClientMaster.Core.Models.Dtos.CustomerDtos;
using ClientMaster.Core.Models.Dtos.LocationDtos;

namespace ClientMaster.Api.Framework.MappingProfile
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            #region Customer

            CreateMap<Customer, CustomerViewDto>();

            CreateMap<CustomerPostDto, Customer>();

            CreateMap<CustomerUpdateDto, Customer>();


            #endregion

            #region Location

            CreateMap<Location, LocationViewDto>();

            CreateMap<LocationPostDto, Location>();

            CreateMap<LocationUpdateDto, Location>();

            #endregion

            #region Address

            CreateMap<Sector, SectorDto>();

            CreateMap<Municipality, MunicipalityDto>();

            CreateMap<Province, ProvinceDto>();

            #endregion


        }
    }
}
