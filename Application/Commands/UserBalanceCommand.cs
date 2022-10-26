using MediatR;
using Shared.DataTransferObjects;

namespace Application.Commands;

public sealed record UserBalanceCommand(UserBalanceDto User) : IRequest<WalletDto>;
