using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using story.App.AutoMapper;
using story.App.CodeFirstEntity;
using story.App.CodeFirstEntity.Constant;
using story.App.CodeFirstEntity.Entities;
using story.App.Model;
using story.App.Services.Repositories;
using story.App.Services.ServiceInterface;
using story.Extensions.Constants;
using story.Extensions.Helpers.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.Services.Services
{
    public class AppRoleService : IAppRoleServiceInterface
    {

        private readonly AppDbContext _appDbContext;

        private RoleManager<AppRole> _roleManager;

        private IMapper _mapper;

        //private IRepository<AppRole, Guid> _repository;

        private IUnitOfWork _unitOfWork;

        public AppRoleService(AppDbContext appDbContext, RoleManager<AppRole> roleManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _appDbContext = appDbContext;
            _roleManager = roleManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public AppRole Add(AppRoleViewModel model)
        {
            var appRole = _mapper.Map<AppRoleViewModel, AppRole>(model);
            _appDbContext.AppRoles.Add(appRole);
            return appRole;
        }

        public void Delete(Guid id)
        {
            
        }

        public void Delete(AppRoleViewModel appRoleViewModel)
        {
            var modelAppRole = _mapper.Map<AppRoleViewModel, AppRole>(appRoleViewModel);

            _appDbContext.AppRoles.Remove(modelAppRole);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public AppRoleViewModel FindId(Guid id)
        {
            var role = _appDbContext.AppRoles.Where(x => x.Id == id).ProjectTo<AppRoleViewModel>(AutoMapperConfig.RegisterMapping()).FirstOrDefault();

            return role;
        }

        public List<AppRoleViewModel> GetAll()
        {
            var roles = _appDbContext.AppRoles.OrderBy(x => x.Id).ProjectTo<AppRoleViewModel>(AutoMapperConfig.RegisterMapping()).ToList();

            //var roles = _repository.FindAll().OrderBy(x => x.Id).ProjectTo<AppRoleViewModel>(AutoMapperConfig.RegisterMapping()).ToList();

            return roles;
        }

        public PageResult<AppRoleViewModel> GetAll(Status status, string search, int pageCurrent, int pageSize)
        {
            var query = _roleManager.Roles;

            if(status != Status.All)
            {
                query = query.Where(x => x.Status == status);
            }

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Name.Contains(search) || x.Description.Contains(search));
            }

            int totalPage = query.Count();

            query = query.Skip((pageCurrent - 1) * pageSize).Take(pageSize);

            

            var resutl = query.ProjectTo<AppRoleViewModel>(AutoMapperConfig.RegisterMapping()).ToList();

            var pageResult = new PageResult<AppRoleViewModel>()
            {
                PageCurrent = pageCurrent,
                TotalPage = totalPage,
                Results = resutl,
                PageSize = pageSize,
            };

            return pageResult;
        }

        public bool IsUnique(string name, Guid roleId)
        {
            var query = _appDbContext.AppRoles.Where(x => x.Name.Equals(name));

            var guidDefault = default(Guid);

            // is updated
            if (roleId != guidDefault)
            {
                var role = FindId(roleId);

                query = _appDbContext.AppRoles.Where(x => x.Name.Equals(name) && !x.Name.Equals(role.Name));
            }

            if(query.Count() > 0)
            {
                return false;
            }

            return true;
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public AppRole Update(AppRoleViewModel model)
        {
            var appRole = _mapper.Map<AppRoleViewModel, AppRole>(model);

            _appDbContext.AppRoles.Update(appRole);
            return appRole;
        }
    }
}
