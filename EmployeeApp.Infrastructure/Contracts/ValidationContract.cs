using EmployeeApp.Models;
namespace EmployeeApp.Infrastructure
{
    public interface IValidation
    {
        public bool ValidateEmployeeId(string? Id);
        public bool ValidateRoleId(string? Id);
        public bool ValidateName(string? Id);
        public bool ValidateEmail(string? Id);
        public bool ValidateMobileNo(string? Id);
        public DateTime? ValidateDate(string? date);
        public bool AttributeValidation(RoleView role);

    }
}