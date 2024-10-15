
namespace ComiteCompartido.Dtos.Usuarios
{
    public record UsuarioListadoDto(
        int Id,
        string Email,
        string Password,
        string Discriminator
        )
    {
    }
}
