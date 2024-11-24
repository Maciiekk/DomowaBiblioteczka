using DomowaBiblioteczka.Data.Models;
using DomowaBiblioteczka.Data;
using DomowaBiblioteczka.Services.Comon;
using Microsoft.EntityFrameworkCore;

namespace DomowaBiblioteczka.Services.Medias
{
    public class MediasService : CRUDService<Media, MediaDbContext>, IMediasService
    {
        MediaDbContext _context;

        public MediasService(MediaDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Media> GetByIdAsync(object id)
           => await GetAllAsyncCallback(id);



        private async Task<Media> GetAllAsyncCallback(object id)
        {
            int convertedId; 
            if (Int32.TryParse(id.ToString(),out convertedId))
            {
                return await _context.Medias
                    .Include(m => m.Industry)
                    .Include(m => m.Keywords)
                    .Include(m=> m.Authors)
                    .Include(m => m.MediaType)
                        .ThenInclude(mt => mt.Unit)
                    .FirstOrDefaultAsync(m => m.Id == convertedId);
            }
            return null;
        }
    }
}

