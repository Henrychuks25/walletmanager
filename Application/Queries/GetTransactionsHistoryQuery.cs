using MediatR;
using Shared.DataTransferObjects;

namespace Application.Queries;

public sealed record GetTransactionsHistoryQuery(bool TrackChanges) : IRequest<IEnumerable<TransactionHistoryDto>>;
