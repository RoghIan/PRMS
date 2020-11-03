using Core.Entities;

namespace Core.Specifications
{
    public class TitleWithFiltersForCountSpecification : BaseSpecification<Title>
    {
        public TitleWithFiltersForCountSpecification(TitleSpecParams titleSpecParams) : base()
        {
        }

        public TitleWithFiltersForCountSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.PublisherTitles);
        }
    }
}