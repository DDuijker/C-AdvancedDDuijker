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

            CreateMap<Location, LocationDTOv2>().ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => src.Images.Find(i => i.IsCover).Url))
                .ForMember(dest => dest.LandlordAvatarURL, opt => opt.MapFrom(src => src.Landlord.Avatar.Url))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.PricePerDay))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.LocationType));

            CreateMap<Image, ImageDTO>().ForMember(dest => dest.URL, opt => opt.MapFrom(src => src.Url))
                .ForMember(dest => dest.IsCover, opt => opt.MapFrom(src => src.IsCover));
        }
    }

}
