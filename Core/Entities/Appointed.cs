using System.Collections.Generic;

namespace Core.Entities
{
    public class Appointed : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<AppointedPublisher> AppointedPublishers { get; set; }
    }
}
