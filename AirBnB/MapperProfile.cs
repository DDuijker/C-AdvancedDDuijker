namespace AirBnB
{
    using AirBnB.Models;
    using AirBnB.Models.DTO;
    using AutoMapper;
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Location, LocationDTO>().ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => src.Images.Find(i => i.IsCover).Url))
                .ForMember(dest => dest.LandlordAvatarURL, opt => opt.MapFrom(src => src.Landlord.Avatar.Url));

        }
    }

}
