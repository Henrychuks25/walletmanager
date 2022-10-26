using Application.Commands;
using AutoMapper;
using Contracts;
using Entities.Models;
using MediatR;
using Shared.DataTransferObjects;
using BCrypt.Net;

namespace Application.Handlers;

internal sealed class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDto>
{
	private readonly IRepositoryManager _repository;
	private readonly IMapper _mapper;

	public CreateUserHandler(IRepositoryManager repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		var userEntity = _mapper.Map<User>(request.User);
		userEntity.Password = BCrypt.Net.BCrypt.HashPassword(request.User.Password);
		var newWallet = await _repository.Wallet.Get(userEntity.Id);
		if(newWallet == null)
		{
			_repository.Wallet.CreateWallet(userEntity.Id, "USD");
			_repository.Wallet.CreateWallet(userEntity.Id, "NGN");
		}

		_repository.User.Create(userEntity);
		await _repository.SaveAsync();

		var userResult = _mapper.Map<UserDto>(userEntity);

		return userResult;
	}
}
