using System;
using System.Collections.Generic;
using System.Text;
using Boards.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Boards.Data.Seed
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            AddBoards(modelBuilder);
        }

        private static void AddBoards(ModelBuilder modelBuilder)
        {
            var records = SeedBoards.GetSeedBoards();

            foreach (var record in records)
            {
                modelBuilder.Entity<Board>().HasData
                (
                    record
                );
            }
        }
    }
}
