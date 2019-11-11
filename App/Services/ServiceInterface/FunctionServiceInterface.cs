using story.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.Services.ServiceInterface
{
    public interface FunctionServiceInterface : IDisposable
    {
        void Add(FunctionViewModel model);

        void Update(FunctionViewModel model);

        void Delete(string id);

        FunctionViewModel FindById(string id);

        List<FunctionViewModel> FindAll();

        Task<List<FunctionViewModel>> FindAllAsync();

        void SaveChanges();
    }
}