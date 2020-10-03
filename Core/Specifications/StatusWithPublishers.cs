using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class StatusWithPublishers : BaseSpecification<Status>
    {
        public StatusWithPublishers()
        {
            AddInclude(s => s.Publishers);
        }

        public StatusWithPublishers(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Publishers);
        }
    }
}
