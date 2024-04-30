using EmployeeApp.Data.Entites;
using EmployeeApp.Models;

namespace EmployeeApp.Data
{
    public interface IEmployeeRepo
    {
        public Task InsertAsync(Employee employee);
        public Task EditAsync(Employee employee);
        public Task DeleteAsync(string id);
        public Task<List<EmployeeInfo>> ViewAllDetailsAsync();
        public Task<EmployeeInfo> ViewOneDetailAsync(string id);
        public Task<Employee> ViewOneEmployeeAsync(string id);
        public Task<List<EmployeeInfo>> getSortedDataAsync(int sortChoice);
        public Task<List<EmployeeInfo>> SearchByLetterAsync(char letterToSearch);
        public Task<bool> CheckIdAsync(string id);
        public Task<List<EmployeeInfo>> FilterAsync(int choice, string filterOption);


    }
}