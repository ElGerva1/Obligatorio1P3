
namespace ComiteLogicaNegocio.InterfacesCasoUso
{
    public interface IObtenerTodos <T>
    {
        IEnumerable<T> Ejecutar();
    }
}
