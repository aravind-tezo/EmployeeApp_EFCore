using EmployeeApp.Data.Entites;
using Microsoft.EntityFrameworkCore;
namespace EmployeeApp.Data{
    public class RoleRepo:IRoleRepo
    {
        private MyDBContext _dbContext;
        public RoleRepo(MyDBContext myDbContext)
        {
            _dbContext=myDbContext;
        }

        #region CRUD Operations
        public async Task<Role> ViewOneAsync(string id){
            return await _dbContext.Roles.FirstOrDefaultAsync(r=>r.Id==id);
        }
        public  async Task<bool> CheckIdAsync(string id){
            return await _dbContext.Roles.AnyAsync(e=>e.Id==id);
        }
        public async Task<List<Role>> ViewAllAsync(){
            return await _dbContext.Roles.ToListAsync();
        }
        public async Task InsertAsync(Role role){
            _dbContext.Roles.AddAsync(role);
            _dbContext.SaveChangesAsync();
        }
        public async Task EditAsync(Role role)
        {
            var r=await _dbContext.Roles.FindAsync(role.Id);
            if(r!=null)
            {
                r.Name=role.Name;
                r.Department=role.Department;
                r.Description=role.Description;
                r.Location=role.Location;
                _dbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(string id){
            var roleToDelete=await _dbContext.Roles.FirstOrDefaultAsync(r=>r.Id==id);
            if(roleToDelete!=null){
                _dbContext.Roles.Remove(roleToDelete);
                _dbContext.SaveChangesAsync();
            }
        }
        #endregion
    }
}