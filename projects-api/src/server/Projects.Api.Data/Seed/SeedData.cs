using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Projects.Api.Data.Entities;

namespace Projects.Api.Data.Seed
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            AddProjects(modelBuilder);
        }

        private static void AddProjects(ModelBuilder modelBuilder)
        {
            var records = SeedProjects.GetSeedProjects();

            foreach (var record in records)
            {
                modelBuilder.Entity<Project>().HasData
                (
                    record
                );
            }
        }
    }
}
