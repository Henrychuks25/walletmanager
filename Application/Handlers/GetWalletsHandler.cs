using Application.Queries;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Handlers;

internal sealed class GetWalletsHandler : IRequestHandler<GetWalletsQuery, IEnumerable<WalletDto>>
{
	private readonly IRepositoryManager _repository;
	private readonly IMapper _mapper;

	public GetWalletsHandler(IRepositoryManager repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}
   
    public async Task<IEnumerable<WalletDto>> Handle(GetWalletsQuery request, CancellationToken cancellationToken)
	{
		var wallet = await _repository.Wallet.GetAllWalletAsync(request.TrackChanges);
		

		var walletDto = _mapper.Map <IEnumerable<WalletDto>>(wallet);

		return walletDto;
	}
}
