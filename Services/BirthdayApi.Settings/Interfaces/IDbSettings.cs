using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayApi.Settings
{
    /// <summary>
    /// Тут хранятся различные настройки связанные с бд
    /// </summary>
    public interface IDbSettings
    {
        string GetConnectionString { get; }
    }
}
