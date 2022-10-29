using Application.Queries;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Handlers;

internal sealed class GetWalletsBalanceHandler : IRequestHandler<GetWalletsBalanceQuery, IEnumerable<WalletDto>>
{
	private readonly IRepositoryManager _repository;
	private readonly IMapper _mapper;

	public GetWalletsBalanceHandler(IRepositoryManager repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}
   
    public async Task<IEnumerable<WalletDto>> Handle(GetWalletsBalanceQuery request, CancellationToken cancellationToken)
	{
		var wallet = await _repository.Wallet.GetAllWalletByUserIdAsync(request.userId);
		

		var walletDto = _mapper.Map <IEnumerable<WalletDto>>(wallet);

		return walletDto;
	}
}
