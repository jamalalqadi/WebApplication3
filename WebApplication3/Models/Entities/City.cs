using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.Entities
{
    public class City
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Remote(action: "CityExists", controller: "City")]
        public string  Name { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}
