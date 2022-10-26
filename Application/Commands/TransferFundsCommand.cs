using MediatR;
using Shared.DataTransferObjects;

namespace Application.Commands;

public sealed record TransferFundsCommand(WalletUserTransferDto User) : IRequest<WalletDto>;
