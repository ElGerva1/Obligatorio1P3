using ComiteLogicaNegocio.Excepciones.Usuario;

namespace ComiteLogicaNegocio.Entidades
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
 
    public Usuario(
           string email,
           string password)
    {

        Email = email;
        Password = password;
        Validar();
    }
    private void Validar()
    {
        ValidarEmail();
        ValidarPassword();
    }

    private void ValidarEmail()
    {
        if (string.IsNullOrEmpty(Email))
        {
            throw new EmailUsuarioInvalidoException("El mail no puede estar vacio.");
        }
    }

    private void ValidarPassword()
    {
        if (string.IsNullOrEmpty(Password))
        {
            throw new PasswordUsuarioInvalidoException("El mail no puede estar vacio.");
        }
    }
    }
}
