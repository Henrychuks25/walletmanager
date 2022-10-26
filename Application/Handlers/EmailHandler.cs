using Application.Notifications;
using Contracts;
using MediatR;

namespace Application.Handlers;

internal sealed class EmailHandler : INotificationHandler<WalletTopUpNotification>
{
	private readonly ILoggerManager _logger;

	public EmailHandler(ILoggerManager logger) => _logger = logger;

	public async Task Handle(WalletTopUpNotification notification, CancellationToken cancellationToken)
	{
		_logger.LogInfo($"wallet top for userid: {notification.Id} was successful.");

		await Task.CompletedTask;
	}
}
