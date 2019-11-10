﻿using story.App.CodeFirstEntity.Entities;
using story.App.Model;
using story.App.Services.Repositories;
using story.App.Services.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.Services.Services
{
    public class AppRoleService : AppRoleServiceInterface
    {

        private readonly IRepository<AppRole, Guid> _repository;

        private readonly IUnitOfWork _unitOfWork;

        public AppRoleService(IRepository<AppRole, Guid> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AppRoleViewModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public AppRoleViewModel FindId(Guid? id)
        {
            throw new NotImplementedException();
        }

        public List<AppRoleViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveChange()
        {
            throw new NotImplementedException();
        }

        public void Update(AppRoleViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}