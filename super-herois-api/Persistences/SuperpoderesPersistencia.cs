using Microsoft.EntityFrameworkCore;
using super_herois_api.Domain.Models;

namespace super_herois_api.Persistences
{
    public class SuperpoderesPersistencia : ISuperpoderesPersistencia
    {
        private readonly SuperHeroisContext _context;
        public SuperpoderesPersistencia(SuperHeroisContext context)
        {
            _context = context;
        }

        public async Task<List<Superpoderes>> Listar()
        {
            return await _context.Superpoderes.ToListAsync();
        }

        public async Task<Superpoderes> Buscar(int id)
        {
            Superpoderes? superpoder = await _context.Superpoderes.FirstOrDefaultAsync(x => x.Id == id);
            if(superpoder == null) return await Task.FromResult<Superpoderes>(null!);
            return superpoder;
        }

        public async Task<Superpoderes> Inserir(Superpoderes superpoder)
        {
            superpoder.Id = 0;
            _context.Superpoderes.Add(superpoder);
            await _context.SaveChangesAsync();
            return superpoder;
        }

        public async Task<Superpoderes> Atualizar(int id, Superpoderes superpoder)
        {
            if(superpoder.Id == id)
            {
                _context.Entry(superpoder).State = EntityState.Modified;
                _context.Superpoderes.Update(superpoder);
                await _context.SaveChangesAsync();
                return superpoder;
            }
            return await Task.FromResult<Superpoderes>(null!);
        }

        public async Task<Superpoderes> Deletar(int id)
        {
            Superpoderes? superpoder = await _context.Superpoderes.FirstOrDefaultAsync(x => x.Id == id);
            if(superpoder == null) return await Task.FromResult<Superpoderes>(null!);
            _context.Superpoderes.Remove(superpoder);
            await _context.SaveChangesAsync();
            return superpoder;
        }

        public Task<List<Superpoderes>> BuscarTodos(int id)
        {
            return _context.Superpoderes.Where(x => x.Id == id).ToListAsync();
        }
    }
}
