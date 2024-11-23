using DomowaBiblioteczka.Data;
using DomowaBiblioteczka.Data.Models;
using DomowaBiblioteczka.Services.Comon;

namespace DomowaBiblioteczka.Services.MediaTypes
{
    public class MediaTypesService : CRUDService<MediaType,MediaDbContext> ,IMediaTypesService
    {
        public MediaTypesService(MediaDbContext context) : base(context) 
        { 
        }
    }
}
