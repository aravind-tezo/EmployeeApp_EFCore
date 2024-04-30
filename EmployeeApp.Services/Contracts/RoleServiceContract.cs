using EmployeeApp.Models;

namespace EmployeeApp.Services
{
    public interface IRoleServices
    {
        public Task<List<RoleView>> getAllRolesAsync();
        public Task InsertAsync(RoleRegistration roleView);
        public Task EditAsync(RoleView roleView);
        public Task DeleteAsync(string id);
        public Task<List<EmployeeView>> ShowEmployeesAsync(string roleId);
        public Task<RoleView> ViewRoleAsync(string id);
        public Task<bool> CheckIdAsync(string id);
    }
}