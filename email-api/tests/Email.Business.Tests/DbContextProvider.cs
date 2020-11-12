using Email.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Email.Business.Tests
{
    public static class DbContextProvider
    {
        public static ApplicationDbContext GetInMemoryDbContext() =>
            new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("Business.Tests").Options);
    }
}
