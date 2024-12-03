using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ComiteAccesoADatos.Excepciones
{
    public class EventoException : Exception
    {
        public EventoException()
        {
        }

        public EventoException(string? message) : base(message)
        {
        }

        public EventoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EventoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
