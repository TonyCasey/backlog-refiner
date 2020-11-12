using System;
using System.Linq;
using Sts.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sts.Data.Seed;

namespace Sts.Data.EntityFramework
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamUser> TeamUsers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// SaveChanges with AddUserAndTimestamp extension
        /// Fills CreationTime, CreationUser, LastUpdateTime, LastUpdateUser fields
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            AddUserAndTimestamp();
            try
            {
                return base.SaveChanges();
            }
            catch (Exception e)
            {
                //Logger = LogManager.GetCurrentClassLogger();
                //Logger<>.Error(e.Message);
                //Logger<>.Error(e.InnerException);
                throw e;
            }
        }

        /// <summary>
        /// Fills CreationTime, CreationUser, LastUpdateTime, LastUpdateUser fields of the entity that is BaseEntity
        /// </summary>
        private void AddUserAndTimestamp()
        {
            var entities = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Modified || e.State == EntityState.Added));


            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreationTime = DateTime.UtcNow;
                }
                else
                {
                    ((BaseEntity)entity.Entity).LastUpdateTime = DateTime.UtcNow;
                }
            }
        }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {

            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            SeedData.Seed(modelbuilder);

            base.OnModelCreating(modelbuilder);
        }
    }
}
