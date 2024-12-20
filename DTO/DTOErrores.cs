using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOErrores
    {
        public string Message { get; set; }

        public string StackTrace { get; set; }

        public string InnerException { get; set; }

        public DTOErrores() { }

        public DTOErrores(string message, string stackTrace, string innerException)
        {
            Message = message;
            StackTrace = stackTrace;
            InnerException = innerException;
        }
    }
}
