using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        [Remote(action: "EmployeeExists", controller: "Employee")]
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime HireDate { get; set; }
        public double Salary { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        [Display(Name="City")]
        public int CityId { get; set; }
        public City City { get; set; }
        [Display(Name = "Job")]
        public int JobId { get; set; }
        public Job Job { get; set; }

        public PersonalData PersonalData { get; set; }
        public ICollection<EmpRole> EmpRoles { get; set; }



    }
}
