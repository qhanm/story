using story.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.Services.ServiceInterface
{
    public interface IAppUserRoleServiceInterface : IDisposable
    {
        AppUserRoleViewModel GetByUserId(Guid userId);

        void Add(AppUserRoleViewModel appUserRoleViewModel);

        void SaveChanges();
    }
}
