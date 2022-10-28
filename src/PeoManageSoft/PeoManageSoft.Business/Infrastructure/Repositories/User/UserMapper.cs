using AutoMapper;
using System.Data;
using static PeoManageSoft.Business.Infrastructure.Repositories.User.UserEntityConfig;

namespace PeoManageSoft.Business.Infrastructure.Repositories.User
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal class UserMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.User.UserMapper class.
        /// </summary>
        public UserMapper()
        {
            var searchValue = GetFuncSearchValue();

            CreateMap<IDataReader, UserEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => (long)searchValue(EntityField.Id_Readonly, src)))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => (bool)searchValue(EntityField.IsActive, src)))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => searchValue(EntityField.Login_Readonly, src)))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => searchValue(EntityField.Password, src)))
                .ForMember(dest => dest.PasswordToken, opt => opt.MapFrom(src => searchValue(EntityField.PasswordToken, src)))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => (int)searchValue(EntityField.Role, src)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => searchValue(EntityField.Name, src)))
                .ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => searchValue(EntityField.ShortName, src)))
                .ForMember(dest => dest.TitleId, opt => opt.MapFrom(src => (long)searchValue(EntityField.TitleId, src)))
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => (long)searchValue(EntityField.DepartmentId, src)))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => searchValue(EntityField.Email_Readonly, src)))
                .ForMember(dest => dest.BussinessPhone, opt => opt.MapFrom(src => searchValue(EntityField.BussinessPhone, src)))
                .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(src => searchValue(EntityField.MobilePhone, src)));

        }

        #endregion
    }
}
