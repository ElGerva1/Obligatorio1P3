
namespace ComiteLogicaNegocio.InterfacesCasoUso
{
    public interface IObtener <T>
    {
        T Ejecutar(int id);
        T Ejecutar(string email);
    }
}
