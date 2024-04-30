namespace EmployeeApp.Models
{
    public class EmployeeTest  // Implement the interface
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? EmailId { get; set; }
        public string? MobileNo { get; set; }
        public string? RoleName { get; set; }
        public string? ProjectName { get; set; }
        public string? ManagerName { get; set; }
        public string? Location { get; set; }
        public string? Department { get; set; }
        public DateTime? DateOfJoining { get; set; }

        public EmployeeTest()  // Default constructor
        {
            // No arguments; useful for object initialization without initial values
        }

        public EmployeeTest(string id, string firstName, string lastName, DateTime? dateOfBirth,
                           string emailId, string mobileNo, DateTime? dateOfJoining, string roleName, string projectName, string location, string department,string managerName)
        {
            // Constructor with all properties as parameters
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.EmailId = emailId;
            this.MobileNo = mobileNo;
            this.RoleName = roleName;
            this.ProjectName = projectName;
            this.ManagerName = managerName;
            this.Location = location;
            this.Department = department;
            this.DateOfJoining = dateOfJoining;
        }
    }


}
