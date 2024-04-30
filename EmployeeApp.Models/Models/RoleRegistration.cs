using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public class RoleRegistration
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

    }
}
