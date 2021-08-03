using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Publisher : BaseEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BaptismDate { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhotoUrl { get; set; }
        public string Gender { get; set; }
        public int PhoneNumber { get; set; }
        public IEnumerable<AppointedPublisher> AppointedPublishers { get; set; }
        public int StatusId { get; set; }
        public Group Group { get; set; }
        public int GroupId { get; set; }
        public IEnumerable<Report> Reports { get; set; }
    }
}
