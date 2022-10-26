using MediatR;

namespace Application.Notifications;

public sealed record WalletTopUpNotification(Guid Id, bool TrackChanges) : INotification;
