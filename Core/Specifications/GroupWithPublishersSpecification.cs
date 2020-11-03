using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Specifications
{
    public class GroupWithPublishersSpecification : BaseSpecification<Group>
    {
        public GroupWithPublishersSpecification(GroupSpecParams groupSpecParams) : base()
        {
            AddInclude(x => x.Publishers);
        }

        public GroupWithPublishersSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Publishers);
        }
    }
}