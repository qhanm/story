using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using story.App.AutoMapper;
using story.App.CodeFirstEntity;
using story.App.CodeFirstEntity.Entities;
using story.App.Model;
using story.App.Services.Repositories;
using story.App.Services.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.Services.Services
{
    public class AppRoleService : IAppRoleServiceInterface
    {

        //private readonly IRepository<AppRole, Guid> _repository;

        //private readonly IUnitOfWork _unitOfWork;

        //public AppRoleService(IRepository<AppRole, Guid> repository, IUnitOfWork unitOfWork)
        //{
        //    _repository = repository;
        //    _unitOfWork = unitOfWork;
        //}

        //public void Add(AppRoleViewModel model)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Dispose()
        //{
        //    GC.SuppressFinalize(this);
        //}

        //public AppRoleViewModel FindId(Guid? id)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<AppRoleViewModel> GetAll()
        //{
        //    var appRoles = _repository.FindAll()
        //                              .OrderBy(x => x.DateUpdated)
        //                              .ProjectTo<AppRoleViewModel>(AutoMapperConfig.RegisterMapping())
        //                              .ToList();
        //    return appRoles;
        //}

        //public void SaveChange()
        //{
        //    _unitOfWork.Commit();
        //}

        //public void Update(AppRoleViewModel model)
        //{
        //    throw new NotImplementedException();
        //}

        private readonly AppDbContext _appDbContext;

        private RoleManager<AppRole> _roleManager;

        public AppRoleService(AppDbContext appDbContext, RoleManager<AppRole> roleManager)
        {
            _appDbContext = appDbContext;
            _roleManager = roleManager;
        }

        public void Add(AppRoleViewModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public AppRoleViewModel FindId(Guid id)
        {
            //var role = _appDbContext.AppUserRoles.Where(x => x.UserId)
            throw new NotImplementedException();
        }

        public List<AppRoleViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveChange()
        {
            throw new NotImplementedException();
        }

        public void Update(AppRoleViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
