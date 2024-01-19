using Microsoft.EntityFrameworkCore;
using super_herois_api.Domain.Models;

namespace super_herois_api.Persistences
{
    public class HeroisPersistencia : IHeroiPersistencia
    { 
        private readonly SuperHeroisContext _context;
        public HeroisPersistencia(SuperHeroisContext context)
        {
            _context = context;
        }

        public async Task<List<Herois>> Listar()
        {
            return await _context.Herois.ToListAsync();
        }

        public async Task<Herois> Buscar(int id)
        {
            Herois? heroi = await _context.Herois.FirstOrDefaultAsync(x => x.Id == id);
            if(heroi == null) return await Task.FromResult<Herois>(null!);
            return heroi;
        }

        public async Task<Herois> Inserir(Herois heroi)
        {
            heroi.Id = 0;
            _context.Herois.Add(heroi);
            await _context.SaveChangesAsync();
            return heroi;
        }

        public async Task<Herois> Atualizar(int id, Herois heroi)
        {
            if(heroi.Id == id && IdExiste(id))
            {
                _context.Herois.Update(heroi);
                await _context.SaveChangesAsync();
                return heroi;
            }
            return await Task.FromResult<Herois>(null!);
        }
        
        public async Task<Herois> Deletar(int id)
        {
            Herois? heroi = await _context.Herois.FirstOrDefaultAsync(x => x.Id == id);
            if(heroi == null) return await Task.FromResult<Herois>(null!);
            _context.Herois.Remove(heroi);
            await _context.SaveChangesAsync();
            return heroi;
        }

        public async Task<List<Herois>> BuscaNomeHeroi(string nomeHeroi)
        {
            return await _context.Herois.AsNoTracking().Where(x => x.NomeHeroi == nomeHeroi).ToListAsync();
        }

        public Task<List<Herois>> BuscarTodos(int id)
        {
            throw new NotImplementedException();
        }

        private bool IdExiste(int id)
        {
            return _context.Herois.AsNoTracking().Any(x => x.Id == id);
        }
    }
}
