using System;
using System.Collections.Generic;

namespace UserServices.Models
{
    public partial class TblUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}
