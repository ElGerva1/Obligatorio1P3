using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ComiteAccesoADatos.Excepciones
{
    public class DisciplinaException : Exception
    {
        public DisciplinaException()
        {
        }

        public DisciplinaException(string? message) : base(message)
        {
        }

        public DisciplinaException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DisciplinaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
