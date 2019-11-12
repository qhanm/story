using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
    public class AppUserService : IAppUserServiceInterface
    {
        //private readonly IRepository<AppUser, Guid> _repository;

        //private readonly IUnitOfWork _unitOfWork;

        //private readonly IMapper _mapper;

        //public AppUserService(IRepository<AppUser, Guid> repository, IUnitOfWork unitOfWork, IMapper mapper)
        //{
        //    _repository = repository;
        //    _unitOfWork = unitOfWork;
        //    _mapper = mapper;
        //}

        //public void Add(AppUserViewModel model)
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

        //public List<AppUserViewModel> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public void SaveChanges()
        //{
        //    _unitOfWork.Commit();
        //}

        //public void Update(AppUserViewModel model)
        //{
        //    throw new NotImplementedException();
        //}

        //public AppUserViewModel FindById(Guid id)
        //{
        //    var appUser = _repository.FindById(id);

        //    var appUserMapper = _mapper.Map<AppUser, AppUserViewModel>(appUser);

        //    return appUserMapper;
        //}


        //public AppUser FindByIdNoMap(Guid id)
        //{
        //    var appUser = _repository.FindById(id);

        //    return appUser;
        //}

        private readonly AppDbContext _appDbContext;

        private UserManager<AppUser> _userManager;

        public AppUserService(AppDbContext appDbContext, UserManager<AppUser> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        public void Add(AppUserViewModel model)
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

        public AppUserViewModel FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public AppUser FindByIdNoMap(Guid id)
        {
            var appUser = _appDbContext.AppUsers.Where(x => x.Id.Equals(id)).FirstOrDefault();

            return appUser;
        }

        public List<AppUserViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(AppUserViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
