
namespace EmployeeApp.Presentation
{
    public class Mainmenu : IMainmenu
    {
        private IEmployeeManager _employeeManager;
        private IRoleManager _roleManager;
        public Mainmenu(IEmployeeManager employeeManager, IRoleManager roleManager)
        {
            _employeeManager = employeeManager;
            _roleManager = roleManager;
        }
        public async Task EntryAsync()
        {
            Console.WriteLine("Welcome to Employee Application\n");
            int operationChoice = 1;
            while (operationChoice > 0)
            {
                Console.WriteLine("Choose your Operations\n1.Employee Management\t2.Role Management\t0.Exit");
                operationChoice = int.Parse(Console.ReadLine() ?? "0");
                switch (operationChoice)
                {
                    case 1:
                        await EmployeeOperationsAsync();
                        break;
                    case 2:
                        await RoleOperationsAsync();
                        break;
                    case 0:
                        Console.WriteLine("Operations Completed... Closing");
                        break;
                }
            }

        }
        public async Task EmployeeOperationsAsync()
        {
            int operationChoice = -1;
            while (operationChoice != 0)
            {
                Console.WriteLine("Enter your choice for EmployeeApplication");
                Console.WriteLine("1.Display All\t2.Add Employee\t3.Edit Employee\t4.SearchBy Letter\t5.Sort\t6.Delete Employee\t7.ExportToCSV\t8.Display One\t0.Back");
                operationChoice = int.Parse(Console.ReadLine() ?? "0");
                switch (operationChoice)
                {
                    case 1:
                        await _employeeManager.ViewEmployeesAsync();
                        break;
                    case 2:
                        await _employeeManager.CreateEmployeeAsync();
                        break;
                    case 3:
                        await _employeeManager.editEmployeeAsync();
                        break;
                    case 4:
                        await _employeeManager.SearchByLetterAsync();
                        break;
                    case 5:
                        await _employeeManager.SortEmployeesAsync();
                        break;
                    case 6:
                        await _employeeManager.DeleteEmployeeAsync();
                        break;
                    case 7:
                        await _employeeManager.ExportEmployeeToCsvAsync();
                        break;
                    case 8:
                        await _employeeManager.ViewSingleEmployeeAsync();
                        break;
                    case 0:
                        break;
                }
            }
        }
        public async Task RoleOperationsAsync()
        {
            int operationChoice = -1;
            Console.WriteLine("Enter your choice for RoleApplication");
            while (operationChoice != 0)
            {
                Console.WriteLine("1.View\t2.Create\t3.Delete\t4.Show Employees\t5.Edit\t6.Assign Employees\t0.Back");
                operationChoice = int.Parse(Console.ReadLine() ?? "");
                switch (operationChoice)
                {
                    case 1:
                        await _roleManager.ViewRolesAsync();
                        break;
                    case 2:
                        await _roleManager.CreateRoleAsync();
                        break;
                    case 3:
                        await _roleManager.DeleteRoleAsync();
                        break;
                    case 4:
                        await _roleManager.ShowRoleEmployeesAsync();
                        break;
                    case 5:
                        await _roleManager.EditRoleAsync();
                        break;
                    case 6:
                        await _roleManager.AssignEmployeesAsync();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Invalid Operation");
                        break;

                }
            }
        }

    }
}