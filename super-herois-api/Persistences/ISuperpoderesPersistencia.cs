using super_herois_api.Domain.Models;

namespace super_herois_api.Persistences
{
    public interface ISuperpoderesPersistencia : IPersistenciaBase<Superpoderes>
    {
        public Task<List<Superpoderes>> BuscarTodos(int id);
    }
}
