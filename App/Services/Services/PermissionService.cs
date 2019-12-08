using AutoMapper;
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
        private readonly RoleManager<AppRole> _roleManager;

        private readonly AppDbContext _appDbContext;

        private readonly IRepository<Permission, int> _repositoryPermission;

        private readonly IRepository<Function, string> _repositoryFunction;

        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public PermissionService(IRepository<Permission, int> repositoryPermission, IRepository<Function, string> repositoryFunction, AppDbContext appDbContext, 
            RoleManager<AppRole> roleManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repositoryFunction = repositoryFunction;
            _repositoryPermission = repositoryPermission; 
            _appDbContext = appDbContext;
            _roleManager = roleManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public void Add(PermissionViewModel permission)
        {
            var permssionModel = _mapper.Map<PermissionViewModel, Permission>(permission);

            _repositoryPermission.Add(permssionModel);
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

        public void DeleteByRoleId(Guid roelId)
        {
            List<PermissionViewModel> permissionViewModels = GetAll(roelId);

            List<Permission> permissions = _mapper.Map<List<PermissionViewModel>, List<Permission>>(permissionViewModels);

            _repositoryPermission.RemoveMulty(permissions);
            
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
                query = query.Where(x => x.RoleId == roleId);
            }

            var permission = query.ProjectTo<PermissionViewModel>(AutoMapperConfig.RegisterMapping()).ToList();

            return permission;
        }

        public bool IsUnique(string name, Guid roleId)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(PermissionViewModel permission)
        {
            var permissionModel = _mapper.Map<PermissionViewModel, Permission>(permission);

            _repositoryPermission.Update(permissionModel);
        }
    }
}
