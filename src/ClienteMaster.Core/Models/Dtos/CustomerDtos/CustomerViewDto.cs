using ClienteMaster.Core.Framework.Enums;
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
        public ICollection<Location> Adreesses { get; set; }
    }
}
