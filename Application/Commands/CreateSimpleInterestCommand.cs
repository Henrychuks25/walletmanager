using MediatR;
using Shared.DataTransferObjects;

namespace Application.Commands;

public sealed record CreateSimpleInterestCommand(bool TrackChanges) :IRequest<IEnumerable<WalletDto>>;
