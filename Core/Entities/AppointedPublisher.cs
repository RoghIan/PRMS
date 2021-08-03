using Newtonsoft.Json;

namespace Core.Entities
{
    public class AppointedPublisher : BaseEntity
    {
        public int PublisherId { get; set; }
        [JsonIgnore]
        public Publisher Publisher { get; set; }
        public int AppointedId { get; set; }
        [JsonIgnore]
        public Appointed Appointed { get; set; }
    }
}
