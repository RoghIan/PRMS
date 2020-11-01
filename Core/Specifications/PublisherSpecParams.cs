using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class PublisherSpecParams : BaseSpecParams
    {
        public int? TitleId { get; set; }
        public int? GroupId { get; set; }
        public int? StatusId { get; set; }
    }
}