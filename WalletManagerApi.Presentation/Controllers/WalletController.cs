using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Queries;
using Shared.DataTransferObjects;
using Application.Commands;
using Application.Notifications;

namespace WalletAppApi.Presentation.Controllers;

[Route("api/wallets")]
[ApiController]
public class WalletController : ControllerBase
{
	private readonly ISender _sender;
	private readonly IPublisher _publisher;

	public WalletController(ISender sender, IPublisher publisher)
	{
		_sender = sender;
		_publisher = publisher;
	}

	[HttpGet]
	public async Task<IActionResult> GetWallets()
	{
		var wallets = await _sender.Send(new GetWalletsQuery(TrackChanges: false));

		return Ok(wallets);
	}

	[HttpGet("{id:guid}", Name = "WalletById")]
	public async Task<IActionResult> GetWallet(Guid id)
	{
		var wallet = await _sender.Send(new GetWalletQuery(id, TrackChanges: false));

		return Ok(wallet);
	}

    [HttpGet("balance/{id:guid}", Name = "WalletBalanceById")]
    public async Task<IActionResult> GetWalletBalance(Guid id)
    {
        var wallet = await _sender.Send(new GetUserBalanceQuery(id));

        return Ok(wallet);
    }

    [HttpGet("{id:guid}/{currency}", Name = "WalletById_Currency")]
    public async Task<IActionResult> GetWalletCurrency(Guid id, string currency)
    {
        var wallet = await _sender.Send(new GetWalletQueryCurrency(id, currency));

        return Ok(wallet);
    }

    [HttpPost]
	public async Task<IActionResult> CreateWallet([FromBody] WalletUserForCreationDto walletUserForCreationDto)
	{
		var wallet = await _sender.Send(new CreateWalletCommand(walletUserForCreationDto));

		return CreatedAtRoute("WalletById", new { id = wallet.Id }, wallet);
	}

    [HttpPut("top_up")]
    public async Task<IActionResult> TopUpWallet(WalletUserTopUpDto walletUser)
    {
        if (walletUser is null)
            return BadRequest("WalletUserTopUpDto object is null");

        await _sender.Send(new TopUpWalletCommand(walletUser));

        return NoContent();
    }


    [HttpPost("withdraw_money")]
    public async Task<IActionResult> WithdrawMoney([FromBody] WalletUserWithdrawDto walletUser)
    {
        var wallet = await _sender.Send(new CreateWalletWithdrawalCommand(walletUser));

        return CreatedAtRoute("WalletById", new { id = wallet.Id }, wallet);
    }

}
