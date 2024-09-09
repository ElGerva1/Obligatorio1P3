using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ComiteLogicaNegocio.Excepciones
{
    public class LogicaNegocioException : Exception
    {
        public LogicaNegocioException()
        {
        }

        public LogicaNegocioException(string? message) : base(message)
        {
        }

        public LogicaNegocioException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected LogicaNegocioException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
