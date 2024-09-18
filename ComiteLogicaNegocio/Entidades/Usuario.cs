using ComiteLogicaNegocio.Excepciones.Usuario;
using ComiteLogicaNegocio.Vo.Generic;

namespace ComiteLogicaNegocio.Entidades
{
    public class Usuario
    {
        private string email;
        private string password;

        public int ID { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
    protected Usuario() { }
    public Usuario(int id,
           Email email,
           Password password)
    {

        Email = email;
        Password = password;
        Validar();
    }


        private void Validar()
    {
    }

    }
}