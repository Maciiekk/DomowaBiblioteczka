using DomowaBiblioteczka.Data;
using DomowaBiblioteczka.Data.Models;
using DomowaBiblioteczka.Services.Comon;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DomowaBiblioteczka.Services.KeyWords
{
    public class KeyWordsService :CRUDService<KeyWord, MediaDbContext>, IKeyWordsService
    {
        MediaDbContext _context;
        public KeyWordsService (MediaDbContext context) : base (context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Media>> GetMediaByKeyWords(IEnumerable<KeyWord> words, bool andSearch)
            => await GetMediaByKeyWordsCallback(words,  andSearch);

        private async Task<IEnumerable<Media>> GetMediaByKeyWordsCallback(IEnumerable<KeyWord> words, bool andSearch)
        {
            if (andSearch)
            {
                // AND Search: Only Medias linked to all specified keywords
                var keywordIds = words.Select(w => w.Id).ToList();
                var data = await _context.Medias
                    .Where(m => keywordIds.All(id => m.Keywords.Any(k => k.Id == id)))
                    .ToListAsync();
                return data;
            }
            else
            {
                // OR Search: Any Medias linked to any specified keywords
                var keywordIds = words.Select(w => w.Id).ToList();
                var data = await _context.Medias
                    .Where(m => m.Keywords.Any(k => keywordIds.Contains(k.Id)))
                    .ToListAsync();
                return data;
            }
        }
    }
}
