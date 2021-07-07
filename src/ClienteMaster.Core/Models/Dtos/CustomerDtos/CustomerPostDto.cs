using ClienteMaster.Core.Framework.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ClientMaster.Core.Models.Dtos.CustomerDtos
{
    public class CustomerPostDto
    {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Email { get; set; }
        [Required] public Gender Gender { get; set; }
        [Required] public DateTime Birthday { get; set; }
    }
}
