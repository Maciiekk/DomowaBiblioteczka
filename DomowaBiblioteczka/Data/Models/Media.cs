namespace DomowaBiblioteczka.Data.Models
{
    public class Media
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set;}

        public DateTime UpdatedDate { get; set;} = DateTime.Now;

        public DateTime ReleseDate { get; set;} 

        public int TimeOrPages { get; set; }
        
        public ICollection<MediaSection> Sections { get; set; }

        public ICollection<KeyWord> Keywords { get; set; }

        public ICollection<Author> Authors { get; set; }
        public int MediaTypeID { get; set; }
        public MediaType MediaType { get; set; }

        //TODO: image ID
    }
}
