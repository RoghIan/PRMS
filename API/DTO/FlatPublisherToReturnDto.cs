using System;

namespace API.DTO
{
    public class FlatPublisherToReturnDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime BaptismDate { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhotoUrl { get; set; }
        public string Gender { get; set; }
        public string Group { get; set; }
    }
}