namespace Picasso.Models.DTOs.Member
{
    public class ManagementCenterDto
    {
        public MemberDto Member { get; set; }

        public List<ExhibitionApplyRecordDto> ExhibitionApplyRecords { get; set;}

        public List<CurationRecordDto> CurationRecords { get; set;}
    }
}
