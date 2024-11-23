using DomowaBiblioteczka.Data.Models;
using DomowaBiblioteczka.Data;
using DomowaBiblioteczka.Services.Comon;
using DomowaBiblioteczka.Services.Medias;

namespace DomowaBiblioteczka.Services.Medias
{
    public class MediasService : CRUDService<Media, MediaDbContext>, IMediasService
    {
        public MediasService(MediaDbContext context) : base(context)
        {
           
        }
    }
}

