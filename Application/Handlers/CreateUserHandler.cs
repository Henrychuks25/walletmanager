using Application.Commands;
using AutoMapper;
using Contracts;
using Entities.Models;
using MediatR;
using Shared.DataTransferObjects;

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

		_repository.User.Create(userEntity);
		await _repository.SaveAsync();

		var userResult = _mapper.Map<UserDto>(userEntity);

		return userResult;
	}
}
