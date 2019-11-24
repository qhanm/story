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
            try
            {
                appDbContext.Database.EnsureCreated();

                AppUser appUser = new AppUser();

                if (appDbContext.AppUsers.Count() == 0)
                {
                    PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

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

                if (appDbContext.Functions.Count() == 0)
                {
                    appDbContext.Functions.AddRange(new List<Function>()
                    {
                        new Function() {Id = "SYSTEM", Name = "System",ParentId = null,SortOrder = 1,Status = Status.Active, Url = "/",IconCss = "fa-desktop"  },
                        new Function() {Id = "ROLE", Name = "Role",ParentId = "SYSTEM",SortOrder = 1,Status = Status.Active, Url = "/admin/role/index",IconCss = "fa-home"  },
                        new Function() {Id = "FUNCTION", Name = "Function",ParentId = "SYSTEM",SortOrder = 2,Status = Status.Active, Url = "/admin/function/index",IconCss = "fa-home"  },
                        new Function() {Id = "USER", Name = "User",ParentId = "SYSTEM",SortOrder =3,Status = Status.Active, Url = "/admin/user/index",IconCss = "fa-home"  },
                        new Function() {Id = "ACTIVITY", Name = "Activity",ParentId = "SYSTEM",SortOrder = 4,Status = Status.Active, Url = "/admin/activity/index",IconCss = "fa-home"  },
                        new Function() {Id = "ERROR", Name = "Error",ParentId = "SYSTEM",SortOrder = 5,Status = Status.Active, Url = "/admin/error/index",IconCss = "fa-home"  },
                        new Function() {Id = "SETTING", Name = "Configuration",ParentId = "SYSTEM",SortOrder = 6,Status = Status.Active, Url = "/admin/setting/index",IconCss = "fa-home"  },

                        new Function() {Id = "STORY", Name = "Story", ParentId = null, SortOrder = 1, Status = Status.Active, Url="/", IconCss = "null" },                    
                        new Function() {Id = "COUNTRY", Name = "Country", ParentId = "STORY", SortOrder = 3, Status = Status.Active, Url = "/admin/country/index", IconCss = ""},
                        new Function() {Id = "TRANSLATOR", Name = "Translator", ParentId = "STORY", SortOrder = 4, Status = Status.Active, Url = "/admin/translator", IconCss = "" },
                        new Function() {Id = "CATEGORY", Name = "Category", ParentId = "STORY", SortOrder = 5, Status = Status.Active, Url = "/admin/category/index", IconCss = ""},
                        new Function() {Id = "CHAPTER", Name = "Chapter", ParentId = "STORY", SortOrder = 6, Status = Status.Active, Url = "/admin/chapter/index", IconCss = ""},
                        new Function() {Id = "COMMENT", Name = "Comment", ParentId = "STORY", SortOrder = 7, Status = Status.Active, Url = "/admin/comment/index", IconCss = ""},

                        new Function() {Id = "MEDIA", Name = "Media", ParentId = null, SortOrder = 1, Status = Status.Active, Url = "/", IconCss = ""},
                        new Function() {Id = "IMAGE", Name = "Image", ParentId = "MEDIA", SortOrder = 1, Status = Status.Active, Url = "/admin/image/index", IconCss = ""},
                        new Function() {Id = "BANNER", Name = "Banner", ParentId = "MEDIA", SortOrder = 2, Status = Status.Active, Url = "/admin/banner/index", IconCss = ""}

                    });
                }

                AppRole appRole = new AppRole();

                if (appDbContext.AppRoles.Count() == 0)
                {
                    appRole.Name = "SuperAdmin";
                    appRole.Description = "This is super admin";
                    appRole.Status = Status.Active;
                    appDbContext.AppRoles.Add(appRole);
                }

                if (appDbContext.UserRoles.Count() == 0)
                {
                    //IdentityUserRole<Guid> role = new IdentityUserRole<Guid>();

                    //role.RoleId = appRole.Id;
                    //role.UserId = appUser.Id;

                    appDbContext.AppUserRoles.Add(new AppUserRole()
                    {
                        UserId = appUser.Id,
                        RoleId = appRole.Id
                    });
                }

                if (!appDbContext.Permisstions.Where(x => x.FunctionId.Contains("SYSTEM")).Any())
                {
                    appDbContext.Permisstions.AddRange(new List<Permission>()
                    {
                        new Permission() {Create = true, Read = true, Update = true, Delete = true, Approved = true, RoleId = appRole.Id, FunctionId = "SYSTEM"},
                        new Permission() {Create = true, Read = true, Update = true, Delete = true, Approved = true, RoleId = appRole.Id, FunctionId = "ROLE"},
                        new Permission() {Create = true, Read = true, Update = true, Delete = true, Approved = true, RoleId = appRole.Id, FunctionId = "FUNCTION"},
                        new Permission() {Create = true, Read = true, Update = true, Delete = true, Approved = true, RoleId = appRole.Id, FunctionId = "USER"},
                        new Permission() {Create = true, Read = true, Update = true, Delete = true, Approved = true, RoleId = appRole.Id, FunctionId = "ACTIVITY"},
                        new Permission() {Create = true, Read = true, Update = true, Delete = true, Approved = true, RoleId = appRole.Id, FunctionId = "ERROR"},
                        new Permission() {Create = true, Read = true, Update = true, Delete = true, Approved = true, RoleId = appRole.Id, FunctionId = "SETTING"},
                        new Permission() {Create = true, Read = true, Update = true, Delete = true, Approved = true, RoleId = appRole.Id, FunctionId = "STORY"},
                        new Permission() {Create = true, Read = true, Update = true, Delete = true, Approved = true, RoleId = appRole.Id, FunctionId = "COUNTRY"},
                        new Permission() {Create = true, Read = true, Update = true, Delete = true, Approved = true, RoleId = appRole.Id, FunctionId = "TRANSLATOR"},
                        new Permission() {Create = true, Read = true, Update = true, Delete = true, Approved = true, RoleId = appRole.Id, FunctionId = "CATEGORY"},
                        new Permission() {Create = true, Read = true, Update = true, Delete = true, Approved = true, RoleId = appRole.Id, FunctionId = "CHAPTER"},
                        new Permission() {Create = true, Read = true, Update = true, Delete = true, Approved = true, RoleId = appRole.Id, FunctionId = "COMMENT"},
                        new Permission() {Create = true, Read = true, Update = true, Delete = true, Approved = true, RoleId = appRole.Id, FunctionId = "MEDIA"},
                        new Permission() {Create = true, Read = true, Update = true, Delete = true, Approved = true, RoleId = appRole.Id, FunctionId = "IMAGE"},
                        new Permission() {Create = true, Read = true, Update = true, Delete = true, Approved = true, RoleId = appRole.Id, FunctionId = "BANNER"}
                    });

                 
                }

                appDbContext.SaveChanges();
            }
            catch(Exception exception)
            {
                exception.Message.ToString();
            }
        }
    }
}
