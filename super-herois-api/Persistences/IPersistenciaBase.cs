using super_herois_api.Domain.Models;

namespace super_herois_api.Persistences
{
    public interface IPersistenciaBase<T> where T : class
    {
        public Task<List<T>> Listar();
        public Task<T> Buscar(int id);
        public Task<T> Inserir(T entity);
        public Task<T> Atualizar(int id, T entity);
        public Task<T> Deletar(int id);
    }
}
