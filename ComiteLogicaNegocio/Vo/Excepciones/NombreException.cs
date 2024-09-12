using ComiteLogicaNegocio.Excepciones;
using System;

namespace ComiteLogicaNegocio.Vo.Excepciones
{
    public class NombreException : LogicaNegocioException
    {
        public NombreException()
        {
        }

        public NombreException(string? message) : base(message)
        {
        }

        public NombreException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}
