using Application.Queries;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Handlers;

internal sealed class GetUserHandler : IRequestHandler<GetUserQuery, UserDto>
{
	private readonly IRepositoryManager _repository;
	private readonly IMapper _mapper;

	public GetUserHandler(IRepositoryManager repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
	{
		var user = await _repository.User.GetUserAsync(request.Id, request.TrackChanges);
		if (user is null)
			throw new UserNotFoundException(request.Id);

		var userDto = _mapper.Map<UserDto>(user);

		return userDto;
	}
}
