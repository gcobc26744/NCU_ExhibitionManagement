using AutoMapper;
using Picasso.Models.DTOs.Exhibition;
using Picasso.Model;
using Picasso.Models.DTOs.ExhibitionApply;
using Picasso.Models.DTOs.Curation;
using Picasso.Models.DTOs.Member;
using Picasso.Models.DTOs.Administrator;

namespace Picasso.Profiles
{
    public class ExhibitionManagementProfile : Profile
    {
        public ExhibitionManagementProfile()
        {
            CreateMap<Exhibitions, ExhibitionDto>();
            CreateMap<ExhibitionApply, ExhibitionApplyDto>();
            CreateMap<ApplyDto, Exhibitions>();
            CreateMap<Members, MemberDto>();
            CreateMap<MemberDto, Members>();
            CreateMap<Exhibitions, ReviewCurationDto>();
            CreateMap<Exhibitions, ReviewCurationDetailDto>();
        }
    }
}
