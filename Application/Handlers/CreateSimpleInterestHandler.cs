using Application.Commands;
using AutoMapper;
using Contracts;
using Entities.Models;
using MediatR;
using Shared.DataTransferObjects;
using BCrypt.Net;
using Application.Queries;

namespace Application.Handlers;

internal sealed class CreateSimpleInterestHandler : IRequestHandler<CreateSimpleInterestCommand, IEnumerable<WalletDto>>
{
	private readonly IRepositoryManager _repository;
	private readonly IMapper _mapper;

	public CreateSimpleInterestHandler(IRepositoryManager repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}
    public async Task<IEnumerable<WalletDto>> Handle(CreateSimpleInterestCommand request, CancellationToken cancellationToken)
    {
        var wallet = await _repository.SimpleInterest.ProcessInterests(request.TrackChanges);


        var walletDto = _mapper.Map<IEnumerable<WalletDto>>(wallet);

        return walletDto;
    }

 //   public async Task<SimpleInterestDto> Handle(CreateSimpleInterestCommand request, CancellationToken cancellationToken)
	//{
		
	//	var newWallet = await _repository.Wallet.GetWalletAsync(request.SimpleInterest.UserId, request.SimpleInterest.currency);

 //       _repository.SimpleInterest.CreateSimpleInterest(newWallet.Id, newWallet.Currency);
 //       await _repository.SaveAsync();
        

	

	//	var userResult = _mapper.Map<SimpleInterestDto>(newWallet);

	//	return userResult;
	//}
}
