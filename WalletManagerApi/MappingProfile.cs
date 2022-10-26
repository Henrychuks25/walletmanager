using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace WalletAppApi;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Company, CompanyDto>()
			.ForMember(c => c.FullAddress,
				opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
		CreateMap<User, UserDto>();
		CreateMap<Wallet, WalletDto>();

		CreateMap<CompanyForCreationDto, Company>();
		CreateMap<WalletUserForCreationDto, Wallet>();
		CreateMap<WalletUserTopUpDto, Wallet>();
		CreateMap<WalletUserTransferDto, Wallet>();
		CreateMap<WalletUserWithdrawDto, Wallet>();
		CreateMap<UserForCreationDto, User>();

		CreateMap<UserForUpdateDto, User>();
		CreateMap<CompanyForUpdateDto, Company>();
	}
}
