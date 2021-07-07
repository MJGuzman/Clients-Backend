using ClienteMaster.Core.Framework.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientMaster.Core.Models
{
    public class Customer
    {
        [Key] public int Id { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Email { get; set; }
        [Required] public Gender Gender { get; set; }
        [Required] public DateTime Birthday { get; set; }
        public ICollection<Location> Adreesses { get; set; }
    }
}
