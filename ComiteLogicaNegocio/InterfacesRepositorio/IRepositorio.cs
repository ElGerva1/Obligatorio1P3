
namespace ComiteLogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorio <T>
    {
        void Add(T obj);
        T GetById(int id);
        IEnumerable<T> GetAll();

    }
}
