using AutoMapper;

namespace rock_paper_scissors.Profiles
{
    public class ChoiceProfile : Profile
    {

        public ChoiceProfile() 
        {
            CreateMap<Entities.Choice, Models.ChoiceDto>();
        
        }
    }
}
