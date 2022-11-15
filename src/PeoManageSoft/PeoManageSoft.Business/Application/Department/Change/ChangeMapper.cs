﻿using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Commands.Department.Update;

namespace PeoManageSoft.Business.Application.Department.Change
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal sealed class ChangeMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Department.Change.ChangeMapper class.
        /// </summary>
        public ChangeMapper()
        {
            CreateMap<ChangeRequest, UpdateRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }

        #endregion
    }
}
