namespace ClientMaster.Core.Models.Dtos
{
    public class MunicipalityDto
    {
        public int MunicipalityId { get; set; }
        public string Name { get; set; }
        public ProvinceDto Province { get; set; }
    }
}
