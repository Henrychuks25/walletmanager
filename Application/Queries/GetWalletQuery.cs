using MediatR;
using Shared.DataTransferObjects;

namespace Application.Queries;

public sealed record GetWalletQuery(Guid Id,  bool TrackChanges) : IRequest<WalletDto>;
