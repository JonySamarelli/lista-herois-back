using super_herois_api.Domain.Models;

namespace super_herois_api.Persistences
{
    public interface IHeroiPersistencia : IPersistenciaBase<Herois>
    {
        public Task<List<Herois>> BuscarTodos(int id);
        public Task<List<Herois>> BuscaNomeHeroi(string nomeHeroi);
    }
}
