using ComiteLogicaNegocio.Excepciones;
using System;

namespace ComiteLogicaNegocio.Vo.Excepciones
{
    public class EmailException : LogicaNegocioException
    {
        public EmailException()
        {
        }

        public EmailException(string? message) : base(message)
        {
        }

        public EmailException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}
