using Microsoft.EntityFrameworkCore;
using super_herois_api.Domain.DTOs;
using super_herois_api.Domain.Models;
using super_herois_api.Persistences;

namespace super_herois_api.Services
{
    public class SuperpoderesService : IServiceBase<Superpoderes, Superpoderes>
    {
        private readonly ISuperpoderesPersistencia _persistencia;
        private readonly IHeroisSuperpoderesService _heroisSuperpoderesService;
        public SuperpoderesService(ISuperpoderesPersistencia persistencia, IHeroisSuperpoderesService heroisSuperpoderesService)
        {
            _persistencia = persistencia;
            _heroisSuperpoderesService = heroisSuperpoderesService;
        }
        
        public List<Superpoderes> Listar()
        {
            List<Superpoderes> superpoderes = _persistencia.Listar().Result;
            if(superpoderes == null)
            {
                return new List<Superpoderes>();
            }
            return superpoderes;
        }

        public Superpoderes Atualizar(int id, Superpoderes entity)
        {
            return _persistencia.Atualizar(id, entity).Result;
        }

        public Superpoderes Buscar(int id)
        {
            return _persistencia.Buscar(id).Result;
        }

        public Superpoderes Deletar(int id)
        {
            DeletaHeroiSuperpoderes(_persistencia.Buscar(id).Result);
            return _persistencia.Deletar(id).Result;
        }

        public Superpoderes Inserir(Superpoderes dto)
        {
            return _persistencia.Inserir(dto).Result;
        }

        public List<Superpoderes> BuscarTodos(int id)
        {
            return _persistencia.BuscarTodos(id).Result;
        }

        private bool DeletaHeroiSuperpoderes(Superpoderes superpoderes)
        {
            return _heroisSuperpoderesService.Deletar(superpoderes);
        }
    }
}
