using AutoMapper;
using EmployeeApp.Data;
using EmployeeApp.Data.Entites;
using EmployeeApp.Models;

namespace EmployeeApp.Services
{
    public class RoleServices : IRoleServices
    {
        private IEmployeeRepo employeeAccess;
        private IRoleRepo roleAccess;
        private readonly IMapper _mapper;

        public RoleServices(IEmployeeRepo _employeeRepo, IRoleRepo _roleRepo, IMapper mapper)
        {
            employeeAccess = _employeeRepo;
            roleAccess = _roleRepo;
            _mapper = mapper;
        }
        public async Task<List<RoleView>> getAllRolesAsync()
        {
            List<RoleView> roleViewList = [];
            foreach (var a in await roleAccess.ViewAllAsync())
            {
                roleViewList.Add(_mapper.Map<Role, RoleView>(a));
            }
            return roleViewList;
        }
        public async Task InsertAsync(RoleRegistration roleView)
        {
            Role role = _mapper.Map<RoleRegistration, Role>(roleView);
            role.Id = await genrarateRoleIdAsync();
            await roleAccess.InsertAsync(role);
        }
        public async Task EditAsync(RoleView roleView)
        {
            Role role = _mapper.Map<RoleView, Role>(roleView);
            await roleAccess.EditAsync(role);
        }
        public async Task DeleteAsync(string id)
        {
            await roleAccess.DeleteAsync(id);
        }
        public async Task<List<EmployeeView>> ShowEmployeesAsync(string roleId)
        {
            RoleView r = _mapper.Map<Role, RoleView>(await roleAccess.ViewOneAsync(roleId));
            Console.WriteLine($"{roleId}-{r.Name}");
            return (await employeeAccess.ViewAllDetailsAsync()).Select(employee => _mapper.Map<EmployeeInfo, EmployeeView>(employee)).Where(view => view.RoleName == r.Name).ToList();
        }
        public async Task<RoleView> ViewRoleAsync(string id)
        {
            return _mapper.Map<Role, RoleView>(await roleAccess.ViewOneAsync(id));
        }
        public async Task<bool> CheckIdAsync(string id)
        {
            return await roleAccess.CheckIdAsync(id);
        }
        public async Task<String> genrarateRoleIdAsync()
        {
            Role? role = (await roleAccess.ViewAllAsync()).OrderByDescending(e => e.Id).FirstOrDefault();
            int idNo = 1;
            if (role != null)
            {
                idNo = int.Parse(role.Id[2..4]) + 1;
            }
            return "RL" + idNo.ToString("D2");

        }
    }
}