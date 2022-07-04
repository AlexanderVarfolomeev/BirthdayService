using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayApi.Settings
{
    /// <summary>
    /// С помощью этого класса мы можем получать различные значения из файлов конфигурации
    /// </summary>
    public interface ISettingsSource
    {
        string GetConnectionString(string source = null);
        string GetAsString(string source, string defaultValue = null);
        bool GetAsBool(string source, bool defaultValue = false);
        int GetAsInt(string source, int defaultValue = 0);
    }
}
