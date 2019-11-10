using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;
using story.App.CodeFirstEntity.Entities;
using story.App.CodeFirstEntity.InterfaceGeneric;
using System;
//using System.IO;
using System.Linq;
//using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace story.App.CodeFirstEntity
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Banner> Banners { get; set; }

        public DbSet<BannerImage> BannerImages { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Chapter> Chapters { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Function> Functions { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<ImageMeta> ImageMetas { get; set; }

        public DbSet<KindStory> KindStories { get; set; }

        public DbSet<Permisstion> Permisstions { get; set; }

        public DbSet<AppRole> AppRoles { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Story> Stories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x => x.Id);

            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims").HasKey(x => x.Id);

            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.RoleId, x.UserId });

            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => new { x.UserId });

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (EntityEntry entity in modified)
            {
                var changeOrAddItem = entity.Entity as Date;

                if (changeOrAddItem != null)
                {
                    if (entity.State == EntityState.Added)
                    {
                        changeOrAddItem.DateCreated = DateTime.Now;
                    }
                    else if (entity.State == EntityState.Modified)
                    {
                        changeOrAddItem.DateUpdated = DateTime.Now;
                    }
                }
            }

            return base.SaveChanges();
        }
        //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        //{
        //    public AppDbContext CreateDbContext(string[] args)
        //    {
        //        IConfiguration configuration = new ConfigurationBuilder()
        //            .SetBasePath(Directory.GetCurrentDirectory())
        //            .AddJsonFile("appsettings.json").Build();
        //        var builder = new DbContextOptionsBuilder<AppDbContext>();
        //        var connectionString = configuration.GetConnectionString("DefaultConnection");
        //        builder.UseSqlServer(connectionString);
        //        return new AppDbContext(builder.Options);
        //    }
        //}
    }
}