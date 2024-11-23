using DomowaBiblioteczka.Data;
using DomowaBiblioteczka.Data.Models;
using DomowaBiblioteczka.Services.Comon;
using Microsoft.EntityFrameworkCore;


namespace DomowaBiblioteczka.Services.MediaSections
{
    public class MediaSectionsService: CRUDService<MediaSection, MediaDbContext>, IMediaSectionsService
    {
        MediaDbContext _context;
        public MediaSectionsService(MediaDbContext context) : base(context)
        {
            _context = context; 
        }
        public async Task<IEnumerable<MediaSection>> GetAllAsync()
            => await  GetAllAsyncCallback();



        private async Task<IEnumerable<MediaSection>> GetAllAsyncCallback()
        {
            return await _context.MediaSections.Include(s=>s.Media).ToListAsync();
        }
    }
}
