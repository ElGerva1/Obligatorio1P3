using ComiteLogicaNegocio.Entidades;


namespace ComiteLogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioDisciplina : IRepositorio<Disciplina>
    {
        Disciplina GetByName(string nombre);
        void Delete(Disciplina obj);

        void Edit(Disciplina obj);
    }
}
