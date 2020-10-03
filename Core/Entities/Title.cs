using System.Collections.Generic;

namespace Core.Entities
{
    public class Title : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<PublisherTitle> PublisherTitles { get; set; }
    }
}
