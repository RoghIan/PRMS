using Core.Entities;

namespace Core.Specifications
{
    public class ReportWithPublisherSpecification : BaseSpecification<Report>
    {
        public ReportWithPublisherSpecification(ReportSpecParams reportSpecParams)
            : base(x =>
                (!reportSpecParams.ReportDate.HasValue || x.ReportDate == reportSpecParams.ReportDate) &&
                (!reportSpecParams.ReportStartDate.HasValue || x.ReportDate >= reportSpecParams.ReportStartDate) &&
                (!reportSpecParams.ReportDate.HasValue || x.ReportDate <= reportSpecParams.ReportEndDate) &&
                (!reportSpecParams.Placements.HasValue || x.Placements == reportSpecParams.Placements) &&
                (!reportSpecParams.PlacementStartRange.HasValue ||
                 x.Placements >= reportSpecParams.PlacementStartRange) &&
                (!reportSpecParams.PlacementEndRange.HasValue || x.Placements <= reportSpecParams.PlacementEndRange) &&
                (!reportSpecParams.VideoShowing.HasValue || x.VideoShowings == reportSpecParams.VideoShowing) &&
                (!reportSpecParams.VideoShowingStartRange.HasValue ||
                 x.VideoShowings >= reportSpecParams.VideoShowingStartRange) &&
                (!reportSpecParams.VideoShowingEndRange.HasValue ||
                 x.VideoShowings <= reportSpecParams.VideoShowingEndRange) &&
                (!reportSpecParams.Hours.HasValue || x.Hours == reportSpecParams.Hours) &&
                (!reportSpecParams.HoursStartRange.HasValue || x.Hours >= reportSpecParams.HoursStartRange) &&
                (!reportSpecParams.HoursEndRange.HasValue || x.Hours <= reportSpecParams.HoursEndRange) &&
                (!reportSpecParams.ReturnVisits.HasValue || x.ReturnVisits == reportSpecParams.ReturnVisits) &&
                (!reportSpecParams.ReturnVisitsStartRange.HasValue ||
                 x.ReturnVisits >= reportSpecParams.ReturnVisitsStartRange) &&
                (!reportSpecParams.ReturnVisitsEndRange.HasValue ||
                 x.ReturnVisits <= reportSpecParams.ReturnVisitsEndRange) &&
                (!reportSpecParams.BibleStudies.HasValue || x.BibleStudies == reportSpecParams.BibleStudies) &&
                (!reportSpecParams.BibleStudiesStartRange.HasValue ||
                 x.BibleStudies >= reportSpecParams.BibleStudiesStartRange) &&
                (!reportSpecParams.BibleStudiesEndRange.HasValue ||
                 x.BibleStudies <= reportSpecParams.BibleStudiesStartRange) &&
                (string.IsNullOrEmpty(reportSpecParams.TitleName) ||
                 x.TitleName.Contains(reportSpecParams.TitleName)) &&
                (string.IsNullOrEmpty(reportSpecParams.GroupName) ||
                 x.GroupName.Contains(reportSpecParams.GroupName)) &&
                (!reportSpecParams.IsAuxi.HasValue || x.Auxiliary == reportSpecParams.IsAuxi)
            )
        {
            AddInclude(x => x.Publisher);
        }

        public ReportWithPublisherSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Publisher);
        }
    }
}