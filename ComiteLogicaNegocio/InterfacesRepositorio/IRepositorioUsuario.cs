using ComiteLogicaNegocio.Entidades;


namespace ComiteLogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        void Delete(Usuario obj);
        void Edit(Usuario obj);
        Usuario GetByEmail(string email);
    }
}
