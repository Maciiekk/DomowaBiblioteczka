using DomowaBiblioteczka.Data.Models;
using DomowaBiblioteczka.Data;
using DomowaBiblioteczka.Services.Comon;

namespace DomowaBiblioteczka.Services.Medias
{
    public class MediasService : CRUDService<Media, MediaDbContext>, IMediasService
    {
        public MediasService(MediaDbContext context) : base(context)
        {
           
        }
    }
}

