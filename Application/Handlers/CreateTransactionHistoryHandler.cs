using Application.Commands;
using AutoMapper;
using Contracts;
using Entities.Models;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Handlers;

internal sealed class CreateTransactionHistoryHandler : IRequestHandler<CreateTransactionHistoryCommand, TransactionHistoryDto>
{
	private readonly IRepositoryManager _repository;
	private readonly IMapper _mapper;

	public CreateTransactionHistoryHandler(IRepositoryManager repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<TransactionHistoryDto> Handle(CreateTransactionHistoryCommand request, CancellationToken cancellationToken)
	{
        var walletEntity = _mapper.Map<TransactionHistory>(request.Transaction);
        var user = await _repository.Wallet.Get(request.Transaction.UserId);
        if (user is null)
            // this wallet already exist
            throw new KeyNotFoundException();


        _repository.TransactionHistory.CreateUserTransaction(walletEntity);
        await _repository.SaveAsync();

        var walletToReturn = _mapper.Map<TransactionHistoryDto>(walletEntity);

        return walletToReturn;
    }
}
