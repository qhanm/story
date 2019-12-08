using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class AppUserRoleService : IAppUserRoleServiceInterface
    {
        private readonly AppDbContext _appDbContext;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public AppUserRoleService(AppDbContext appDbContext, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(AppUserRoleViewModel appUserRoleViewModel)
        {
            var modelMapper = _mapper.Map<AppUserRoleViewModel, AppUserRole>(appUserRoleViewModel);

            _appDbContext.AppUserRoles.Add(modelMapper);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public AppUserRoleViewModel GetByUserId(Guid userId)
        {
            var appUserRole = _appDbContext.AppUserRoles.Where(x => x.UserId.Equals(userId))
                                            .ProjectTo<AppUserRoleViewModel>(AutoMapperConfig.RegisterMapping())
                                            .FirstOrDefault();

            return appUserRole;
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
