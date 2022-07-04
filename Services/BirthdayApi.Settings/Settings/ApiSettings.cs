using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayApi.Settings
{
    public class ApiSettings : IApiSettings
    {
        private readonly ISettingsSource source;
        private readonly IGeneralSettings generalSettings;
        private readonly IDbSettings dbSettings;
        private readonly IIdentitySettings identityServerSettings;

        public ApiSettings(ISettingsSource source) 
        {
            this.source = source;
        }

        public ApiSettings(ISettingsSource source, IGeneralSettings generalSettings, IDbSettings dbSettings, IIdentitySettings identityServerSettings)
        {
            this.source = source;
            this.generalSettings = generalSettings;
            this.dbSettings = dbSettings;
            this.identityServerSettings = identityServerSettings;
        }
        public IIdentitySettings IdentityServer => identityServerSettings ?? new IdentitySettings(source);
        public IGeneralSettings GeneralSettings => generalSettings ?? new GeneralSettings(source);

        public IDbSettings DbSettings => dbSettings ?? new DbSettings(source);
    }
}
