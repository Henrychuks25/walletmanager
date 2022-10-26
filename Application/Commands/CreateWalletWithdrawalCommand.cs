using MediatR;
using Shared.DataTransferObjects;

namespace Application.Commands;

public sealed record CreateWalletWithdrawalCommand(WalletUserWithdrawDto Wallet) : IRequest<WalletDto>;
