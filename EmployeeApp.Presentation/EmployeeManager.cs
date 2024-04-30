using EmployeeApp.Infrastructure;
using EmployeeApp.Services;
using EmployeeApp.Models;
using Infrastructure;

namespace EmployeeApp.Presentation
{
    public class EmployeeManager:IEmployeeManager
    {
        private IValidation _validate;
        private IEmployeeServices _empService;
        private IRoleServices _roleService;
        public EmployeeManager(IValidation validatation,IEmployeeServices employeeServices,IRoleServices roleServices)
        {
          _validate=validatation;
          _empService=employeeServices;
          _roleService=roleServices;
        }

        public  async Task CreateEmployeeAsync()
        {
            Console.WriteLine("\n-------Creating new EmployeeView-----------\n");
            Console.WriteLine("Enter EmployeeView ID:");
            EmployeeRegistration newEmployee=new EmployeeRegistration();
                Console.WriteLine("Enter First Name:");
                string firstName = Console.ReadLine() ?? "";
                if (!_validate.ValidateName(firstName))
                {
                    firstName = ReTakeData(1);
                    if (!_validate.ValidateName(firstName))
                    {
                        return;
                    }
                }
                Console.WriteLine("Enter Last Name:");
                string lastName = Console.ReadLine() ?? "";
                if (!_validate.ValidateName(lastName))
                {
                    lastName = ReTakeData(1);
                    if (!_validate.ValidateName(lastName))
                    {
                        return;
                    }
                }
                Console.WriteLine("Enter Date of Birth (YYYY-MM-DD) (optional):");
                DateTime? dateOfBirth = _validate.ValidateDate(Console.ReadLine());
                Console.WriteLine("Enter Email ID:");
                string emailId = Console.ReadLine() ?? "__Empty";
                if (!_validate.ValidateEmail(emailId))
                {
                    emailId = ReTakeData(4);
                    if (!_validate.ValidateEmail(emailId))
                    {
                        return;
                    }
                }
                Console.WriteLine("Enter Mobile Number:");
                string mobileNo = Console.ReadLine() ?? "__Empty";
                if (!_validate.ValidateMobileNo(mobileNo))
                {
                    mobileNo = "Invalid Change Later";
                }
                Console.WriteLine("Enter Department");
                 string department=Console.ReadLine()??"";
                if (!_validate.ValidateName(department))
                {
                    department = ReTakeData(1);
                    if (!_validate.ValidateName(department))
                    {
                        return;
                    }
                }
                Console.WriteLine("Enter Location");
                string location=Console.ReadLine()??"";
                if (!_validate.ValidateName(location))
                {
                    location= ReTakeData(1);
                    if (!_validate.ValidateName(location))
                    {
                        return;
                    }
                }
                Console.WriteLine("Assign Role\n Enter RoleID:");
                foreach (var temp in await  _roleService.getAllRolesAsync())
                {
                    Console.WriteLine($"{temp.Id} : {temp.Name}");
                }
                string role = Console.ReadLine() ?? "__Empty";
                if (!_validate.ValidateRoleId(role))
                {
                    role= ReTakeData(3);
                    if (!_validate.ValidateRoleId(role))
                    {
                        return;
                    }
                }
                Console.WriteLine("Assign Project\tEnter ProjectName:");
                string project = Console.ReadLine() ?? "__Empty";
                Console.WriteLine("Assign Project\tEnter ManagerName:");
                string managerName = Console.ReadLine() ?? "__Empty";
                if(!_validate.ValidateName(managerName)){
                    managerName= ReTakeData(1);
                    if (!_validate.ValidateName(managerName))
                    {
                        return;
                    }
                }
                newEmployee.FirstName=firstName;
                newEmployee.LastName=lastName;
                newEmployee.DateOfBirth=dateOfBirth;
                newEmployee.EmailId=emailId;
                newEmployee.MobileNo=mobileNo;
                newEmployee.RoleName=role;
                newEmployee.ProjectName=project;
                newEmployee.Location=location;
                newEmployee.Department=department;
                newEmployee.ManagerName=managerName;
                 _empService.InsertAsync(newEmployee);
            }
        public  async Task DeleteEmployeeAsync()
        {
            Console.WriteLine("Enter ID to delete");
            string idToDelete = Console.ReadLine() ?? "";
            if (idToDelete.Length == 0)
            {
                Console.WriteLine("Invalid Input");
            }
            else if (! await _empService.CheckIdAsync(idToDelete))
            {
                Console.WriteLine("EmployeeView do not exist");
            }
            else{
                 _empService.DeleteAsync(idToDelete);
            }
        }
        public  async Task SearchByLetterAsync()
        {
            Console.WriteLine("Enter Letter to search");
            char letterToSearch = char.Parse(Console.ReadLine() ?? "-");
            if (char.IsLetter(letterToSearch))
            {
                var matchingEmployees =await _empService.SearchByLetterAsync(letterToSearch);
                 ViewEmployeesAsync(matchingEmployees);
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }
        public async Task ViewEmployeesAsync(List<EmployeeView> employees)
        {
            const int idLength = 12;  // EmployeeView ID
            const int nameLength = 17; // FirstName + LastName
            const int emailLength = 19;  // Email ID
            const int phoneLength = 15;  // Phone Number
            const int locationLength = 10; // Location
            const int departmentLength = 14; // Department
            const int roleLength = 14;   // Role
            const int projectLength = 10;  // Project
            const int managerNameLength = 12; // FirstName + LastName

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"| {"Employee ID",-idLength}| {" Name ",-nameLength} | {" Email ID ",-emailLength} | {" Phone Number ",-phoneLength} | {" Location ",-locationLength} | {" Department ",-departmentLength} | {" Role ",-roleLength} | {" Project ",-projectLength} | {" Manager ",-managerNameLength} |");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------");

            foreach (var emp in employees)
            {
                string roleName = emp.RoleName??"";
                string fullName = $"{emp.FirstName} {emp.LastName}";
                string fullNameSubstring=fullName.Substring(0, Math.Min(fullName.Length, nameLength));
                string project = emp.ProjectName??"";
                string managerName = emp.ManagerName??"";
                string emailSubstring = (emp.EmailId??"").Substring(0, Math.Min((emp.EmailId??"").Length, emailLength));
                string phoneSubstring = (emp.MobileNo??"").Substring(0, Math.Min((emp.MobileNo??"").Length, phoneLength));
                string locationSubstring = (emp.Location??"").Substring(0, Math.Min((emp.Location??"").Length, locationLength));
                string departmentSubstring = (emp.Department??"").Substring(0, Math.Min((emp.Department??"").Length, departmentLength));
                string roleSubstring = roleName.Substring(0, Math.Min(roleName.Length, roleLength));
                string projectSubstring = project.Substring(0, Math.Min(project.Length, projectLength));
                string managerSubstring = managerName.Substring(0, Math.Min(managerName.Length, managerNameLength));


                Console.WriteLine($"| {emp.Id,-idLength}| {fullNameSubstring,-nameLength} | {emailSubstring,-emailLength} | {phoneSubstring,-phoneLength} | {locationSubstring,-locationLength} | {departmentSubstring,-departmentLength} | {roleSubstring,-roleLength} | {projectSubstring,-projectLength} | {managerSubstring,-managerNameLength} |");
            }

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------");
        }
        public  async Task ViewEmployeesAsync()
        {
             ViewEmployeesAsync(await _empService.getAllEmployeesAsync());

        }
        public  async Task ViewSingleEmployeeAsync()
        {
            Console.WriteLine("Enter the employee ID");
            string getId = Console.ReadLine() ?? "";
            if (await _empService.CheckIdAsync(getId))
            {
                EmployeeView emp =await _empService.getSingleEmployeeAsync(getId);
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"ID : {emp.Id}\nName : {emp.FirstName} {emp.LastName}\nEmailId : {emp.EmailId}\nMobileNo : {emp.MobileNo}");
                Console.WriteLine($"DateOfBirth : {emp.DateOfBirth}\nDateOfJoining : {emp.DateOfJoining}");
                Console.WriteLine($"Role : {emp.RoleName}\nDepartment : {emp.Department}\nLocation : {emp.Location}");
                Console.WriteLine($"Project : {emp.ProjectName}\nManager : {emp.ManagerName}");
                Console.WriteLine("--------------------------------------");

            }
        }
        public  async Task SortEmployeesAsync()
        {
            Console.WriteLine("Select your choice to sort");
            Console.WriteLine("1.EmployeeView Id\n2.FirstName\n3.LastName\n4.Dateof Birth\n5.Email id\n6.Location\n7.Department\n8.JobTItile\n9.Dateof Joining");
            int sortChoice = Int32.Parse(Console.ReadLine() ?? "0");
            List<EmployeeView> sortedData = [];
            if(sortChoice>0 && sortChoice<=9){
                sortedData=await _empService.getSortedDataAsync(sortChoice);
            }
            else{
                Console.WriteLine("Invalid choice");
                return;
            }
             ViewEmployeesAsync(sortedData);
        }
        public  async Task editEmployeeAsync()
        {
            Console.WriteLine("--Edit EmployeeView Id");
            Console.WriteLine("Enter EmployeeView ID");
            string searchId = Console.ReadLine() ?? "";
            if (await _empService.CheckIdAsync(searchId))
            {
                EmployeeView foundEmployee = await _empService.GetDataToEditAsync(searchId);
                Console.WriteLine("Select your choice to edit");
                int editChoice = 1;
                while (editChoice > 0)
                {
                    Console.WriteLine("1.FirstName\t2.LastName\t3.Dateof Birth\t4.Email id\t5.Dateof Joining\t6.Role\t7.Project\t8.Location\t9.Department\t0:Submit");
                    editChoice = int.Parse(Console.ReadLine() ?? "0");
                    switch (editChoice)
                    {
                        case 1:
                            Console.WriteLine("Enter new FirstName");
                            string firstNameInput = Console.ReadLine() ?? "";
                            if (!_validate.ValidateName(firstNameInput))
                            {
                                firstNameInput = ReTakeData(1);
                                if (!_validate.ValidateName(firstNameInput))
                                {
                                    return;
                                }
                            }
                            foundEmployee.FirstName=firstNameInput;
                            break;
                        case 2:
                            Console.WriteLine("Enter new lastName");
                            string lastNameInput = Console.ReadLine() ?? "";
                            if (!_validate.ValidateName(lastNameInput))
                            {
                                lastNameInput = ReTakeData(1);
                                if (!_validate.ValidateName(lastNameInput))
                                {
                                    return;
                                }
                            }
                            foundEmployee.LastName=lastNameInput;
                            break;
                        case 3:
                            Console.WriteLine("Enter new DateOf Birth\n Follow format yyyy-mm-dd");
                            foundEmployee.DateOfBirth = _validate.ValidateDate(Console.ReadLine());
                            break;
                        case 4:
                            Console.WriteLine("Enter new Email");
                            string emailInput = Console.ReadLine() ?? "";
                            if (!_validate.ValidateEmail(emailInput))
                            {
                                emailInput= ReTakeData(4);
                                if (!_validate.ValidateEmail(emailInput))
                                {
                                    return;
                                }
                            }
                            foundEmployee.EmailId=emailInput;
                            break;
                        case 5:
                            Console.WriteLine("Enter new Joining Date(yyyy-mm-dd)");
                            foundEmployee.DateOfJoining = _validate.ValidateDate(Console.ReadLine());
                            break;
                        case 6:
                            Console.WriteLine("Enter new Role");
                            string roleIdInput = Console.ReadLine() ?? "";
                            if (await _roleService.CheckIdAsync(roleIdInput))
                            {
                                foundEmployee.RoleName = roleIdInput;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input");
                                return;
                            }
                            break;
                        case 7:
                            Console.WriteLine("Enter new Project Name");
                            string? projectIdInput = Console.ReadLine()??"";
                            if (_validate.ValidateName(projectIdInput))
                            {
                                foundEmployee.ProjectName = projectIdInput;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input");
                            }
                            break;
                        case 8:
                            Console.WriteLine("Enter new location");
                            string locationInput = Console.ReadLine() ?? "";
                            if (!_validate.ValidateName(locationInput))
                            {
                                locationInput = ReTakeData(1);
                                if (!_validate.ValidateName(locationInput))
                                {
                                    return;
                                }
                            }
                            foundEmployee.Location=locationInput;
                            break;
                        case 9:
                            Console.WriteLine("Enter new Department");
                            string departmentInput = Console.ReadLine() ?? "";
                            if (!_validate.ValidateName(departmentInput))
                            {
                                departmentInput = ReTakeData(1);
                                if (!_validate.ValidateName(departmentInput))
                                {
                                    return;
                                }
                            }
                            foundEmployee.Department=departmentInput;
                            break;
                        case 0:
                            Console.WriteLine("Submitted");
                            List<EmployeeView> editedEmployeeList = [];
                            editedEmployeeList.Add(foundEmployee);
                             ViewEmployeesAsync(editedEmployeeList);
                             await _empService.EditAsync(foundEmployee);
                            break;
                        default:
                            Console.WriteLine("Wrong Input.. Action Not possible");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("EmployeeView Not Found");
                return;
            }
        }
        public async Task ExportEmployeeToCsvAsync()
        {
            await _empService.ExportEmployeeToCsvAsync();
            Console.WriteLine("Data exported to CSV");
        }
        public async Task FilterEmployeesAsync()
        {
            int filterChoice=9; 
            string filterOption="";
            while(filterChoice>0){
                Console.WriteLine("Filter Options 1.Role\t 2.Department\t 3.Location");
                filterChoice=int.Parse(Console.ReadLine()??"0");
                switch(filterChoice){
                    case 1:
                        Console.WriteLine("Enter Role id");
                        filterOption=Console.ReadLine()??"";
                        if(!_validate.ValidateRoleId(filterOption)){
                            Console.WriteLine("Invalid role id");
                            return;
                        }
                        break;
                    case 2:
                         Console.WriteLine("Enter Departent");
                        filterOption=Console.ReadLine()??"";
                        if(!_validate.ValidateName(filterOption)){
                            Console.WriteLine("Invalid role id");
                            return;
                        }
                        break;
                    case 3:
                         Console.WriteLine("Enter Department");
                         filterOption=Console.ReadLine()??"";
                        if(!_validate.ValidateName(filterOption)){
                            Console.WriteLine("Invalid role id");
                            return;
                        }
                        break;
                    case 0:
                        Console.WriteLine("Exiting");
                        return;
                    default:
                        Console.WriteLine("Invalid Input Exited");
                        return;
                }
                 ViewEmployeesAsync(await _empService.FilterAsync(filterChoice,filterOption));

            }
        }
        public string ReTakeData(int choice)
        {
            int trail=0;
            while(trail<3){
                Console.WriteLine("Try Entering Data Again");
                string? data=Console.ReadLine();
                bool ans;
                switch(choice){
                    case 1:
                        ans=_validate.ValidateName(data);
                        break;
                    case 2:
                        ans=_validate.ValidateEmployeeId(data);
                        break;
                    case 3:
                        ans=_validate.ValidateRoleId(data);
                        break;
                    case 4:
                        ans=_validate.ValidateEmail(data);
                        break;
                    case 5:
                        ans=_validate.ValidateMobileNo(data);
                        break;
                    default:
                        ans=false;
                    
                        break;
                }
                if(ans){
                    return data??"";
                }
                else{
                    trail++;
                }
            }
            Console.WriteLine("You have entered 3 times wrong! Operation Cancelled");
            return "";

        }
        public async Task InsertFakeDataAsync(){
            TestData testData=new TestData();
            foreach(var e in testData.GenerateEmployees()){
                EmployeeRegistration newEmployee=new EmployeeRegistration();
                newEmployee.FirstName=e.FirstName;
                newEmployee.LastName=e.LastName;
                newEmployee.DateOfBirth=e.DateOfBirth;
                newEmployee.EmailId=e.EmailId;
                newEmployee.MobileNo=e.MobileNo;
                newEmployee.RoleName=e.RoleName;
                newEmployee.ProjectName=e.ProjectName;
                newEmployee.Location=e.Location;
                newEmployee.Department=e.Department;
                newEmployee.ManagerName=e.ManagerName;
                 await _empService.InsertAsync(newEmployee);
            }
        }

    }
}