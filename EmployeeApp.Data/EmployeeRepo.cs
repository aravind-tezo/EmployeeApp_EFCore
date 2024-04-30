using EmployeeApp.Data.Entites;
using EmployeeApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Security.Cryptography;

namespace EmployeeApp.Data
{
    public class EmployeeRepo:IEmployeeRepo
    {
        private IRoleRepo roleRepo;
        private MyDBContext _dbContext;
        public EmployeeRepo(IRoleRepo _roleRepo,MyDBContext myDbContext)
        {
            roleRepo = _roleRepo;
            _dbContext=myDbContext;
        }

        #region CRUD_Operations
        public async Task InsertAsync(Employee employee)
        {
           await _dbContext.Employees.AddAsync(employee);
           await _dbContext.SaveChangesAsync();         
        }
        public async Task EditAsync(Employee employee)
        {
           var empToUpdate=await _dbContext.Employees.FindAsync(employee.Id);
           if(empToUpdate!=null){
                empToUpdate.FirstName=employee.FirstName;
                empToUpdate.LastName=employee.LastName;
                empToUpdate.MobileNo=employee.MobileNo;
                empToUpdate.EmailId=employee.EmailId;
                empToUpdate.DateOfBirth=employee.DateOfBirth;
                empToUpdate.DateOfJoining=employee.DateOfJoining;
                empToUpdate.Location=employee.Location;
                empToUpdate.RoleId=employee.RoleId;
                empToUpdate.Department=employee.Department;
                empToUpdate.ManagerName=employee.ManagerName;
                empToUpdate.ProjectName=employee.ProjectName;
                await _dbContext.SaveChangesAsync();
           }
        }
        public async Task DeleteAsync(string id)
        {
            var emp=await _dbContext.Employees.FirstOrDefaultAsync(e=>e.Id==id);
            if(emp!=null)
            {
                 _dbContext.Employees.Remove(emp);
                await _dbContext.SaveChangesAsync();
            }
        }
        public  async Task<List<EmployeeInfo>> ViewAllDetailsAsync()
        {
            return await _dbContext.GetEmployeeDetailsAsync();
        }

        public async Task<EmployeeInfo> ViewOneDetailAsync(string id) 
        {
            var employeeDetails= await _dbContext.GetEmployeeDetailsAsync();
            return employeeDetails.FirstOrDefault(e => e.Id == id);
        }
        public async Task<Employee> ViewOneEmployeeAsync(string id)
        {

            return await _dbContext.Employees.Where(e => string.Equals(e.Id,id)).Include(e=>e.Role).FirstOrDefaultAsync();


        }
        #endregion

        #region Order Operations
        public async Task<List<EmployeeInfo>> getSortedDataAsync(int sortChoice)
        {
            try
            {
                List<EmployeeInfo> EmployeeList =await _dbContext.GetEmployeeDetailsAsync();
                Dictionary<string, Role> RoleList = [];
                foreach (var r in await roleRepo.ViewAllAsync())
                {
                    RoleList.Add(r.Id, r);
                }
                List<EmployeeInfo> sortedData = [];
                switch (sortChoice)
                {
                    case 1:
                        sortedData = [.. EmployeeList.OrderBy(e => e.Id)];
                        break;
                    case 2:
                        sortedData = [.. EmployeeList.OrderBy(e => e.FirstName)];
                        break;
                    case 3:
                        sortedData = [.. EmployeeList.OrderBy(e => e.LastName)];
                        break;
                    case 4:
                        sortedData = [.. EmployeeList.OrderBy(e => e.DateOfBirth)];
                        break;
                    case 5:
                        sortedData = [.. EmployeeList.OrderBy(e => e.EmailId)];
                        break;
                    case 6:
                        sortedData = [.. EmployeeList.OrderBy(e => e.Location)];
                        break;
                    case 7:
                        sortedData = [.. EmployeeList.OrderBy(e => e.Department)];
                        break;
                    case 8:
                        sortedData = [.. EmployeeList.OrderBy(e => e.RoleName)];
                        break;
                    case 9:
                        sortedData = [.. EmployeeList.OrderBy(e => e.DateOfJoining)];
                        break;
                }
                return  sortedData;
            }
            catch (Exception e)
            {
                 File.WriteAllTextAsync("../EmployeeApp.Presentation/Exceptions.txt", e.Message);
                return [];
            }
        }
        public  async Task<List<EmployeeInfo>> SearchByLetterAsync(char letterToSearch)
        {
            List<EmployeeInfo> EmployeeList =await _dbContext.GetEmployeeDetailsAsync();
            return  EmployeeList.Where(e => e.FirstName.StartsWith(letterToSearch.ToString(), StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public async Task<bool> CheckIdAsync(string id)
        {
    
            if (await _dbContext.Employees.AnyAsync(e=>e.Id==id))
            {
                return true;
            }
            return false;
        }
        public  async Task<List<EmployeeInfo>> FilterAsync(int choice, string filterOption)
        {
            List<EmployeeInfo> EmployeeList =await _dbContext.GetEmployeeDetailsAsync();
            switch (choice)
            {
                case 1:
                    return  EmployeeList.Where(e => e.RoleName == filterOption).ToList();
                case 2:
                    return  EmployeeList.Where(e => e.Department == filterOption).ToList();
                case 3:
                    return  EmployeeList.Where(e => e.Location == filterOption).ToList();
                default:
                    return [];
            }
        }
        #endregion

    }
}