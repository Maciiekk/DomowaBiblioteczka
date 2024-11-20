namespace DomowaBiblioteczka.Data.Models
{
    public class MediaType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Media> Medias { get; set; }
    }
}
