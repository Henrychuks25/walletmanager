using MediatR;
using Shared.DataTransferObjects;

namespace Application.Queries;

public sealed record GetWalletsQuery(bool TrackChanges) : IRequest<IEnumerable<WalletDto>>;
