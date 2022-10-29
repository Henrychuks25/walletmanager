using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Queries;
using Shared.DataTransferObjects;
using Application.Commands;
using Application.Notifications;

namespace WalletAppApi.Presentation.Controllers;

[Route("api/transaction_history")]
[ApiController]
public class TransactionHistoryController : ControllerBase
{
	private readonly ISender _sender;
	private readonly IPublisher _publisher;

	public TransactionHistoryController(ISender sender, IPublisher publisher)
	{
		_sender = sender;
		_publisher = publisher;
	}

	[HttpGet]
	public async Task<IActionResult> GetWallets()
	{
		var wallets = await _sender.Send(new GetTransactionsHistoryQuery(TrackChanges: false));

		return Ok(wallets);
	}

	[HttpGet("{userId:guid}", Name = "TransactionHistoryById")]
	public async Task<IActionResult> GetTransactionHistory(Guid id)
	{
		var wallet = await _sender.Send(new GetTransactionHistoryQuery(id));

		return Ok(wallet);
	}

  



   
}
