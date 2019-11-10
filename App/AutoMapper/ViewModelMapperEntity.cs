using AutoMapper;
using story.App.CodeFirstEntity.Entities;
using story.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.AutoMapper
{
    public class ViewModelMapperEntity: Profile
    {
        public ViewModelMapperEntity()
        {
            CreateMap<AppUserViewModel, AppUser>().ConstructUsing(x => new AppUser(x.Id,x.FullName, x.Avatar, x.Email));
            CreateMap<AppRoleViewModel, AppRole>().ConstructUsing(x => new AppRole(x.Id, x.Name, x.Description, x.Status));
        }
    }
}
