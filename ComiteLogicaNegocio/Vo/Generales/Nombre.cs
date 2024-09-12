

using ComiteLogicaNegocio.Vo.Excepciones;


namespace ComiteLogicaNegocio.Vo.Generic
{
    public record Nombre
    {
        public string Value { get; set; }

        public Nombre(string value)
        {
            if (string.IsNullOrEmpty(value) )
            {
                throw new NombreException("El nombre no puede ser vacio");
            }
            this.Value = value; 
        }

    }
}
