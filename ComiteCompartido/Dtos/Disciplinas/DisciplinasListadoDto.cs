
namespace ComiteCompartido.Dtos.Disciplinas
{
    public record DisciplinasListadoDto(
        int Id,
        string Email,
        string Password,
        string Discriminator
        )
    {
    }
}
