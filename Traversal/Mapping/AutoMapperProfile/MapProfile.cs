using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.CityDTOs;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;

namespace Traversal.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDto, Announcement>().ReverseMap();
            CreateMap<AppUserRegisterDTOs, AppUser>().ReverseMap();
            CreateMap<AppUserLoginDTOs, AppUser>().ReverseMap();
            CreateMap<AnnouncemenetListDto, Announcement>().ReverseMap();
            CreateMap<AnnouncementUpdateDto, Announcement>().ReverseMap();
            CreateMap<SendMessageDto, ContactUs>().ReverseMap();
        }
    }
}
