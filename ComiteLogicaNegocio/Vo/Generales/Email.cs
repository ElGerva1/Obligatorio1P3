

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
            if (value.IndexOf('@') == -1)
            {
                throw new EmailException("Su email debe tener @");
            }
            if (value.IndexOf('@') == 0)
            {
                throw new EmailException("Su email no puede empezar con @");
            }
            if (value.IndexOf('@') == value.Length - 1)
            {
                throw new EmailException("Su email no puede terminar con @");
            }
            if (value.IndexOf('@') != value.LastIndexOf('@'))
            {
                throw new EmailException("Su email no puede tener mas de un @");
            }

            this.Value = value; 
        }

    }
}
