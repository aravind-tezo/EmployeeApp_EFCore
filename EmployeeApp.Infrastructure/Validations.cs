using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using EmployeeApp.Models;
namespace EmployeeApp.Infrastructure
{
    public class Validation : IValidation
    {
        public bool ValidateEmployeeId(string? Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                return Regex.IsMatch(Id, "^TZ\\d{4}$");
            }
            else
            {
                return false;
            }
        }
        public bool ValidateRoleId(string? Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                return Regex.IsMatch(Id, "^RL\\d{2}$");
            }
            else
            {
                return false;
            }
        }
        public bool ValidateName(string? Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                return Regex.IsMatch(Id, "^[a-zA-Z]+(?: [a-zA-Z]+)*$");
            }
            else
            {
                return false;
            }
        }
        public bool ValidateEmail(string? Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                return Regex.IsMatch(Id, "^^([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5})$");
            }
            else
            {
                return false;
            }
        }
        public bool ValidateMobileNo(string? Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                return Regex.IsMatch(Id, "^\\d{10}|\\d{12}$");

            }
            else
            {
                return false;
            }
        }
        public DateTime? ValidateDate(string? date)
        {
            if (string.IsNullOrEmpty(date))
            {
                Console.WriteLine("Empty Date");
                return null;
            }
            try
            {
                DateTime dateOfJoining = DateTime.Parse(date);
                return dateOfJoining;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date format. Please enter in YYYY-MM-DD format.");
                return null;
            }
        }
        public bool AttributeValidation(RoleView role)
        {
            if (role == null)
            {
                Console.WriteLine("ROle is null");
                return false;
            }
            ValidationContext context = new ValidationContext(role);
            List<ValidationResult> results = new List<ValidationResult>();
            // Console.WriteLine($"---------------{role.Name}");
            try
            {
                Validator.TryValidateProperty(role, context, results);
                if (results.Count > 0)
                {
                    foreach (var res in results)
                    {
                        Console.WriteLine($"{res.ErrorMessage}{role.Name}");
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }





    }
}
