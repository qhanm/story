using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.Services.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
