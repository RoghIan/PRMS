using Core.Entities;

namespace Core.Specifications
{
    public class PublisherWithReport : BaseSpecification<Publisher>
    {
        public PublisherWithReport()
        {
            AddInclude(x => x.Reports);
        }

    }
}