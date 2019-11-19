using AutoMapper;
using story.App.CodeFirstEntity.Entities;
using story.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.AutoMapper
{
    public class EntityMapperViewModel : Profile
    {
        public EntityMapperViewModel()
        {
            CreateMap<AppUser, AppUserViewModel>();
            CreateMap<AppRole, AppRoleViewModel>();
            CreateMap<Function, FunctionViewModel>();
            CreateMap<AppUserRole, AppUserRoleViewModel>();
            CreateMap<Permisstion, PermissionViewModel>();
        }
    }
}
