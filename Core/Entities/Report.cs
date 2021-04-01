using System;

namespace Core.Entities
{
    public class Report : BaseEntity
    {
        public DateTime ReportDate { get; set; }
        public int Placements { get; set; }
        public int VideoShowings { get; set; }
        public int Hours { get; set; }
        public int ReturnVisits { get; set; }
        public int BibleStudies { get; set; }
        public string Remarks { get; set; }
        public string TitleName { get; set; }
        public string GroupName { get; set; }
        public bool Auxiliary { get; set; }
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
    }
}
