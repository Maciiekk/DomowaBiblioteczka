using DomowaBiblioteczka.Data;
using DomowaBiblioteczka.Data.Models;
using DomowaBiblioteczka.Services.Comon;
using Microsoft.EntityFrameworkCore;

namespace DomowaBiblioteczka.Services.MediaTypes
{
    public class MediaTypesService : CRUDService<MediaType,MediaDbContext> ,IMediaTypesService
    {
        MediaDbContext _context;
        public MediaTypesService(MediaDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<MediaType>> GetAllAsync()
            => await GetAllAsyncCallback();

        private async Task<IEnumerable<MediaType>> GetAllAsyncCallback()
        {
            return await _context.MediaTypes.Include(i => i.Unit).ToListAsync();
        }
    }
}
