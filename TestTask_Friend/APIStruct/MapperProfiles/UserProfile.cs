using AutoMapper;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using TestTask_Friend.Controllers;

namespace TestTask_Friend.APIStruct.MapperProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserEntity>()
            .ForMember(prop => prop.tg
                , options =>
                    options.MapFrom(propFrom => propFrom.tg)).ReverseMap();
        CreateMap<User, UserEntity>()
            .ForMember(prop => prop.Email
                , options =>
                    options.MapFrom(propFrom => propFrom.email)).ReverseMap();
        CreateMap<User, UserEntity>()
            .ForMember(prop => prop.Id
                , options =>
                    options.MapFrom(propFrom => propFrom.id)).ReverseMap();
        CreateMap<User, UserEntity>()
            .ForMember(prop => prop.Login
                , options =>
                    options.MapFrom(propFrom => propFrom.login)).ReverseMap();
        CreateMap<User, UserEntity>()
            .ForMember(prop => prop.Name
                , options =>
                    options.MapFrom(propFrom => propFrom.name)).ReverseMap();
        CreateMap<User, UserEntity>()
            .ForMember(prop => prop.Password
                , options =>
                    options.MapFrom(propFrom => propFrom.password)).ReverseMap();
        CreateMap<User, UserEntity>()
            .ForMember(prop => prop.Phone
                , options =>
                    options.MapFrom(propFrom => propFrom.phone)).ReverseMap();
        CreateMap<User, UserEntity>()
            .ForMember(prop => prop.Phone
                , options =>
                    options.MapFrom(propFrom => propFrom.phone)).ReverseMap();
        CreateMap<User, UserEntity>()
            .ForMember(prop => prop.Birth
                , options =>
                    options.MapFrom(propFrom => propFrom.birth)).ReverseMap();
    }
}