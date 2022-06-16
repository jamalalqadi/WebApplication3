using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.Entities
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string  Name { get; set; }
        public ICollection<Employee> Employees { get; set; }


    }
}
