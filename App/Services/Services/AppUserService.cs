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
using story.Extensions.Helpers.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.Services.Services
{
    public class AppUserService : IAppUserServiceInterface
    {


        private readonly AppDbContext _appDbContext;

        private readonly UserManager<AppUser> _userManager;

        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public AppUserService(AppDbContext appDbContext, UserManager<AppUser> userManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public AppUser Add(AppUserViewModel model)
        {
            var modelMapper = _mapper.Map<AppUserViewModel, AppUser>(model);

            _appDbContext.AppUsers.Add(modelMapper);

            return modelMapper;
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

        public PageResult<AppUserViewModel> GetAll(Status status, string search, int pageCurrent, int pageSize)
        {
            var query = _userManager.Users;

            if(status != Status.All)
            {
                query = query.Where(x => x.Status == status);
            }

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.UserName.Contains(search) || x.Email.Contains(search) || x.FullName.Contains(search) || x.PhoneNumber.Contains(search));
            }

            int totalRecord = query.Count();

            var result = query.ProjectTo<AppUserViewModel>(AutoMapperConfig.RegisterMapping())
                                .Skip((pageCurrent - 1) * pageSize).Take(pageSize).ToList();

            var pageResut = new PageResult<AppUserViewModel>
            {
                Results = result,
                PageCurrent = pageCurrent,
                PageSize = pageSize,
                TotalRecord = totalRecord
            };

            return pageResut;

        }

        public bool IsUnique(string value, string field)
        {
            var query = _userManager.Users;

            if(field == "email")
            {
                query = query.Where(x => x.Email == value);
            }

            if(field == "username")
            {
                query = query.Where(x => x.UserName == value);
            }

            var result = query.Count();

            if(result > 0)
            {
                return false;
            }

            return true;


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
    }
}
