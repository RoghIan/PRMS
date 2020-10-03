using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class TitleRepository : ITitleRepository
    {
        private readonly DataContext _context;

        public TitleRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Title> GetTitleByIdAsync(int id)
        {
            return await _context.Titles.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IReadOnlyList<Title>> GetTitlesAsync()
        {
            return await _context.Titles.ToListAsync();
        }
    }
}
