using Application.Models.Dtos.Ledgers;
using Application.Models.Dtos.Users;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, AddUserDto>().ReverseMap();
            CreateMap<User, GetAllUserDto>().ReverseMap();
            CreateMap<User, GetUserDto>()
                .ForMember(d => d.Ledgers, o => o.MapFrom(s => s.Ledgers))
                .ReverseMap();
            CreateMap<User, UpdateUserInfoDto>().ReverseMap();
            CreateMap<UpdateBalanceDto, User>()
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Amount)).ReverseMap();

            CreateMap<Ledger, GetLedgerDto>().ReverseMap();
        }        
    }
}
