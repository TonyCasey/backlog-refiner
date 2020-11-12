using Microsoft.EntityFrameworkCore;
using Sts.Data.Entities;

namespace Sts.Data.Seed
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            AddUsers(modelBuilder);
            AddCompanies(modelBuilder);
            AddTeams(modelBuilder);
            AddTeamUsers(modelBuilder);
        }

        private static void AddUsers(ModelBuilder modelBuilder)
        {
            var records = UserSeed.GetSeedUsers();

            foreach (var record in records)
            {
                modelBuilder.Entity<User>().HasData
                (
                    record
                );
            }

        }

        private static void AddCompanies(ModelBuilder modelBuilder)
        {

            var records = CompanySeed.GetSeedCompanies();

            foreach (var record in records)
            {
                modelBuilder.Entity<Company>().HasData
                (
                    record
                );
            }

        }

        private static void AddTeams(ModelBuilder modelBuilder)
        {
            var records = TeamSeed.GetSeedTeams();

            foreach (var record in records)
            {
                modelBuilder.Entity<Team>().HasData
                (
                    record
                );
            }
        }

        private static void AddTeamUsers(ModelBuilder modelBuilder)
        {
            var records = TeamUsersSeed.GetSeedTeamUsers();

            foreach (var record in records)
            {
                modelBuilder.Entity<TeamUser>().HasData
                (
                    record
                );
            }
        }

    }
}
