using MediatR;
using Shared.DataTransferObjects;

namespace Application.Queries;

public sealed record GetUserBalanceQuery(Guid Id) : IRequest<UserBalanceDto>;
