namespace DomowaBiblioteczka.Data.Models
{
    public class KeyWord
    {
        public int Id { get; set; }

        public string Word { get; set; }

        public ICollection<Media> Medias { get; set; }
    }
}
