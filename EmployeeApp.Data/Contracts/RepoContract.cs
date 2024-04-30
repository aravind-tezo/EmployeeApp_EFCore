
namespace EmployeeApp.Data
{
    public interface IRepo<T>
    {
        public void InsertAsync(T t);
        public void EditAsync(T t);
        public void DeleteAsync(string id);
        List<T> ReadDataAsync();
    }

}