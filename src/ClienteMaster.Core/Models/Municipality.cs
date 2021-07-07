using System.ComponentModel.DataAnnotations;

namespace ClientMaster.Core.Models
{
    public class Municipality
    {
        [Required] public int MunicipalityId { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int ProvinceId { get; set; }
        public Province Province { get; set; }
    }
}
