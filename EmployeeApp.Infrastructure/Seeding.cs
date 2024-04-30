using EmployeeApp.Models;
namespace Infrastructure
{
    public class TestData
    {
        public List<EmployeeTest> GenerateEmployees()
        {
            List<EmployeeTest> employees = new List<EmployeeTest>
        {
             new EmployeeTest("TZ0001", "John", "Doe", new DateTime(1990, 5, 15), "john.doe@example.com", "1234567890", new DateTime(2020, 1, 1), "RL01", "PJ01", "New York", "Engineering", "John Doe"),
            new EmployeeTest("TZ0002", "Jane", "Smith", new DateTime(1988, 8, 25), "jane.smith@example.com", "9876543210", new DateTime(2019, 6, 15), "RL02", "PJ02", "Los Angeles", "Marketing", "John Doe"),
            new EmployeeTest("TZ0003", "Michael", "Johnson", new DateTime(1995, 3, 10), "michael.johnson@example.com", "4567890123", new DateTime(2020, 3, 20), "RL03", "PJ03", "Chicago", "Finance", "Michael Johnson"),
            new EmployeeTest("TZ0004", "Emily", "Brown", new DateTime(1993, 11, 5), "emily.brown@example.com", "7890123456", new DateTime(2018, 12, 10), "RL04", "PJ04", "Los Angeles", "Human Resources", "Emily Brown"),
            new EmployeeTest("TZ0005", "David", "Wilson", new DateTime(1991, 7, 15), "david@example.com", "2345678901", new DateTime(2017, 9, 5), "RL05", "PJ05", "Houston", "Customer Service", "David Wilson"),
            new EmployeeTest("TZ0006", "Sarah", "Lee", new DateTime(1991, 8, 12), "sarah@example.com", "3456789012", new DateTime(2013, 7, 20), "RL01", "PJ01", "New York", "Engineering", "Sarah Lee"),
            new EmployeeTest("TZ0007", "James", "Williams", new DateTime(1986, 4, 30), "james@example.com", "5678901234", new DateTime(2014, 10, 5), "RL02", "PJ02", "Chicago", "Marketing", "John Doe"),
            new EmployeeTest("TZ0008", "Olivia", "Taylor", new DateTime(1993, 11, 5), "olivia@example.com", "6789012345", new DateTime(2016, 3, 15), "RL03", "PJ03", "San Francisco", "Finance", "Michael Johnson"),
            new EmployeeTest("TZ0009", "Ethan", "Martinez", new DateTime(1989, 6, 22), "ethan@example.com", "8901234567", new DateTime(2019, 9, 25), "RL04", "PJ04", "Los Angeles", "Human Resources", "Emily Brown"),
            new EmployeeTest("TZ0010", "Sophia", "Garcia", new DateTime(1994, 2, 17), "sophia@example.com", "9012345678", new DateTime(2017, 12, 10), "RL05", "PJ05", "Houston", "Customer Service", "David Wilson"),
            new EmployeeTest("TZ0011", "Adam", "Brown", new DateTime(1990, 9, 18), "adam@example.com", "1234567890", new DateTime(2015, 6, 12), "RL01", "PJ01", "New York", "Engineering", "Sarah Lee"),
            new EmployeeTest("TZ0012", "Grace", "Clark", new DateTime(1987, 7, 25), "grace@example.com", "9876543210", new DateTime(2012, 8, 20), "RL02", "PJ02", "Houston", "Marketing", "John Doe"),
            new EmployeeTest("TZ0013", "Ryan", "Gonzalez", new DateTime(1993, 11, 30), "ryan@example.com", "4567890123", new DateTime(2018, 5, 15), "RL03", "PJ03", "San Francisco", "Finance", "Michael Johnson"),
            new EmployeeTest("TZ0014", "Emma", "Hill", new DateTime(1985, 5, 10), "emma@example.com", "7890123456", new DateTime(2010, 10, 5), "RL04", "PJ04", "Los Angeles", "Human Resources", "Emily Brown"),
            new EmployeeTest("TZ0015", "Liam", "Allen", new DateTime(1991, 3, 8), "liam@example.com", "2345678901", new DateTime(2013, 12, 28), "RL05", "PJ05", "Houston", "Customer Service", "David Wilson"),
            new EmployeeTest("TZ0016", "Isabella", "Thompson", new DateTime(1987, 12, 10), "isabella@example.com", "6789012345", new DateTime(2014, 2, 15), "RL01", "PJ01", "Chicago", "Engineering", "Grace Clark"),
            new EmployeeTest("TZ0017", "Mason", "Clark", new DateTime(1991, 5, 18), "mason@example.com", "7890123456", new DateTime(2015, 8, 20), "RL02", "PJ02", "Chicago", "Marketing", "Grace Clark"),
            new EmployeeTest("TZ0018", "Evelyn", "Lewis", new DateTime(1989, 9, 22), "evelyn@example.com", "8901234567", new DateTime(2016, 6, 25), "RL03", "PJ03", "New York", "Finance", "Michael Johnson"),
            new EmployeeTest("TZ0019", "Lucas", "Walker", new DateTime(1993, 2, 5), "lucas@example.com", "9012345678", new DateTime(2017, 4, 30), "RL04", "PJ04", "San Francisco", "Human Resources", "Emily Brown"),
            new EmployeeTest("TZ0020", "Harper", "Roberts", new DateTime(1990, 11, 15), "harper@example.com", "0123456789", new DateTime(2018, 10, 10), "RL05", "PJ05", "San Francisco", "Customer Service","Grace Clark")


        };
            return employees;
        }
        public Dictionary<string, EmployeeTest> GenarateEmployeeDict()
        {
            List<EmployeeTest> employees = GenerateEmployees();
            Dictionary<string, EmployeeTest> empDict = [];
            foreach (EmployeeTest emp in employees)
            {
                empDict.Add(emp.Id, emp);
            }
            return empDict;

        }
        public List<RoleTest> GenarateRoles()
        {
            // Generate 5 roles
            List<RoleTest> roles = new List<RoleTest>
        {
            new RoleTest("RL01", "Software Developer", "Engineering", "Developing software applications", "New York"),
            new RoleTest("RL02", "Marketing Manager", "Marketing", "Creating marketing strategies", "San Francisco"),
            new RoleTest("RL03", "Financial Analyst", "Finance", "Analyzing financial data", "Chicago"),
            new RoleTest("RL04", "Human Resources Specialist", "Human Resources", "Managing employee relations", "Los Angeles"),
            new RoleTest("RL05", "Customer Support Representative", "Customer Service", "Assisting customers with inquiries", "Houston")
            // Add more roles as needed
        };
            return roles;
        }
        // public Dictionary<String, RoleTest> GenarateRoleDict()
        // {
        //     List<RoleTest> roles = GenarateRoles();
        //     Dictionary<string, RoleTest> roleDict = [];
        //     foreach (RoleTest role in roles)
        //     {
        //         roleDict.Add(role.Id, role);
        //     }
        //     return roleDict;
        // }

    }
}

