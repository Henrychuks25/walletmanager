﻿using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace WalletAppApi;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		
		CreateMap<User, UserDto>();
		CreateMap<Wallet, WalletDto>();

		CreateMap<WalletUserForCreationDto, Wallet>();
		CreateMap<WalletUserTopUpDto, Wallet>();
		CreateMap<WalletUserTransferDto, Wallet>();
		CreateMap<WalletUserWithdrawDto, Wallet>();
		CreateMap<UserForCreationDto, User>();

		CreateMap<UserForUpdateDto, User>();
	}
}
