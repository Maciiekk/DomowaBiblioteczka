namespace DomowaBiblioteczka.Data.Models
{
    public class MediaSection
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Position { get; set; }

        public int MediaId { get; set; }

        public Media Media { get; set; }

    }
}
