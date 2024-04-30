namespace EmployeeApp.Presentation
{
    public interface IMainmenu
    {
        public Task EntryAsync();
        public Task EmployeeOperationsAsync();
        public Task RoleOperationsAsync();

    }
}