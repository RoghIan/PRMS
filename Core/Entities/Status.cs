using System.Collections.Generic;

namespace Core.Entities
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Publisher> Publishers { get; set; }
    }
}
