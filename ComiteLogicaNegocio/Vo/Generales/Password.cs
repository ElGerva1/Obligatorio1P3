

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
            if (value.Length < 6)
            {
                throw new PasswordException("La contraseña no puede ser menor a 6 caracteres");
            }
            if (value.Any(char.IsUpper) == false)
            {
                throw new PasswordException("La contraseña debe contener una mayuscula");
            }
            if (value.Any(char.IsLower) == false)
            {
                throw new PasswordException("La contraseña debe contener una minuscula");
            }
            if (value.Any(char.IsDigit) == false)
            {
                throw new PasswordException("La contraseña debe contener un digito especial");
            }
            if (value.Any(char.IsPunctuation) == false)
            {
                throw new PasswordException("La contraseña debe contener un caracter de puntuacion");
            }
            this.Value = value; 
        }

    }
}
