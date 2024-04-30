using EmployeeApp.Models;

namespace EmployeeApp.Presentation
{
    public interface IEmployeeManager
    {
        public Task CreateEmployeeAsync();
        public Task DeleteEmployeeAsync();
        public Task SearchByLetterAsync();
        public Task ViewEmployeesAsync(List<EmployeeView> employees);
        public Task ViewEmployeesAsync();
        public Task ViewSingleEmployeeAsync();
        public Task SortEmployeesAsync();
        public Task editEmployeeAsync();
        public Task ExportEmployeeToCsvAsync();
        public Task FilterEmployeesAsync();
        public Task InsertFakeDataAsync();
    }

}