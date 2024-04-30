using EmployeeApp.Data.Entites;
using EmployeeApp.Data;
using System.Globalization;
using System.Text;
using EmployeeApp.Models;
using CsvHelper;
using AutoMapper;

namespace EmployeeApp.Services
{
    public class EmployeeServices : IEmployeeServices
    {

        private readonly IEmployeeRepo _employeeAccess;
        private readonly IRoleRepo _roleAccess;
        private readonly IMapper _mapper;
        public EmployeeServices(IEmployeeRepo employeeAccess, IRoleRepo roleAccess, IMapper mapper)
        {
            _employeeAccess = employeeAccess;
            _roleAccess = roleAccess;
            _mapper = mapper;
        }

        public async Task InsertAsync(EmployeeRegistration employeeView)
        {
            Employee employee = _mapper.Map<EmployeeRegistration, Employee>(employeeView);
            employee.Id =await genrarateEmployeeIdAsync();
            await _employeeAccess.InsertAsync(employee);
        }
        public async Task EditAsync(EmployeeView employeeView)
        {
            Employee employee = _mapper.Map<EmployeeView, Employee>(employeeView);
            await _employeeAccess.EditAsync(employee);
        }
        public async Task DeleteAsync(string id)
        {
            await _employeeAccess.DeleteAsync(id);
        }
        public async Task<List<EmployeeView>> getAllEmployeesAsync()
        {
            List<EmployeeInfo> employeeList =await _employeeAccess.ViewAllDetailsAsync();
            List<EmployeeView> employeeViewList = [];
            foreach (var a in employeeList)
            {
                employeeViewList.Add(_mapper.Map<EmployeeInfo, EmployeeView>(a));
            }
            return employeeViewList;
        }
        public async Task<EmployeeView> getSingleEmployeeAsync(string id)
        {
            EmployeeInfo employee =await _employeeAccess.ViewOneDetailAsync(id);
            return _mapper.Map<EmployeeInfo, EmployeeView>(employee);
        }
        public async Task<List<EmployeeView>> getSortedDataAsync(int sortChoice)
        {
            List<EmployeeView> employeeViewList = [];
            foreach (var a in await _employeeAccess.getSortedDataAsync(sortChoice))
            {
                employeeViewList.Add(_mapper.Map<EmployeeInfo, EmployeeView>(a));
            }
            return employeeViewList;
        }
        public async Task<List<EmployeeView>> SearchByLetterAsync(char letterToSearch)
        {
            List<EmployeeView> employeeViewList = [];
            foreach (var a in await _employeeAccess.SearchByLetterAsync(letterToSearch))
            {
                employeeViewList.Add(_mapper.Map<EmployeeInfo, EmployeeView>(a));
            }
            return employeeViewList;
        }
        public async Task ExportEmployeeToCsvAsync()
        {
            string filePath = "C:\\Users\\aravind.a\\OneDrive - Technovert\\Documents\\DotnetApp\\Presentation\\EmployeeView.csv";
            // Use CultureInfo.InvariantCulture for consistent formatting
            List<EmployeeInfo> employee =await _employeeAccess.ViewAllDetailsAsync();
            List<EmployeeView> employees = employee.Select(a => _mapper.Map<EmployeeInfo, EmployeeView>(a)).ToList();
            using var writer = new StreamWriter(filePath, false, new UTF8Encoding(false)); // Replace 'false' with 'true' to append to existing file
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            // Write headers (optional)
            csv.WriteField("EmployeeView ID");
            csv.WriteField("First Name");
            csv.WriteField("Last Name");
            csv.WriteField("Email Id");
            csv.WriteField("Mobile No");
            csv.WriteField("Job Title");
            csv.WriteField("Location");
            csv.WriteField("Department");
            csv.WriteField("Project");
            csv.WriteField("Date of Birth"); // Assuming format yyyy-MM-dd
            csv.WriteField("Date of Joining"); // Assuming format yyyy-MM-dd
            csv.WriteField("Manager");
            csv.NextRecord(); // Move to the next line after headers
            foreach (var emp in employees)
            {
                csv.WriteField(emp.Id);
                csv.WriteField(emp.FirstName);
                csv.WriteField(emp.LastName);
                csv.WriteField(emp.EmailId);
                csv.WriteField(emp.MobileNo);
                csv.WriteField(emp.RoleName);
                csv.WriteField(emp.Location);
                csv.WriteField(emp.Department);
                csv.WriteField(emp.ProjectName);
                csv.WriteField(emp.DateOfBirth?.ToString("yyyy-MM-dd")); 
                csv.WriteField(emp.DateOfJoining?.ToString("yyyy-MM-dd")); // Assuming format yyyy-MM-dd
                csv.WriteField(emp.ManagerName);
                csv.NextRecord();
            }
        }
        public async Task<bool> CheckIdAsync(string id)
        {
            return await _employeeAccess.CheckIdAsync(id);
        }
        public async Task<List<EmployeeView>> FilterAsync(int choice, string filterOption)
        {

            List<EmployeeView> employeeViewList = [];
            foreach (var a in await _employeeAccess.FilterAsync(choice, filterOption))
            {
                employeeViewList.Add(_mapper.Map<EmployeeInfo, EmployeeView>(a));
            }
            return employeeViewList;
        }
        public async Task<EmployeeView> GetDataToEditAsync(string id)
        {
            Employee employee =await _employeeAccess.ViewOneEmployeeAsync(id);
            return _mapper.Map<Employee, EmployeeView>(employee);

        }
        public async Task<String> genrarateEmployeeIdAsync()
        {
            EmployeeInfo? employee =(await _employeeAccess.ViewAllDetailsAsync()).OrderByDescending(e => e.Id).FirstOrDefault();
            int idNo = 1;
            if (employee != null)
            {
                idNo = int.Parse(employee.Id[2..6]) + 1;
            }
            return "TZ" + idNo.ToString("D4");

        }

    }
}