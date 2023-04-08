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

            CreateMap<Landlord, LandlordDTO>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => src.Avatar.Url));

            CreateMap<Location, PriceDTO>().ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.PricePerDay));

            CreateMap<Location, LocationDetailDTO>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.SubTitle, opt => opt.MapFrom(src => src.SubTitle))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.Rooms))
                .ForMember(dest => dest.NumberOfGuests, opt => opt.MapFrom(src => src.NumberOfGuests))
                .ForMember(dest => dest.PricePerDay, opt => opt.MapFrom(src => Math.Round(src.PricePerDay, 2)))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.LocationType))
                .ForMember(dest => dest.Features, opt => opt.MapFrom(src => src.Features))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(img => new ImageDTO { URL = img.Url, IsCover = img.IsCover })))
                .ForMember(dest => dest.Landlord, opt => opt.MapFrom(src => new LandlordDTO { Name = src.Landlord.FirstName + " " + src.Landlord.LastName, Avatar = src.Landlord.Avatar.Url }));
        }
    }

}
