namespace ClientMaster.Core.Models.Dtos
{
    public class SectorDto
    {
        public int SectorId { get; set; }
        public string Name { get; set; }
        public MunicipalityDto Municipality { get; set; }
    }
}
