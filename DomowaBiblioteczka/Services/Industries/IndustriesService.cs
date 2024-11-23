using DomowaBiblioteczka.Data.Models;
using DomowaBiblioteczka.Data;
using DomowaBiblioteczka.Services.Comon;
using Microsoft.EntityFrameworkCore;

namespace DomowaBiblioteczka.Services.Industries
{
    public class IndustriesService : CRUDService<Industry, MediaDbContext>, IIndustriesService
    {
        MediaDbContext _context;
        public IndustriesService(MediaDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Industry>> GetAllAsync()
           => await GetAllAsyncCallback();



        private async Task<IEnumerable<Industry>> GetAllAsyncCallback()
        {
            return await _context.Industries.Include(i=>i.IndustryType).ToListAsync();
        }

    }
}
