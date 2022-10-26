using MediatR;
using Shared.DataTransferObjects;

namespace Application.Queries;

public sealed record GetWalletQueryCurrency(Guid Id, string currency) : IRequest<WalletDto>;
