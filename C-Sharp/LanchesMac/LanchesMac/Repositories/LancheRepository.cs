using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;

        public LancheRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanche> Lanches => _context.Lanches
                                                      .Include(lanches => lanches.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches
                                                                .Where(lanches => lanches.IsLanchePreferido == true)
                                                                .Include(lanches => lanches.Categoria);

        public Lanche GetLancheById(int LancheId)
        {
               return _context.Lanches
                              .Include(lanches => lanches.Categoria)
                              .FirstOrDefault(lanches => lanches.LancheId == LancheId, new Lanche());
        }
    }
}
