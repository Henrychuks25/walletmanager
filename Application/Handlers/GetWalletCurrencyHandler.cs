using Application.Queries;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Handlers;

internal sealed class GetWalletCurrencyHandler : IRequestHandler<GetWalletQueryCurrency, WalletDto>
{
	private readonly IRepositoryManager _repository;
	private readonly IMapper _mapper;

	public GetWalletCurrencyHandler(IRepositoryManager repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<WalletDto> Handle(GetWalletQueryCurrency request, CancellationToken cancellationToken)
	{
		var company = await _repository.Wallet.GetWalletAsync(request.Id, request.currency);
		if (company is null)
			throw new UserNotFoundException(request.Id);

		var userDto = _mapper.Map<WalletDto>(company);

		return userDto;
	}
}
