using Application.Commands;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Handlers;

internal sealed class WalletWithdrawalHandler : IRequestHandler<CreateWalletWithdrawalCommand, WalletDto>
{
	private readonly IRepositoryManager _repository;
	private readonly IMapper _mapper;

	public WalletWithdrawalHandler(IRepositoryManager repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<WalletDto> Handle(CreateWalletWithdrawalCommand request, CancellationToken cancellationToken)
	{
        var walletEntity = _mapper.Map<Wallet>(request.Wallet);

        var wallet = await  _repository.Wallet.GetWalletAsync(walletEntity.UserId, walletEntity.Currency);
      
        if (walletEntity.Amount > wallet.Amount)
            throw new InsufficientFundException("Dear customer, you have insufficient fund.");

        wallet.Amount -= walletEntity.Amount;

        var walletToReturn = _mapper.Map<WalletDto>(walletEntity);

        await _repository.SaveAsync();
        TransactionHistory transaction = new TransactionHistory();

        transaction.Id = Guid.NewGuid();
        transaction.UserId = wallet.UserId;
        transaction.CreatedDate = wallet.CreatedDate;
        transaction.UpdatedDate = wallet.UpdatedDate;
        transaction.TransactionType = "Account Withdrawal";
        transaction.TransactionAmount = wallet.Amount;
        //transaction.TransactionType = userEntity.Wallets.First().Currency;
        await _repository.TransactionHistory.CreateUserTransaction(transaction);

        return walletToReturn;
    }

	
}
