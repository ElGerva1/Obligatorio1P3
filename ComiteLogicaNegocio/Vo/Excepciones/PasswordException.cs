using ComiteLogicaNegocio.Excepciones;
using System;

namespace ComiteLogicaNegocio.Vo.Excepciones
{
    public class PasswordException : LogicaNegocioException
    {
        public PasswordException()
        {
        }

        public PasswordException(string? message) : base(message)
        {
        }

        public PasswordException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}
