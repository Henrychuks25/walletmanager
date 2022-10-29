using MediatR;
using Shared.DataTransferObjects;

namespace Application.Queries;

public sealed record GetWalletsBalanceQuery(Guid userId) : IRequest<IEnumerable<WalletDto>>;
