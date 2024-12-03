
namespace WebCliente.Models.Dtos.Usuarios
{
    public record UsuarioAltaDto (
        int Id,
        string Email,
        string Password,
        string Discriminator
        )
    {
    }
}
