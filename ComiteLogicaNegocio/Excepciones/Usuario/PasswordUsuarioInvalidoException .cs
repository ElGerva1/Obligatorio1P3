namespace ComiteLogicaNegocio.Excepciones.Usuario
{
    public class PasswordUsuarioInvalidoException : UsuarioException
    {
        public PasswordUsuarioInvalidoException()
        {
        }

        public PasswordUsuarioInvalidoException(string? message) : base(message)
        {
        }

        public PasswordUsuarioInvalidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
