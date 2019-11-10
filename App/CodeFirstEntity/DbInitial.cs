using Microsoft.AspNetCore.Identity;
using story.App.CodeFirstEntity.Constant;
using story.App.CodeFirstEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.CodeFirstEntity
{
    public class DbInitial
    {
        public static void Seeder(AppDbContext appDbContext)
        {
            appDbContext.Database.EnsureCreated();

            if (appDbContext.AppUsers.Count() == 0)
            {
                PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

                AppUser appUser = new AppUser();
                appUser.FullName = "Quach Hoai Nam";
                appUser.UserName = "qhnam.67";
                appUser.PasswordHash = passwordHasher.HashPassword(appUser.UserName, "123456!@#");
                appUser.NormalizedEmail = "QHNAM.67@GMAIL.COM";
                appUser.NormalizedUserName = "QHNAM.67";
                appUser.Email = "qhnam.67@gmail.com";
                appUser.SecurityStamp = "123abc";
                appUser.DateCreated = DateTime.Now;
                appUser.DateUpdated = DateTime.Now;
                appUser.Status = Status.Active;

                appDbContext.AppUsers.Add(appUser);

            }

            if(appDbContext.Functions.Count() == 0)
            {
                appDbContext.AddRange(new List<Function>()
                {
                    new Function() {Id = "SYSTEM", Name = "System",ParentId = null,SortOrder = 1,Status = Status.Active, Url = "/",IconCss = "fa-desktop"  },
                    new Function() {Id = "ROLE", Name = "Role",ParentId = "SYSTEM",SortOrder = 1,Status = Status.Active, Url = "/admin/role/index",IconCss = "fa-home"  },
                    new Function() {Id = "FUNCTION", Name = "Function",ParentId = "SYSTEM",SortOrder = 2,Status = Status.Active, Url = "/admin/function/index",IconCss = "fa-home"  },
                    new Function() {Id = "USER", Name = "User",ParentId = "SYSTEM",SortOrder =3,Status = Status.Active, Url = "/admin/user/index",IconCss = "fa-home"  },
                    new Function() {Id = "ACTIVITY", Name = "Activity",ParentId = "SYSTEM",SortOrder = 4,Status = Status.Active, Url = "/admin/activity/index",IconCss = "fa-home"  },
                    new Function() {Id = "ERROR", Name = "Error",ParentId = "SYSTEM",SortOrder = 5,Status = Status.Active, Url = "/admin/error/index",IconCss = "fa-home"  },
                    new Function() {Id = "SETTING", Name = "Configuration",ParentId = "SYSTEM",SortOrder = 6,Status = Status.Active, Url = "/admin/setting/index",IconCss = "fa-home"  },
                
                    new Function()
                });
            }

            appDbContext.SaveChanges();
        }
    }
}
