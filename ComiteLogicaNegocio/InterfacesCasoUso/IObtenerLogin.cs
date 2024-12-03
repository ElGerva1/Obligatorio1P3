
namespace ComiteLogicaNegocio.InterfacesCasoUso
{
    public interface IObtenerLogin <T>
    {
        T Ejecutar(string email, string password);
    }
}
