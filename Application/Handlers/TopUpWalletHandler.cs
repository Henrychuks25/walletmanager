using Application.Commands;
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
		var walletEntity = _mapper.Map<Wallet>(request.User);
        var user = await _repository.User.Get(request.User.userId);
        if (user is null || user.Wallets.FirstOrDefault(x => x.Currency == walletEntity.Currency) != null) // wallet with such currency already exists
            throw new KeyNotFoundException() ;

        
        _repository.Wallet.CreateWallet(walletEntity.UserId, walletEntity.Currency);
		await _repository.SaveAsync();

		var walletToReturn = _mapper.Map<WalletDto>(walletEntity);

		return walletToReturn;
	}

	
}
