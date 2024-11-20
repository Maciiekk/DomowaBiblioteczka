namespace DomowaBiblioteczka.Data.Models
{
    public class Industry
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int IndustryTypeId { get; set; }

        public IndustryType IndustryType { get; set; }
    }
}
