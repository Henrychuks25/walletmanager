using MediatR;
using Shared.DataTransferObjects;

namespace Application.Commands;

public sealed record CreateTransactionHistoryCommand(TransactionHistoryForCreationDto Transaction) : IRequest<TransactionHistoryDto>;
