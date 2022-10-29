using Application.Queries;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Handlers;

internal sealed class GetTransactionHistoryHandler : IRequestHandler<GetTransactionHistoryQuery, TransactionHistoryDto>
{
	private readonly IRepositoryManager _repository;
	private readonly IMapper _mapper;

	public GetTransactionHistoryHandler(IRepositoryManager repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<TransactionHistoryDto> Handle(GetTransactionHistoryQuery request, CancellationToken cancellationToken)
	{
		var wallet = await _repository.TransactionHistory.GetTransactionAsync(request.Id);
		if (wallet is null)
			throw new UserNotFoundException(request.Id);

		var userDto = _mapper.Map<TransactionHistoryDto>(wallet);

		return userDto;
	}
}
