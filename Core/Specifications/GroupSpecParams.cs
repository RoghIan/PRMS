using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class GroupSpecParams : BaseSpecParams
    {
        public HashSet<int> PublishersId { get; set; } = new HashSet<int>();
    }
}