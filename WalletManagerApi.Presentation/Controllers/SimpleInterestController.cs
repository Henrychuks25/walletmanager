using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Queries;
using Shared.DataTransferObjects;
using Application.Commands;
using Application.Notifications;

namespace WalletAppApi.Presentation.Controllers;

[Route("api/simple_interest")]
[ApiController]
public class SimpleInterestController : ControllerBase
{
	private readonly ISender _sender;
	private readonly IPublisher _publisher;

	public SimpleInterestController(ISender sender, IPublisher publisher)
	{
		_sender = sender;
		_publisher = publisher;
	}

	

    [HttpPost]
	public async Task<IActionResult> CreateWallet()
	{
		var wallet = await _sender.Send(new CreateSimpleInterestCommand(TrackChanges: false));

		return NoContent();
	}

   

}
