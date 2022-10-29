using MediatR;
using Shared.DataTransferObjects;

namespace Application.Commands;

public sealed record CreateSimpleInterestCommand(SimpleInterestForCreationDto SimpleInterest) : IRequest<SimpleInterestDto>;
