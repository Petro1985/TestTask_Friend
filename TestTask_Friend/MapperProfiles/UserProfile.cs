using AutoMapper;
using TestTask_Friend.APIStruct;
using TestTask_Friend.DAL.Entities;

namespace TestTask_Friend.MapperProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {

        CreateMap<UserRequest, UserEntity>()
            .ForMember(prop => prop.Id, option => option.Ignore());

        CreateMap<UserEntity, UserResponse>()
            .ForMember(prop => prop.Birth
                , option => option
                    .MapFrom(propFrom => propFrom.Birth));
        
        CreateMap<DateTime, DateOnly>().ConvertUsing(prop => DateOnly.FromDateTime(prop));
        CreateMap<DateOnly, DateTime>().ConvertUsing(prop => prop.ToDateTime(TimeOnly.MinValue));
    }
}