using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayApi.Settings
{
    /// <summary>
    /// Тут хранятся все настройки связанык с Api
    /// </summary>
    public interface IApiSettings
    {
        IGeneralSettings GeneralSettings { get; }
        IDbSettings DbSettings { get; }
        IIdentitySettings IdentityServer { get; }
    }
}
