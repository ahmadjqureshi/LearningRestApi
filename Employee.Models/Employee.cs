using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeModels
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        public Gender EmpGender { get; set; }

        public int DepID { get; set; }
        public string Designation { get; set; }
        public string ImagePath { get; set; }
        
    }
}
