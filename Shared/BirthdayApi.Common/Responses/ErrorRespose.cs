using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayApi.Common
{
    /// <summary>
    /// Класс для наших собственных исключений
    /// </summary>
    public class ErrorResponse
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public IEnumerable<ErrorResponseFieldInfo> FieldErrors { get; set; }

    }
    /// <summary>
    /// Класс для ошибок валидации, содержит имя поля и сообщение об ошибке
    /// </summary>
    public class ErrorResponseFieldInfo
    {
        public string FieldName { get; set; }
        public string Message { get; set; }
    }
}
