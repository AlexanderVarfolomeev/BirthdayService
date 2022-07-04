using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayApi.Settings
{
    /// <summary>
    /// Тут можно хранить различные переменные из файла конфигурации
    /// </summary>
    public interface IGeneralSettings
    {
        bool SwaggerVisible { get; }
    }
}
