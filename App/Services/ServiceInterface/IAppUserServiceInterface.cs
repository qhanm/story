using story.App.CodeFirstEntity.Entities;
using story.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.Services.ServiceInterface
{
    public interface IAppUserServiceInterface : IDisposable
    {
        void Add(AppUserViewModel model);

        void Update(AppUserViewModel model);

        void Delete(Guid id);

        AppUserViewModel FindById(Guid id);

        void SaveChanges();

        List<AppUserViewModel> GetAll();

        AppUser FindByIdNoMap(Guid id);
    }
}
