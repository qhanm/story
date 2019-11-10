using story.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.Services.ServiceInterface
{
    public interface AppRoleServiceInterface : IDisposable
    {
        void Add(AppRoleViewModel model);

        void Update(AppRoleViewModel model);

        // find 
        AppRoleViewModel FindId(Guid ?id);

        List<AppRoleViewModel> GetAll();

        void SaveChange();

        void Delete(Guid id);
    }
}
