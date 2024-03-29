﻿using story.App.CodeFirstEntity.Entities;
using story.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.Services.ServiceInterface
{
    public interface IPermissionServiceInterface : IDisposable
    {
        bool CheckPermission(string functionId, string action, string[] roles);

        List<PermissionViewModel> GetAll(Guid? roleId);

        void Add(PermissionViewModel permission);

        void SaveChanges();

        void Update(PermissionViewModel permission);

        bool IsUnique(string name, Guid roleId);

        void DeleteByRoleId(Guid roelId);
    }
}
