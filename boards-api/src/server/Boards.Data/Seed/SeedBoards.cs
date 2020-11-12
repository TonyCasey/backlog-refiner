using System;
using System.Collections.Generic;
using System.Text;
using Boards.Data.Entities;

namespace Boards.Data.Seed
{
    public static class SeedBoards
    {
        public static List<Board> GetSeedBoards()
        {
            List<Board> records = new List<Board>()
            {
                new Board()
                {
                    Guid = new Guid("B3BBD835-EBF5-41A6-97D7-DAE7D27B86CD"),
                    CreationTime = DateTime.Now,
                    CreationUserGuid = new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff"),
                    UserGuid = new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff"),
                    CompanyGuid = new Guid("22e44764-3f21-471f-8f18-ae43d613c8cd"),
                    TeamGuid = new Guid("BE677A6E-A993-4AE3-9F11-82E4FC3B881F"),
                    Name = "BR Board 1",
                },
                new Board()
                {
                    Guid = new Guid("37286062-00A5-4023-9A8C-777AEB037ED7"),
                    CreationTime = DateTime.Now,
                    CreationUserGuid = new Guid("9922826F-8490-4C04-8F36-07115C6193B5"),
                    UserGuid = new Guid("9922826F-8490-4C04-8F36-07115C6193B5"),
                    CompanyGuid = new Guid("3272D072-AC00-4D3A-8D3A-40A14D8D789D"),
                    TeamGuid = new Guid("A640AD1F-F981-4FCF-B126-81DB36AE3A24"),
                    Name = "Retailer Engineering Board",
                }
            };

            int index = 1;
            foreach (var record in records)
            {
                record.BoardId = index;
                ++index;
            }

            return records;
        }
    }
}
