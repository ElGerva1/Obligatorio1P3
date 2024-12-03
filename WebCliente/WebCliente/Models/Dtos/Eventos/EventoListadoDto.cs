namespace WebCliente.Models.Dtos.Eventos
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string NombreDisciplina { get; set; }
        public string Nombre { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public List<PuntajeDto> Puntajes { get; set; }
    }

    public class PuntajeDto
    {
        public AtletaDto Atleta { get; set; }
        public decimal Puntaje { get; set; }
    }

    public class AtletaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public int PaisId { get; set; }
        public List<int> DisciplinasIds { get; set; }
    }
}
