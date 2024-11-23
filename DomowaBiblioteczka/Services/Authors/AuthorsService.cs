using DomowaBiblioteczka.Data;
using DomowaBiblioteczka.Data.Models;
using DomowaBiblioteczka.Services.Comon;

namespace DomowaBiblioteczka.Services.Authors
{
    public class AuthorsService :  CRUDService<Author, MediaDbContext>, IAuthorsService
    {
        public AuthorsService(MediaDbContext context) : base(context) 
        { 
        
        }


    }
}
