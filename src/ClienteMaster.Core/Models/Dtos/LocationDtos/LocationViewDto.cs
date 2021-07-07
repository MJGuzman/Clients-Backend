namespace ClientMaster.Core.Models.Dtos.LocationDtos
{
    public class LocationViewDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public SectorDto Sector { get; set; }
    }
}
