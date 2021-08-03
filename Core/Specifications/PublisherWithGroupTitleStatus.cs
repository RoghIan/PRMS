using Core.Entities;
using System.Linq;

namespace Core.Specifications
{
    public class PublisherWithGroupTitleStatusReport : BaseSpecification<Publisher>
    {
        public PublisherWithGroupTitleStatusReport(PublisherSpecParams publisherParams)
            : base(x =>
                (string.IsNullOrEmpty(publisherParams.Search) ||
                 x.FirstName.ToLower().Contains(publisherParams.Search) ||
                 x.LastName.ToLower().Contains(publisherParams.Search)) &&
                // (!publisherParams.TitleId.HasValue ||
                //  x.PublisherTitles.FirstOrDefault(pt => pt.AppointedId == publisherParams.TitleId).AppointedId ==
                //  publisherParams.TitleId) &&
                (!publisherParams.GroupId.HasValue || x.GroupId == publisherParams.GroupId) &&
                (!publisherParams.StatusId.HasValue || x.StatusId == publisherParams.StatusId)
            )
        {
            //AddInclude("PublisherTitles.Title");
            AddInclude(x => x.Group);
            AddInclude(x => x.Reports);
            AddOrderBy(x => x.LastName);
            ApplyPaging(publisherParams.PageSize * (publisherParams.PageIndex - 1),
                publisherParams.PageSize);

            if (string.IsNullOrEmpty(publisherParams.Sort)) return;
            
            switch (publisherParams.Sort)
            {
                case "lastNameAsc":
                    AddOrderBy(n => n.LastName);
                    break;
                case "lastNameDesc":
                    AddOrderByDescending(n => n.LastName);
                    break;
                case "groupAsc":
                    AddOrderBy(g => g.Group.Name);
                    break;
                case "groupDesc":
                    AddOrderByDescending(g => g.Group.Name);
                    break;
                default:
                    AddOrderBy(n => n.LastName);
                    break;
            }
        }

        public PublisherWithGroupTitleStatusReport(int id) : base(x => x.Id == id)
        {
            //AddInclude("PublisherTitles.Title");
            AddInclude(x => x.Group);
            AddInclude(x => x.Reports);
        }
    }
}