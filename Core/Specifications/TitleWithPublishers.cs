using Core.Entities;

namespace Core.Specifications
{
    public class TitleWithPublishers : BaseSpecification<Title>
    {
        public TitleWithPublishers()
        {
            AddInclude("PublisherTitles.Publisher");
        }

        public TitleWithPublishers(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.PublisherTitles);
        }
    }
}
