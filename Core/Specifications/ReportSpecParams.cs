using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class ReportSpecParams : BaseSpecParams
    {
        public string TitleName { get; set; }
        public string GroupName { get; set; }

        public DateTime? ReportDate { get; set; }
        public DateTime? ReportStartDate { get; set; }
        public DateTime? ReportEndDate { get; set; }
        public int? Placements { get; set; }
        public int? PlacementStartRange { get; set; }
        public int? PlacementEndRange { get; set; }
        public int? VideoShowing { get; set; }
        public int? VideoShowingStartRange { get; set; }
        public int? VideoShowingEndRange { get; set; }
        public int? Hours { get; set; }
        public int? HoursStartRange { get; set; }
        public int? HoursEndRange { get; set; }
        public int? ReturnVisits { get; set; }
        public int? ReturnVisitsStartRange { get; set; }
        public int? ReturnVisitsEndRange { get; set; }
        public int? BibleStudies { get; set; }
        public int? BibleStudiesStartRange { get; set; }
        public int? BibleStudiesEndRange { get; set; }
        public bool? IsAuxi { get; set; }
    }
}