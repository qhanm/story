using story.App.CodeFirstEntity.Constant;
using story.App.CodeFirstEntity.Entities;
using story.App.Model;
using story.Extensions.Helpers.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.Services.ServiceInterface
{
    public interface IAppUserServiceInterface : IDisposable
    {
        AppUser Add(AppUserViewModel model);

        void Update(AppUserViewModel model);

        void Delete(Guid id);

        AppUserViewModel FindById(Guid id);

        void SaveChanges();

        List<AppUserViewModel> GetAll();

        AppUser FindByIdNoMap(Guid id);

        PageResult<AppUserViewModel> GetAll(Status status, string search, int pageCurrent, int pageSize);

        bool IsUnique(string value, string field);
    }
}
