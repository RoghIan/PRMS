using System.Collections.Generic;

namespace Core.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public int OverseerPublisherId { get; set; }
        public int AssistantPublisherId { get; set; }
        public IEnumerable<Publisher> Publishers { get; set; }
    }
}
