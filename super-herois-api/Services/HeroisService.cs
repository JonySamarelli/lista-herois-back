using super_herois_api.Domain.DTOs;
using super_herois_api.Domain.Models;
using super_herois_api.Exceptions;
using super_herois_api.Persistences;

namespace super_herois_api.Services
{
    public class HeroisService : IServiceBase<Herois, HeroisDTO>
    {
        private readonly IHeroiPersistencia _persistencia;
        private readonly IHeroisSuperpoderesService _heroisSuperpoderesService;
        private readonly IServiceBase<Superpoderes, Superpoderes> _superpoderesService;
        public HeroisService(IHeroiPersistencia persistencia, IHeroisSuperpoderesService heroisSuperpoderesService, IServiceBase<Superpoderes, Superpoderes> superpoderesService)
        {
            _persistencia = persistencia;
            _heroisSuperpoderesService = heroisSuperpoderesService;
            _superpoderesService = superpoderesService;
        }

        public List<Herois> Listar()
        {
            List<Herois> listaHerois = _persistencia.Listar().Result;
            if(listaHerois == null) {
                return new List<Herois>();
            }
            return listaHerois;
        }

        public HeroisDTO Buscar(int id)
        {
            Herois heroi = _persistencia.Buscar(id).Result;

            return heroi == null ? throw new HeroisExcepetion("Herói não encontrado") : EntityToDto(heroi);
        }

        public Herois Inserir(HeroisDTO heroiDto)
        {
            ValidaHeroi(heroiDto);
            NomeHeroiUnico(heroiDto);
            Herois heroi = _persistencia.Inserir(DtoToEntity(heroiDto)).Result;
            heroiDto.Id = heroi.Id;
            AdicionaSuperpoderes(heroiDto);
            return heroi;
        }

        public Herois Atualizar(int id, HeroisDTO heroiDto)
        {
            ValidaHeroi(heroiDto);
            NomeHeroiUnico(heroiDto);
            RemoveSuperpoderes(heroiDto.Id);
            AdicionaSuperpoderes(heroiDto);
            return _persistencia.Atualizar(id, DtoToEntity(heroiDto)).Result;
        }

        public Herois Deletar(int id)
        {
            Buscar(id);
            RemoveSuperpoderes(id);
            return _persistencia.Deletar(id).Result;
        }

        private static void ValidaHeroi(HeroisDTO heroi)
        {
            string mensagem = "";
            if(heroi.NomeHeroi == null || heroi.NomeHeroi.Length < 3)
            {
                mensagem += "Nome do herói inválido\n";
            }
            if(heroi.Nome == null || heroi.Nome.Length < 3)
            {
                mensagem += "Nome inválido\n";
            }
            if(heroi.Altura <= 0)
            {
                mensagem += "Altura inválida\n";
            }
            if(heroi.Peso <= 0)
            {
                mensagem += "Peso inválido";
            }
            if(mensagem != "")
            {
                throw new HeroisExcepetion(mensagem);
            }
        }

        private void NomeHeroiUnico(HeroisDTO heroi)
        {
            List<Herois> listaHerois = _persistencia.BuscaNomeHeroi(heroi.NomeHeroi).Result;
            
            if(listaHerois.Count > 0)
            {
                foreach(Herois heroiLista in listaHerois)
                {
                    if(heroiLista.Id != heroi.Id)
                    {
                        throw new HeroisExcepetion("Nome do herói já cadastrado");
                    }
                }
            }
           listaHerois.Clear();
        }

        private HeroisDTO EntityToDto(Herois heroi)
        {
            List<Superpoderes> listaSuperpoderes = BuscaSuperpoderesDoHeroi(heroi.Id);
            return new HeroisDTO(heroi.Id, heroi.Nome, heroi.NomeHeroi, heroi.DataNascimento, heroi.Altura, heroi.Peso, listaSuperpoderes);
        }

        private List<Superpoderes> BuscaSuperpoderesDoHeroi(int id)
        {
            List<HeroisSuperpoderes> listaHeroisSuperpoderes = _heroisSuperpoderesService.BuscarTodos(id);
            List<Superpoderes> listaSuperpoderes = new();
            foreach(HeroisSuperpoderes superpoder in listaHeroisSuperpoderes)
            {
                listaSuperpoderes.Add(_superpoderesService.Buscar(superpoder.SuperpoderId));
            }
            return listaSuperpoderes;
        }

        private static Herois DtoToEntity(HeroisDTO heroiDto)
        {
            return new Herois(heroiDto.Id, heroiDto.Nome, heroiDto.NomeHeroi, heroiDto.DataNascimento, heroiDto.Altura, heroiDto.Peso);
        }

        private void RemoveSuperpoderes(int heroiId)
        {
            _heroisSuperpoderesService.DeletarTodos(heroiId);
        }
        
        private void AdicionaSuperpoderes(HeroisDTO heroiDto)
        {
            foreach(var superpoder in heroiDto.ListaSuperpoderes)
            {
                HeroisSuperpoderes heroisSuperpoderes = new(heroiDto.Id, superpoder.Id);
                _heroisSuperpoderesService.Inserir(heroisSuperpoderes);
            }
        }

        public List<Herois> BuscarTodos(int id)
        {
            return _persistencia.BuscarTodos(id).Result;
        }
    }
}
