namespace EmployeeApp.Presentation
{
    public interface IRoleManager
    {
        public Task CreateRoleAsync();
        public Task DeleteRoleAsync();
        public Task ViewRolesAsync();
        public Task AssignEmployeesAsync();
        public Task ShowRoleEmployeesAsync();
        public Task EditRoleAsync();
        public string ReTakeData(int choice);
        public void InsertFakeData();
    }
}