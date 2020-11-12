using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Tickets.Api.Data.Entities;

namespace Tickets.Api.Data.Seed
{
    public static class SeedTickets
    {
        public static List<Ticket> GetSeedTickets()
        {
            List<Ticket> tickets = new List<Ticket>()
            {
                new Ticket()
                {
                    Summary = "Ticket number 1",
                    Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam venenatis massa eu lorem rutrum scelerisque. Aliquam quis faucibus dui. Morbi eu diam condimentum, aliquet lorem eget, convallis augue. Nam a nisi at est elementum dignissim. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Cras in magna ac mauris eleifend imperdiet sit amet in purus. Phasellus eu mi arcu. Etiam a tempus lectus. In hac habitasse platea dictumst. Fusce viverra sed metus id pretium. Proin auctor enim eu massa fringilla, at vestibulum lacus egestas.

In hac habitasse platea dictumst. Phasellus non semper nisi. Proin consequat, ante et pretium imperdiet, velit augue congue leo, consectetur euismod turpis tellus nec felis. Quisque tempor id libero et maximus. In ullamcorper dolor leo, quis tempus sapien auctor id. Sed eget augue vel augue accumsan ornare. Aliquam ac felis a elit bibendum malesuada at eget arcu. Mauris id tempus lacus. Aenean volutpat tristique sem quis interdum. Cras eu eros at lorem tincidunt pharetra vel ac tortor. Donec non suscipit arcu. Maecenas luctus, eros sodales iaculis feugiat, nisl massa venenatis velit, ullamcorper vulputate quam nisi a dui. Aenean posuere, risus quis lobortis dictum, nisi erat mattis odio, eu porttitor massa neque vel ligula. Mauris et pretium justo, id gravida neque.",
                    Guid = Guid.NewGuid(),
                    CreationTime = DateTime.Now,
                    CreationUserGuid = new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff"),
                    UserGuid = new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff"),
                    CompanyGuid = new Guid("22e44764-3f21-471f-8f18-ae43d613c8cd"),
                    BoardGuid = new Guid("c131073d-cbd5-4b26-bbda-99eda8392a46"),
                    StatusGuid = new Guid("0ad8d818-cea5-4401-a851-614f37133ed1")

                },
                new Ticket()
                {
                    Summary = "Ticket number 2",
                    Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam venenatis massa eu lorem rutrum scelerisque. Aliquam quis faucibus dui. Morbi eu diam condimentum, aliquet lorem eget, convallis augue. Nam a nisi at est elementum dignissim. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Cras in magna ac mauris eleifend imperdiet sit amet in purus. Phasellus eu mi arcu. Etiam a tempus lectus. In hac habitasse platea dictumst. Fusce viverra sed metus id pretium. Proin auctor enim eu massa fringilla, at vestibulum lacus egestas.

In hac habitasse platea dictumst. Phasellus non semper nisi. Proin consequat, ante et pretium imperdiet, velit augue congue leo, consectetur euismod turpis tellus nec felis. Quisque tempor id libero et maximus. In ullamcorper dolor leo, quis tempus sapien auctor id. Sed eget augue vel augue accumsan ornare. Aliquam ac felis a elit bibendum malesuada at eget arcu. Mauris id tempus lacus. Aenean volutpat tristique sem quis interdum. Cras eu eros at lorem tincidunt pharetra vel ac tortor. Donec non suscipit arcu. Maecenas luctus, eros sodales iaculis feugiat, nisl massa venenatis velit, ullamcorper vulputate quam nisi a dui. Aenean posuere, risus quis lobortis dictum, nisi erat mattis odio, eu porttitor massa neque vel ligula. Mauris et pretium justo, id gravida neque.",
                    Guid = Guid.NewGuid(),
                    CreationTime = DateTime.Now,
                    CreationUserGuid = new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff"),
                    UserGuid = new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff"),
                    CompanyGuid = new Guid("22e44764-3f21-471f-8f18-ae43d613c8cd"),
                    BoardGuid = new Guid("c131073d-cbd5-4b26-bbda-99eda8392a46"),
                    StatusGuid = new Guid("0ad8d818-cea5-4401-a851-614f37133ed1")

                },
                new Ticket()
                {
                    Summary = "Ticket number 3",
                    Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam venenatis massa eu lorem rutrum scelerisque. Aliquam quis faucibus dui. Morbi eu diam condimentum, aliquet lorem eget, convallis augue. Nam a nisi at est elementum dignissim. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Cras in magna ac mauris eleifend imperdiet sit amet in purus. Phasellus eu mi arcu. Etiam a tempus lectus. In hac habitasse platea dictumst. Fusce viverra sed metus id pretium. Proin auctor enim eu massa fringilla, at vestibulum lacus egestas.

In hac habitasse platea dictumst. Phasellus non semper nisi. Proin consequat, ante et pretium imperdiet, velit augue congue leo, consectetur euismod turpis tellus nec felis. Quisque tempor id libero et maximus. In ullamcorper dolor leo, quis tempus sapien auctor id. Sed eget augue vel augue accumsan ornare. Aliquam ac felis a elit bibendum malesuada at eget arcu. Mauris id tempus lacus. Aenean volutpat tristique sem quis interdum. Cras eu eros at lorem tincidunt pharetra vel ac tortor. Donec non suscipit arcu. Maecenas luctus, eros sodales iaculis feugiat, nisl massa venenatis velit, ullamcorper vulputate quam nisi a dui. Aenean posuere, risus quis lobortis dictum, nisi erat mattis odio, eu porttitor massa neque vel ligula. Mauris et pretium justo, id gravida neque.",
                    Guid = Guid.NewGuid(),
                    CreationTime = DateTime.Now,
                    CreationUserGuid = new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff"),
                    UserGuid = new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff"),
                    CompanyGuid = new Guid("3272d072-ac00-4d3a-8d3a-40a14d8d789d"),
                    BoardGuid = new Guid("48c85d34-1345-4363-93b7-f2d2785bf07e"),
                    StatusGuid = new Guid("0ad8d818-cea5-4401-a851-614f37133ed9")

                },
                new Ticket()
                {
                    Summary = "Ticket number 4",
                    Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam venenatis massa eu lorem rutrum scelerisque. Aliquam quis faucibus dui. Morbi eu diam condimentum, aliquet lorem eget, convallis augue. Nam a nisi at est elementum dignissim. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Cras in magna ac mauris eleifend imperdiet sit amet in purus. Phasellus eu mi arcu. Etiam a tempus lectus. In hac habitasse platea dictumst. Fusce viverra sed metus id pretium. Proin auctor enim eu massa fringilla, at vestibulum lacus egestas.

In hac habitasse platea dictumst. Phasellus non semper nisi. Proin consequat, ante et pretium imperdiet, velit augue congue leo, consectetur euismod turpis tellus nec felis. Quisque tempor id libero et maximus. In ullamcorper dolor leo, quis tempus sapien auctor id. Sed eget augue vel augue accumsan ornare. Aliquam ac felis a elit bibendum malesuada at eget arcu. Mauris id tempus lacus. Aenean volutpat tristique sem quis interdum. Cras eu eros at lorem tincidunt pharetra vel ac tortor. Donec non suscipit arcu. Maecenas luctus, eros sodales iaculis feugiat, nisl massa venenatis velit, ullamcorper vulputate quam nisi a dui. Aenean posuere, risus quis lobortis dictum, nisi erat mattis odio, eu porttitor massa neque vel ligula. Mauris et pretium justo, id gravida neque.",
                    Guid = Guid.NewGuid(),
                    CreationTime = DateTime.Now,
                    CreationUserGuid = new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff"),
                    UserGuid = new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff"),
                    CompanyGuid = new Guid("3272d072-ac00-4d3a-8d3a-40a14d8d789d"),
                    BoardGuid = new Guid("48c85d34-1345-4363-93b7-f2d2785bf07e"),
                    StatusGuid = new Guid("0ad8d818-cea5-4401-a851-614f37133ed1")

                }
            };

            int index = 1;
            foreach (Ticket record in tickets)
            {
                record.TicketId = index;
                ++index;
            }

            return tickets;
        }
    }
}
