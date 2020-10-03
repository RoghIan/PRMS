using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class GroupWithPublishers : BaseSpecification<Group>
    {
        public GroupWithPublishers()
        {
            AddInclude(x => x.Publishers);
        }

        public GroupWithPublishers(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Publishers);
        }
    }
}
