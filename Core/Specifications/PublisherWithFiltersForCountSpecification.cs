using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Specifications
{
    public class PublisherWithFiltersForCountSpecification : BaseSpecification<Publisher>
    {
        public PublisherWithFiltersForCountSpecification(PublisherSpecParams publisherParams)
                        : base(x =>
                (!publisherParams.TitleId.HasValue || x.PublisherTitles.FirstOrDefault(pt => pt.TitleId == publisherParams.TitleId).TitleId == publisherParams.TitleId) &&
                (!publisherParams.GroupId.HasValue || x.GroupId == publisherParams.GroupId) &&
                (!publisherParams.StatusId.HasValue || x.StatusId == publisherParams.StatusId)
            )
        {

        }
    }
}
