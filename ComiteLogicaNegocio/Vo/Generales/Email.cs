

using ComiteLogicaNegocio.Vo.Excepciones;


namespace ComiteLogicaNegocio.Vo.Generic
{
    public record Email
    {
        public string Value { get; set; }

        public Email(string value)
        {
            if (string.IsNullOrEmpty(value) )
            {
                throw new EmailException("El email no puede ser vacio");
            }
            this.Value = value; 
        }

    }
}
