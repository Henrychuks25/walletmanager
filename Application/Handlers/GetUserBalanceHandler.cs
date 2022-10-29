using Application.Queries;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Handlers;

internal sealed class GetUserBalanceHandler : IRequestHandler<GetUserBalanceQuery, UserBalanceDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetUserBalanceHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserBalanceDto> Handle(GetUserBalanceQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.Wallet.GetWalletsBalance(request.Id);

        var userBal = new UserBalanceDto();

       

        //var userBal = new IEnumerable<UserBalanceDto>();

        if (user is null)
            throw new UserNotFoundException(request.Id);

        foreach (var item in user)
        {
            userBal.Email = item.Email;
            userBal.FirstName = item.FirstName;
            userBal.LastName = item.LastName;
            //userBal.NGNWallet = item.NGNWallet;
            //userBal.USDWallet = item.USDWallet;
            //userBal.Amount = item.Amount;


            foreach (var item2 in item.Wallets)
            {
                if (item2.Currency.Contains("NGN"))
                {
                    userBal.NGNWallet = item2.Currency;
                    userBal.Amount = item2.Amount;
                   

                }
                

            }


        }



        return userBal;
    }
    //   public async Task<IEnumerable<UserBalanceDto>> Handle(GetUserBalanceQuery request, CancellationToken cancellationToken)
    //{
    //	var user = await _repository.Wallet.GetWalletsBalance(request.Id);
    //       var userBal = new UserBalanceDto();

    //       if (user is null)
    //		throw new UserNotFoundException(request.Id);
    //	foreach(var item in user)
    //	{
    //		userBal.Email = item.Email;
    //		userBal.FirstName = item.FirstName;
    //		userBal.LastName = item.LastName;

    //		foreach(var item2 in item.Wallets)
    //		userBal.NGNWallet = item2.Currency;

    //	}


    //	var userDto = _mapper.Map<IEnumerable<UserBalanceDto>>(user);

    //	return userBal;
    //}
}
