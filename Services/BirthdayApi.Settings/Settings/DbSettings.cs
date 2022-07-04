using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayApi.Settings
{
    public class DbSettings : IDbSettings
    {
        private readonly ISettingsSource source;

        public DbSettings(ISettingsSource source)
        {
            this.source = source;
        }
        public string GetConnectionString => source.GetConnectionString("MainConnectionString");
    }
}
