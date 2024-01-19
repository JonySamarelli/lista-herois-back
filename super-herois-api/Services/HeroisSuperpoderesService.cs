using super_herois_api.Domain.DTOs;
using super_herois_api.Domain.Models;
using super_herois_api.Persistences;

namespace super_herois_api.Services
{
    public class HeroisSuperpoderesService : IHeroisSuperpoderesService
    {
        private readonly IHeroisSuperpoderesPersistencia _persistencia;
        public HeroisSuperpoderesService(IHeroisSuperpoderesPersistencia persistencia)
        {
            _persistencia = persistencia;
        }
        public List<HeroisSuperpoderes> Listar()
        {
            return _persistencia.Listar().Result;
        }

        public HeroisSuperpoderes Buscar(int id)
        {
            return _persistencia.Buscar(id).Result;
        }
        public List<HeroisSuperpoderes> BuscarTodos(int id)
        {
            return _persistencia.BuscarTodos(id).Result;
        }
        public HeroisSuperpoderes Inserir(HeroisSuperpoderes entity)
        {
            return _persistencia.Inserir(entity).Result;
        }
        public HeroisSuperpoderes Atualizar(int id, HeroisSuperpoderes dto)
        {
            return _persistencia.Atualizar(id, dto).Result;
        }
        public HeroisSuperpoderes Deletar(int id)
        {
            return _persistencia.Deletar(id).Result;
        }

        public bool DeletarTodos(int heroi)
        {
            if(_persistencia.DeletarTodos(heroi).Result)
            {
                return true;
            }
            return false;
        }

        public bool Deletar(Superpoderes superpoder)
        {
            if(_persistencia.Deletar(superpoder).Result)
            {
                return true;
            }
            return false;
        }
    }
}
