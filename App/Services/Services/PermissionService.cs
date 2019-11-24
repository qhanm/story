using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using story.App.AutoMapper;
using story.App.CodeFirstEntity;
using story.App.CodeFirstEntity.Entities;
using story.App.Model;
using story.App.Services.Repositories;
using story.App.Services.ServiceInterface;
using story.Extensions.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.Services.Services
{
    public class PermissionService : IPermissionServiceInterface
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly RoleManager<AppRole> _roleManager;

        private readonly AppDbContext _appDbContext;

        private readonly IRepository<Permission, int> _repositoryPermission;

        private readonly IRepository<Function, string> _repositoryFunction;

        public PermissionService(IRepository<Permission, int> repositoryPermission, IRepository<Function, string> repositoryFunction, AppDbContext appDbContext, RoleManager<AppRole> roleManager)
        {
            _repositoryFunction = repositoryFunction;
            _repositoryPermission = repositoryPermission; 
            _appDbContext = appDbContext;
            _roleManager = roleManager;
        }

        public bool CheckPermission(string functionId, string action, string[] roles)
        {
            var permissions = _repositoryPermission.FindAll();
            var functions = _repositoryFunction.FindAll();

            var query = from function in functions
                        join permission in permissions on function.Id equals permission.FunctionId
                        join role in _roleManager.Roles on permission.RoleId equals role.Id
                        where roles.Contains(role.Name) && function.Id == functionId
                        &&((permission.Read && action == PermissionConstant.CanRead)
                        ||(permission.Delete && action == PermissionConstant.CanDelete)
                        ||(permission.Update && action == PermissionConstant.CanUpdate)
                        ||(permission.Create && action == PermissionConstant.CanCreate)
                        ||(permission.Approved && action == PermissionConstant.CanApprove))
                        select permission;

            return query.Any();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<PermissionViewModel> GetAll(Guid? roleId)
        {
            var query = _repositoryPermission.FindAll();

            if (roleId.HasValue)
            {
                query.Where(x => x.RoleId == roleId);
            }

            var permission = query.ProjectTo<PermissionViewModel>(AutoMapperConfig.RegisterMapping()).ToList();

            return permission;
        }
    }
}
