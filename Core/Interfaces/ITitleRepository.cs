using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITitleRepository
    {
        Task<Title> GetTitleByIdAsync(int id);
        Task<IReadOnlyList<Title>> GetTitlesAsync();
    }
}
