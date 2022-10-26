using MediatR;
using Shared.DataTransferObjects;

namespace Application.Commands;

public sealed record CreateWalletCommand(WalletUserForCreationDto Wallet) : IRequest<WalletDto>;
