using DomowaBiblioteczka.Data;
using DomowaBiblioteczka.Data.Models;
using DomowaBiblioteczka.Services.Comon;

namespace DomowaBiblioteczka.Services.KeyWords
{
    public interface IKeyWordsService : ICRUDService<KeyWord>
    {
        public Task<IEnumerable<Media>>GetMediaByKeyWords(IEnumerable<KeyWord> words, bool andSearch);
    }
}
