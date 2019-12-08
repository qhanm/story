using story.App.CodeFirstEntity.Constant;
using story.App.CodeFirstEntity.Entities;
using story.App.Model;
using story.Extensions.Constants;
using story.Extensions.Helpers.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.Services.ServiceInterface
{
    public interface IAppRoleServiceInterface : IDisposable
    {
        AppRole Add(AppRoleViewModel model);

        AppRole Update(AppRoleViewModel model);

        // find 
        AppRoleViewModel FindId(Guid id);

        List<AppRoleViewModel> GetAll();

        PageResult<AppRoleViewModel> GetAll(Status status, string search, int pageCurrent, int pageSize);

        void SaveChange();

        void Delete(Guid id);

        void Delete(AppRoleViewModel appRoleViewModel);

        bool IsUnique(string name, Guid roleId);
    }
}
