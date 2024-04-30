using Microsoft.EntityFrameworkCore;
using EmployeeApp.Data.Entites;
using EmployeeApp.Models;
using System.Configuration;

namespace EmployeeApp.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options):base(options)
        {
        
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public async Task<List<EmployeeInfo>> GetEmployeeDetailsAsync()
        {
            return await (from e in Employees
                    join r in Roles on e.RoleId equals r.Id
                    select new EmployeeInfo
                    {
                        Id = e.Id,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        DateOfBirth = e.DateOfBirth,
                        EmailId = e.EmailId,
                        MobileNo = e.MobileNo,
                        RoleName = r.Name,
                        ProjectName = e.ProjectName,
                        ManagerName = e.ManagerName,
                        Location = e.Location,
                        Department = e.Department,
                        DateOfJoining = e.DateOfJoining
                    }).ToListAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
            .HasKey(e => e.Id);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Id)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .HasOne(e=>e.Role)
                .WithMany()
                .HasForeignKey(e => e.RoleId) 
                .IsRequired();       

            modelBuilder.Entity<Role>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Role>()
                .Property(r => r.Id)
                .IsRequired();

            modelBuilder.Entity<Employee>().ToTable("Employees", "EmployeeApp");
            modelBuilder.Entity<Role>().ToTable("Roles", "EmployeeApp");

        }
    }
}