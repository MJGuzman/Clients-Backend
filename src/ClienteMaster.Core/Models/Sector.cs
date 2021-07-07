using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientMaster.Core.Models
{
    public class Sector
    {
        [Required] public int SectorId { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int MunicipalityId { get; set; }
        [Required] public int ProvinceId { get; set; }
        [ForeignKey("ProvinceId,MunicipalityId")]
        public Municipality Municipality { get; set; }
    }
}
