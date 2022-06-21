using AutoMapper;
using TestTask_Friend.DAL.Entities;

namespace TestTask_Friend.APIStruct.MapperProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserResponse, UserEntity>()
            .ForMember(prop => prop.Password
                , option => option.Ignore())
            .ReverseMap();

        CreateMap<UserRequest, UserEntity>()
            .ForMember(prop => prop.Id, option => option.Ignore());

        CreateMap<UserResponse, UserEntity>()
            .ForMember(prop => prop.Birth
                , option => option
                    .MapFrom(propFrom => propFrom.Birth)).ReverseMap();
        
        CreateMap<DateTime, DateOnly>().ConvertUsing(prop => DateOnly.FromDateTime(prop));
        CreateMap<DateOnly, DateTime>().ConvertUsing(prop => prop.ToDateTime(TimeOnly.MinValue));
    }
}