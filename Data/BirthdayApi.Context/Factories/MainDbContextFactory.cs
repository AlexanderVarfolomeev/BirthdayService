using Microsoft.EntityFrameworkCore;

namespace BirthdayApi.Context
{
    public class MainDbContextFactory
    {
        private readonly DbContextOptions<MainDbContext> opts;

        public MainDbContextFactory(DbContextOptions<MainDbContext> opts)
        {
            this.opts = opts;
        }

        public MainDbContext Create()
        {
            return new MainDbContext(opts);
        }
    }
}
