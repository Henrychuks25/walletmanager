using Application.Queries;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Handlers;

internal sealed class GetUserBalanceHandler : IRequestHandler<GetUserBalanceQuery, IEnumerable<UserBalanceDto>>
{
	private readonly IRepositoryManager _repository;
	private readonly IMapper _mapper;

	public GetUserBalanceHandler(IRepositoryManager repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<UserBalanceDto>> Handle(GetUserBalanceQuery request, CancellationToken cancellationToken)
	{
		var user = await _repository.Wallet.GetWalletsBalance(request.Id);
		if (user is null)
			throw new UserNotFoundException(request.Id);
		

		var userDto = _mapper.Map<IEnumerable<UserBalanceDto>>(user);

		return userDto;
	}
}
