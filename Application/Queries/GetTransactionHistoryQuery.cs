using MediatR;
using Shared.DataTransferObjects;

namespace Application.Queries;

public sealed record GetTransactionHistoryQuery(Guid Id) : IRequest<TransactionHistoryDto>;
