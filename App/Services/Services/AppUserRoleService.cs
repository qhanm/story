using AutoMapper.QueryableExtensions;
using story.App.AutoMapper;
using story.App.CodeFirstEntity;
using story.App.Model;
using story.App.Services.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.Services.Services
{
    public class AppUserRoleService : IAppUserRoleServiceInterface
    {
        private AppDbContext _appDbContext;

        public AppUserRoleService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
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
    }
}
