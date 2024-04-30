using EmployeeApp.Models;

namespace EmployeeApp.Services
{
    public interface IEmployeeServices
    {
        public Task InsertAsync(EmployeeRegistration employeeView);
        public Task EditAsync(EmployeeView employeeView);
        public Task DeleteAsync(string id);
        public Task<List<EmployeeView>> getAllEmployeesAsync();
        public Task<EmployeeView> getSingleEmployeeAsync(string id);
        public Task<List<EmployeeView>> getSortedDataAsync(int sortChoice);
        public Task<List<EmployeeView>> SearchByLetterAsync(char letterToSearch);
        public Task ExportEmployeeToCsvAsync();
        public Task<bool> CheckIdAsync(string id);
        public Task<List<EmployeeView>> FilterAsync(int choice, string filterOption);
        public Task<EmployeeView> GetDataToEditAsync(string id);

    }
}