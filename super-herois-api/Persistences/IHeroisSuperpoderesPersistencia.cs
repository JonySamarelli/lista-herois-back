using super_herois_api.Domain.DTOs;
using super_herois_api.Domain.Models;

namespace super_herois_api.Persistences
{
    public interface IHeroisSuperpoderesPersistencia : IPersistenciaBase<HeroisSuperpoderes>
    {
        public Task<List<HeroisSuperpoderes>> BuscarTodos(int id);
        public Task<bool> DeletarTodos(int heroiId);
        public Task<bool> Deletar(Superpoderes superpoder);
    }
}
