using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.Entities
{
    public class PersonalData
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string ImgUrl { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }


    }
}
