using MediatR;
using Shared.DataTransferObjects;

namespace Application.Queries;

public sealed record GetUserQuery(Guid Id, bool TrackChanges) : IRequest<UserDto>;
