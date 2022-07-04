using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BirthdayApi.Context
{
    public class DbContextOptionsFactory
    {
        public static DbContextOptions<MainDbContext> Create(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<MainDbContext>();
            Configure(connectionString).Invoke(builder);
            return builder.Options;
        }

        public static Action<DbContextOptionsBuilder> Configure(string connectionString)
        {
            return (contextOptionsBuilder) => contextOptionsBuilder.UseSqlServer(connectionString);
        }
    }
}
