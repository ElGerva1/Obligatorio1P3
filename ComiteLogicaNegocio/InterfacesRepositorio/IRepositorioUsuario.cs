using ComiteLogicaNegocio.Entidades;


namespace ComiteLogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        Usuario GetByEmail(string email);
    }
}
