using MediatR;
using Shared.DataTransferObjects;

namespace Application.Commands;

public sealed record CreateUserCommand(UserForCreationDto User) : IRequest<UserDto>;
