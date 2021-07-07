using ClienteMaster.Core.Framework.Enums;
using ClientMaster.Core.Models.Dtos.LocationDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientMaster.Core.Models.Dtos.CustomerDtos
{
    public class CustomerUpdateDto
    {
        [Required] public int Id { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Email { get; set; }
        [Required] public Gender Gender { get; set; }
        [Required] public DateTime Birthday { get; set; }
        [Required] public ICollection<LocationUpdateDto> Addresses { get; set; }
    }
}
