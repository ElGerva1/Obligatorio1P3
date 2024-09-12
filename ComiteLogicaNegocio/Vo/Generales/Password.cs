

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
                throw new PasswordException("El nombre no puede ser vacio");
            }
            this.Value = value; 
        }

    }
}
