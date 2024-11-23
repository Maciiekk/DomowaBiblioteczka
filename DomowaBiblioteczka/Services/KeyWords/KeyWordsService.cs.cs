using DomowaBiblioteczka.Data;
using DomowaBiblioteczka.Data.Models;
using DomowaBiblioteczka.Services.Comon;

namespace DomowaBiblioteczka.Services.KeyWords
{
    public class KeyWordsService :CRUDService<KeyWord, MediaDbContext>, IKeyWordsService
    { 

        public KeyWordsService (MediaDbContext context) : base (context)
        {

        }
    }
}
