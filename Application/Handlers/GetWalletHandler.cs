using Application.Queries;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Handlers;

internal sealed class GetWalletHandler : IRequestHandler<GetWalletQuery, WalletDto>
{
	private readonly IRepositoryManager _repository;
	private readonly IMapper _mapper;

	public GetWalletHandler(IRepositoryManager repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<WalletDto> Handle(GetWalletQuery request, CancellationToken cancellationToken)
	{
		var company = await _repository.Wallet.GetAsync(request.Id, request.TrackChanges);
		if (company is null)
			throw new UserNotFoundException(request.Id);

		var userDto = _mapper.Map<WalletDto>(company);

		return userDto;
	}
}
