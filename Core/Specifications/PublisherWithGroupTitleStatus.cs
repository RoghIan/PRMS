using Core.Entities;
using System.Linq;

namespace Core.Specifications
{
    public class PublisherWithGroupTitleStatusReport : BaseSpecification<Publisher>
    {
        public PublisherWithGroupTitleStatusReport(PublisherSpecParams publisherParams)
            : base(x =>
                (!publisherParams.TitleId.HasValue ||
                 x.PublisherTitles.FirstOrDefault(pt => pt.TitleId == publisherParams.TitleId).TitleId ==
                 publisherParams.TitleId) &&
                (!publisherParams.GroupId.HasValue || x.GroupId == publisherParams.GroupId) &&
                (!publisherParams.StatusId.HasValue || x.StatusId == publisherParams.StatusId)
            )
        {
            AddInclude("PublisherTitles.Title");
            AddInclude(x => x.Group);
            AddInclude(x => x.Status);
            AddInclude(x => x.Reports);
            AddOrderBy(x => x.LastName);
            ApplyPaging(publisherParams.PageSize * (publisherParams.PageIndex - 1),
                publisherParams.PageSize);

            if (!string.IsNullOrEmpty(publisherParams.Sort))
                switch (publisherParams.Sort)
                {
                    case "titleAsc":
                        AddOrderBy(t => t.PublisherTitles.Select(pt => pt.Title.Name));
                        break;
                    case "titleDesc":
                        AddOrderByDescending(t => t.PublisherTitles.Select(pt => pt.Title.Name));
                        break;
                    case "groupAsc":
                        AddOrderBy(g => g.Group.Name);
                        break;
                    case "groupDesc":
                        AddOrderByDescending(g => g.Group.Name);
                        break;
                    case "statusAsc":
                        AddOrderBy(g => g.Status.Name);
                        break;
                    case "statusDesc":
                        AddOrderByDescending(g => g.Status.Name);
                        break;
                    default:
                        AddOrderBy(n => n.LastName);
                        break;
                }
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