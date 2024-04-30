using EmployeeApp.Models;
using AutoMapper;
using EmployeeApp.Data.Entites;
namespace EmployeeApp.Services
{
    public class MapperService : Profile
    {
        public MapperService()
        {
            ConfigureMappers();
            CreateMap<Role, RoleView>().ReverseMap();
            CreateMap<EmployeeInfo, EmployeeView>().ReverseMap();
        }
        public void ConfigureMappers()
        {
            CreateMap<EmployeeView, Employee>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.EmailId, opt => opt.MapFrom(src => src.EmailId))
                .ForMember(dest => dest.MobileNo, opt => opt.MapFrom(src => src.MobileNo))
                .ForMember(dest => dest.DateOfJoining, opt => opt.MapFrom(src => src.DateOfJoining))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleName))
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.ProjectName))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.ManagerName));

            CreateMap<Employee, EmployeeView>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.EmailId, opt => opt.MapFrom(src => src.EmailId))
                .ForMember(dest => dest.MobileNo, opt => opt.MapFrom(src => src.MobileNo))
                .ForMember(dest => dest.DateOfJoining, opt => opt.MapFrom(src => src.DateOfJoining))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.RoleId))
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.ProjectName))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.ManagerName));

            CreateMap<EmployeeRegistration, Employee>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => " "))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.EmailId, opt => opt.MapFrom(src => src.EmailId))
                .ForMember(dest => dest.MobileNo, opt => opt.MapFrom(src => src.MobileNo))
                .ForMember(dest => dest.DateOfJoining, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleName))
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.ProjectName))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.ManagerName));
            CreateMap<RoleRegistration, Role>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => " "))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location));
        }

    }

}