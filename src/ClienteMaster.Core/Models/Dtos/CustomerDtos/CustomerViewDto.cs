using ClienteMaster.Core.Framework.Enums;
using ClientMaster.Core.Models.Dtos.LocationDtos;
using System;
using System.Collections.Generic;

namespace ClientMaster.Core.Models.Dtos.CustomerDtos
{
    public class CustomerViewDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public bool Active { get; set; }
        public ICollection<LocationViewDto> Addresses { get; set; }
    }
}
