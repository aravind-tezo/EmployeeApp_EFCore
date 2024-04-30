using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Data.Entites
{
    //[Table("Roles", Schema = "ConsoleApp")]
    public class Role
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        //public ICollection<Employee> Employees { get; set; }

    }
}