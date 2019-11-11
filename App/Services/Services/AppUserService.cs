using AutoMapper;
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
    public class AppUserService : AppUserServiceInterface
    {
        private readonly IRepository<AppUser, Guid> _repository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public AppUserService(IRepository<AppUser, Guid> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        public List<AppUserViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(AppUserViewModel model)
        {
            throw new NotImplementedException();
        }

        public AppUserViewModel FindById(Guid id)
        {
            var appUser = _repository.FindById(id);

            var appUserMapper = _mapper.Map<AppUser, AppUserViewModel>(appUser);

            return appUserMapper;
        }


        public AppUser FindByIdNoMap(Guid id)
        {
            var appUser = _repository.FindById(id);

            return appUser;
        }
    }
}
