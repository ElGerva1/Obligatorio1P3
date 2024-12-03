
namespace WebCliente.Models.Dtos.Usuarios
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
