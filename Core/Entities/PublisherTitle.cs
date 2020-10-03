namespace Core.Entities
{
    public class PublisherTitle
    {
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public int TitleId { get; set; }
        public Title Title { get; set; }
    }
}
