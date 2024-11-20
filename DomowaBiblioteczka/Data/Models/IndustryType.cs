namespace DomowaBiblioteczka.Data.Models
{
    public class IndustryType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Industry> industries { get; set; }
    }
}
