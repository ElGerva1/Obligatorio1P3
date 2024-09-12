

using ComiteLogicaNegocio.Vo.Excepciones;


namespace ComiteLogicaNegocio.Vo.Generic
{
    public record Password
    {
        public string Value { get; set; }

        public Password(string value)
        {
            if (string.IsNullOrEmpty(value) )
            {
                throw new PasswordException("La contraseña no puede ser vacia");
            }
            this.Value = value; 
        }

    }
}
