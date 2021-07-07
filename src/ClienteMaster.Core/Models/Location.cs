using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientMaster.Core.Models
{
    public class Location
    {
        [Key] public int Id { get; set; }
        [Required] public string Address { get; set; }
        [Required] public int ProvinceId { get; set; }
        [Required] public int MunicipalityId { get; set; }
        [Required] public int SectorId { get; set; }
        [ForeignKey("ProvinceId, MunicipalityId, SectorId ")]
        public Sector Sector { get; set; }
        //[Required] public int CustomerId { get; set; }
        //public Customer Customer { get; set; }
    }
}
