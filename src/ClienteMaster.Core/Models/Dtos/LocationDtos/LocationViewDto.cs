using ClientMaster.Core.Models.Dtos.CustomerDtos;

namespace ClientMaster.Core.Models.Dtos.LocationDtos
{
    public class LocationViewDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public Sector Sector { get; set; }
        public CustomerViewDto Customer { get; set; }
    }
}
