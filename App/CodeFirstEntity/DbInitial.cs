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

            appDbContext.SaveChanges();
        }
    }
}
