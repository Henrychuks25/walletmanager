using Application.Queries;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Handlers;

internal sealed class GetTransactionsHistoryHandler : IRequestHandler<GetTransactionsHistoryQuery, IEnumerable<TransactionHistoryDto>>
{
	private readonly IRepositoryManager _repository;
	private readonly IMapper _mapper;

	public GetTransactionsHistoryHandler(IRepositoryManager repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<TransactionHistoryDto>> Handle(GetTransactionsHistoryQuery request, CancellationToken cancellationToken)
	{
		var transaction = await _repository.TransactionHistory.GetAllTransactionsAsync(request.TrackChanges);
		if (!transaction.Any())
			throw new KeyNotFoundException("No transaction available at the moment");

  

        var transDto = _mapper.Map<IEnumerable<TransactionHistory>, List<TransactionHistoryDto>>(transaction);

        //var transDto = _mapper.Map < IEnumerable<TransactionHistoryDto>>(transaction);

		return transDto;
	}
}
