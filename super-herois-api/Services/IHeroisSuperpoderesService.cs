using super_herois_api.Domain.DTOs;
using super_herois_api.Domain.Models;

namespace super_herois_api.Services
{
    public interface IHeroisSuperpoderesService : IServiceBase<HeroisSuperpoderes, HeroisSuperpoderes>
    {
        public bool DeletarTodos(int heroiId);
        public bool Deletar(Superpoderes superpoder);
    }
}
