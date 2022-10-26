using MediatR;
using Shared.DataTransferObjects;

namespace Application.Commands;

public sealed record TopUpWalletCommand(WalletUserTopUpDto Wallet) : IRequest<WalletDto>;
