namespace ComiteLogicaNegocio.Excepciones.Usuario
{
    public class EmailUsuarioInvalidoException : UsuarioException
    {
        public EmailUsuarioInvalidoException()
        {
        }

        public EmailUsuarioInvalidoException(string? message) : base(message)
        {
        }

        public EmailUsuarioInvalidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
