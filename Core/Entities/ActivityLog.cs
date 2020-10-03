using System;

namespace Core.Entities
{
    public class ActivityLog : BaseEntity
    {
        public string Action { get; set; }
        public string Module { get; set; }
        public DateTime DeclareDate { get; set; }
        public string Description { get; set; }
    }
}
