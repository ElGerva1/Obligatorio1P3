using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ComiteLogicaNegocio.Excepciones.Usuario
{
    public class UsuarioException : LogicaNegocioException
    {
        public UsuarioException()
        {
        }

        public UsuarioException(string? message) : base(message)
        {
        }

        public UsuarioException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UsuarioException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
