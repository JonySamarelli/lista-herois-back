using super_herois_api.Domain.Models;

namespace super_herois_api.Services
{
    public interface IServiceBase<T, D> where T : class where D : class
    {
        public List<T> Listar();
        public D Buscar(int id);
        public List<T> BuscarTodos(int id);
        public T Inserir(D dto);
        public T Atualizar(int id, D dto);
        public T Deletar(int id);
    }
}
