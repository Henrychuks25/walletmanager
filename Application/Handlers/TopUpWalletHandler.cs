﻿using Application.Commands;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Handlers;

internal sealed class TopUpWalletHandler : IRequestHandler<TopUpWalletCommand, WalletDto>
{
	private readonly IRepositoryManager _repository;
	private readonly IMapper _mapper;

	public TopUpWalletHandler(IRepositoryManager repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<WalletDto> Handle(TopUpWalletCommand request, CancellationToken cancellationToken)
	{
        var walletEntity = _mapper.Map<Wallet>(request.Wallet);

        var wallet = await  _repository.Wallet.GetWalletAsync(walletEntity.UserId, walletEntity.Currency);
        if (wallet is null)
            throw new KeyNotFoundException("Operation not successful");

        wallet.Amount += walletEntity.Amount;

        var walletToReturn = _mapper.Map<WalletDto>(walletEntity);

        await _repository.SaveAsync();


        return walletToReturn;
    }

	
}
