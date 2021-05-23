using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeModels
{
    public class Department
    {
        [Key]
        public int DepID { get; set; }
        public string DepName { get; set; }
    }
}
