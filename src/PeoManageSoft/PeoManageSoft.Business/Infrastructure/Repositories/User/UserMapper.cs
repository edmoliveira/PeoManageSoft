﻿using AutoMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;

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
            CreateMap<IDataReaderGetValue, UserEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GetValue<long>(UserEntityField.Id_Readonly)))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.GetValue<bool>(UserEntityField.IsActive)))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.GetValue<string>(UserEntityField.Login_Readonly)))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.GetValue<string>(UserEntityField.Password)))
                .ForMember(dest => dest.PasswordToken, opt => opt.MapFrom(src => src.GetValue<string>(UserEntityField.PasswordToken)))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.GetValue<int>(UserEntityField.Role)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetValue<string>(UserEntityField.Name)))
                .ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.GetValue<string>(UserEntityField.ShortName)))
                .ForMember(dest => dest.TitleId, opt => opt.MapFrom(src => src.GetValue<long>(UserEntityField.TitleId)))
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.GetValue<long>(UserEntityField.DepartmentId)))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.GetValue<string>(UserEntityField.Email_Readonly)))
                .ForMember(dest => dest.BussinessPhone, opt => opt.MapFrom(src => src.GetValue<string>(UserEntityField.BussinessPhone)))
                .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(src => src.GetValue<string>(UserEntityField.MobilePhone)));

        }

        #endregion
    }
}