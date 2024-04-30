using System.ComponentModel.DataAnnotations;
namespace EmployeeApp.Models
{
 public class RoleView
    {
        public string Id { get; set; }
        [StringLength(50,MinimumLength = 10)]
        public string Name { get; set; }
        [MinLength(10)]
        public string Department { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        
    }
}