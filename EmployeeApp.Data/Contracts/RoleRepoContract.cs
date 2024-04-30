using EmployeeApp.Data.Entites;

namespace EmployeeApp.Data
{
    public interface IRoleRepo
    {
        public Task<Role> ViewOneAsync(string id);
        public Task<bool> CheckIdAsync(string id);
        public Task<List<Role>> ViewAllAsync();
        public Task InsertAsync(Role role);
        public Task EditAsync(Role role);
        public Task DeleteAsync(string id);
    }
}