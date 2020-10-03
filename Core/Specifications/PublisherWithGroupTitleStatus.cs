using Core.Entities;

namespace Core.Specifications
{
    public class PublisherWithGroupTitleStatusReport : BaseSpecification<Publisher>
    {
        public PublisherWithGroupTitleStatusReport()
        {
            AddInclude("PublisherTitles.Title");
            AddInclude(x => x.Group);
            AddInclude(x => x.Status);
            AddInclude(x => x.Reports);
        }

        public PublisherWithGroupTitleStatusReport(int id) : base(x => x.Id == id)
        {
            AddInclude("PublisherTitles.Title");
            AddInclude(x => x.Group);
            AddInclude(x => x.Status);
            AddInclude(x => x.Reports);
        }
    }
}
