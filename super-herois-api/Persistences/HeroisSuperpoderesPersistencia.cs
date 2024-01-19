using Microsoft.EntityFrameworkCore;
using super_herois_api.Domain.DTOs;
using super_herois_api.Domain.Models;

namespace super_herois_api.Persistences
{
    public class HeroisSuperpoderesPersistencia : IHeroisSuperpoderesPersistencia
    {
        private readonly SuperHeroisContext _context;
        public HeroisSuperpoderesPersistencia(SuperHeroisContext context)
        {
            _context = context;
        }
        public async Task<List<HeroisSuperpoderes>> Listar()
        {
            return await _context.HeroisSuperpoderes.ToListAsync();
        }
        public async Task<HeroisSuperpoderes> Buscar(int id)
        {
            return await _context.HeroisSuperpoderes.FirstOrDefaultAsync(x => x.HeroiId == id) ?? await Task.FromResult<HeroisSuperpoderes>(null!);
        }
        public async Task<HeroisSuperpoderes> Inserir(HeroisSuperpoderes entity)
        {
            await _context.HeroisSuperpoderes.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<HeroisSuperpoderes> Atualizar(int id, HeroisSuperpoderes entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.HeroisSuperpoderes.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<HeroisSuperpoderes> Deletar(int id)
        {
            HeroisSuperpoderes? heroiSuperpoder = await _context.HeroisSuperpoderes.FirstOrDefaultAsync(x => x.HeroiId == id);
            if(heroiSuperpoder == null) return await Task.FromResult<HeroisSuperpoderes>(null!);
            _context.HeroisSuperpoderes.Remove(heroiSuperpoder);
            await _context.SaveChangesAsync();
            return heroiSuperpoder;
        }

        public async Task<List<HeroisSuperpoderes>> BuscarTodos(int id)
        {
            return await _context.HeroisSuperpoderes.Where(x => x.HeroiId == id).ToListAsync();
        }

        public async Task<bool> DeletarTodos(int heroiId)
        {
            List<HeroisSuperpoderes> heroisSuperpoderes = _context.HeroisSuperpoderes.Where(x => x.HeroiId == heroiId).ToList();
            foreach(HeroisSuperpoderes heroiSuperpoder in heroisSuperpoderes)
            {
                _context.HeroisSuperpoderes.Remove(heroiSuperpoder);
            }
            if(await _context.SaveChangesAsync() > 0) return true;
            return false;
        }

        public async Task<bool> Deletar(Superpoderes superpoderes)
        {
            List<HeroisSuperpoderes> heroisSuperpoderes = _context.HeroisSuperpoderes.Where(x => x.SuperpoderId == superpoderes.Id).ToList();
            foreach(HeroisSuperpoderes heroiSuperpoder in heroisSuperpoderes)
            {
                _context.HeroisSuperpoderes.Remove(heroiSuperpoder);
            }
            if(await _context.SaveChangesAsync() > 0) return true;
            return false;
        }
    }
}