/*
 new EmployeeTest("TZ0001", "John", "Doe", new DateTime(1990, 5, 15), "john.doe@example.com", "1234567890", new DateTime(2020, 1, 1), "RL01", "PJ01", "New York", "Engineering", TZ0001),
    new EmployeeTest("TZ0002", "Jane", "Smith", new DateTime(1988, 8, 25), "jane.smith@example.com", "9876543210", new DateTime(2019, 6, 15), "RL02", "PJ02", "Los Angeles", "Marketing", "TZ0012"), 
    new EmployeeTest("TZ0003", "Michael", "Johnson", new DateTime(1995, 3, 10), "michael.johnson@example.com", "4567890123", new DateTime(2020, 3, 20), "RL03", "PJ03", "Chicago", "Finance", "TZ0003"),
    new EmployeeTest("TZ0004", "Emily", "Brown", new DateTime(1993, 11, 5), "emily.brown@example.com", "7890123456", new DateTime(2018, 12, 10), "RL04", "PJ04", "Los Angeles", "Human Resources", "TZ0018"), 
    new EmployeeTest("TZ0005", "David", "Wilson", new DateTime(1991, 7, 15), "david@example.com", "2345678901", new DateTime(2017, 9, 5), "RL05", "PJ05", "Houston", "Customer Service", "TZ0015"), 
    new EmployeeTest("TZ0006", "Sarah", "Lee", new DateTime(1991, 8, 12), "sarah@example.com", "3456789012", new DateTime(2013, 7, 20), "RL01", "PJ01", "New York", "Engineering", "TZ0007"), 
    new EmployeeTest("TZ0007", "James", "Williams", new DateTime(1986, 4, 30), "james@example.com", "5678901234", new DateTime(2014, 10, 5), "RL02", "PJ02", "Chicago", "Marketing", TZ0001), 
    new EmployeeTest("TZ0008", "Olivia", "Taylor", new DateTime(1993, 11, 5), "olivia@example.com", "6789012345", new DateTime(2016, 3, 15), "RL03", "PJ03", "San Francisco", "Finance", "TZ0003"), 
    new EmployeeTest("TZ0009", "Ethan", "Martinez", new DateTime(1989, 6, 22), "ethan@example.com", "8901234567", new DateTime(2019, 9, 25), "RL04", "PJ04", "Los Angeles", "Human Resources", "TZ0018"), 
    new EmployeeTest("TZ0010", "Sophia", "Garcia", new DateTime(1994, 2, 17), "sophia@example.com", "9012345678", new DateTime(2017, 12, 10), "RL05", "PJ05", "Houston", "Customer Service", "TZ0015"), 
    new EmployeeTest("TZ0011", "Adam", "Brown", new DateTime(1990, 9, 18), "adam@example.com", "1234567890", new DateTime(2015, 6, 12), "RL01", "PJ01", "New York", "Engineering", "TZ0007"), 
    new EmployeeTest("TZ0012", "Grace", "Clark", new DateTime(1987, 7, 25), "grace@example.com", "9876543210", new DateTime(2012, 8, 20), "RL02", "PJ02", "Houston", "Marketing", TZ0001), 
    new EmployeeTest("TZ0013", "Ryan", "Gonzalez", new DateTime(1993, 11, 30), "ryan@example.com", "4567890123", new DateTime(2018, 5, 15), "RL03", "PJ03", "San Francisco", "Finance", "TZ0003"), 
    new EmployeeTest("TZ0014", "Emma", "Hill", new DateTime(1985, 5, 10), "emma@example.com", "7890123456", new DateTime(2010, 10, 5), "RL04", "PJ04", "Los Angeles", "Human Resources", "TZ0018"),
    new EmployeeTest("TZ0015", "Liam", "Allen", new DateTime(1991, 3, 8), "liam@example.com", "2345678901", new DateTime(2013, 12, 28), "RL05", "PJ05", "Houston", "Customer Service", TZ0001),
    new EmployeeTest("TZ0016", "Isabella", "Thompson", new DateTime(1987, 12, 10), "isabella@example.com", "6789012345", new DateTime(2014, 2, 15), "RL01", "PJ01", "Chicago", "Engineering", "TZ0012"),
    new EmployeeTest("TZ0017", "Mason", "Clark", new DateTime(1991, 5, 18), "mason@example.com", "7890123456", new DateTime(2015, 8, 20), "RL02", "PJ02", "Chicago", "Marketing", "TZ0012"), 
    new EmployeeTest("TZ0018", "Evelyn", "Lewis", new DateTime(1989, 9, 22), "evelyn@example.com", "8901234567", new DateTime(2016, 6, 25), "RL03", "PJ03", "New York", "Finance", TZ0001), 
    new EmployeeTest("TZ0019", "Lucas", "Walker", new DateTime(1993, 2, 5), "lucas@example.com", "9012345678", new DateTime(2017, 4, 30), "RL04", "PJ04", "San Francisco", "Human Resources", "TZ0018"),
    new EmployeeTest("TZ0020", "Harper", "Roberts", new DateTime(1990, 11, 15), "harper@example.com", "0123456789", new DateTime(2018, 10, 10), "RL05", "PJ05", "San Francisco", "Customer Service","TZ0012")

*/