using System.ComponentModel.DataAnnotations;

namespace ClientMaster.Core.Models.Dtos.LocationDtos
{
    public class LocationUpdateDto
    {
        [Required] public int Id { get; set; }
        [Required] public string Address { get; set; }
        [Required] public int ProvinceId { get; set; }
        [Required] public int MunicipalityId { get; set; }
        [Required] public int SectorId { get; set; }
        [Required] public int CustomerId { get; set; }
    }
}
