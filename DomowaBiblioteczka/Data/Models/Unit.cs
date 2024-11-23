namespace DomowaBiblioteczka.Data.Models
{
    public class Unit
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Symbole { get; set; }

        public ICollection<MediaType> MediaTypes { get; set; }
    }
}
