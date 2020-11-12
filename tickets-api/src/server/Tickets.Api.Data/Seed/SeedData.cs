using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Tickets.Api.Data.Entities;

namespace Tickets.Api.Data.Seed
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            AddTickets(modelBuilder);
        }

        private static void AddTickets(ModelBuilder modelBuilder)
        {
            List<Ticket> tickets = SeedTickets.GetSeedTickets();

            foreach (Ticket record in tickets)
            {
                modelBuilder.Entity<Ticket>().HasData
                (
                    record
                );
            }

        }
    }
}
