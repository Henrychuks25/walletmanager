using Application.Commands;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Handlers;

internal sealed class CreateWalletHandler : IRequestHandler<CreateWalletCommand, WalletDto>
{
	private readonly IRepositoryManager _repository;
	private readonly IMapper _mapper;

	public CreateWalletHandler(IRepositoryManager repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<WalletDto> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
	{
		var walletEntity = _mapper.Map<Wallet>(request.Wallet);
        var user = await _repository.User.Get(request.Wallet.userId);
        if (user is null || user.Wallets.FirstOrDefault(x => x.Currency == walletEntity.Currency) != null) 
			// this wallet already exist
            throw new KeyNotFoundException() ;

        
        _repository.Wallet.CreateWallet(walletEntity.UserId, walletEntity.Currency);
		await _repository.SaveAsync();

		var walletToReturn = _mapper.Map<WalletDto>(walletEntity);

		return walletToReturn;
	}
}
