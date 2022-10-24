using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Queries;
using Shared.DataTransferObjects;
using Application.Commands;
using Application.Notifications;

namespace WalletAppApi.Presentation.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
	private readonly ISender _sender;
	private readonly IPublisher _publisher;

	public UserController(ISender sender, IPublisher publisher)
	{
		_sender = sender;
		_publisher = publisher;
	}

	//[HttpGet]
	//public async Task<IActionResult> Get()
	//{
	//	var user = await _sender.Send(new Get(TrackChanges: false));

	//	return Ok(user);
	//}

	[HttpGet("{id:guid}", Name = "UserById")]
	public async Task<IActionResult> Get(Guid id)
	{
		var user = await _sender.Send(new GetUserQuery(id, TrackChanges: false));

		return Ok(user);
	}

	[HttpPost]
	public async Task<IActionResult> Create([FromBody] UserForCreationDto userForCreationDto)
	{
		var user = await _sender.Send(new CreateUserCommand(userForCreationDto));

		return CreatedAtRoute("UserById", new { id = user.Id }, user);
	}

	//[HttpPut("{id:guid}")]
	//public async Task<IActionResult> UpdateCompany(Guid id, UserForUpdateDto userForUpdateDto)
	//{
	//	if (userForUpdateDto is null)
	//		return BadRequest("UserForUpdateDto object is null");

	//	await _sender.Send(new UpdateUserCommand(id, userForUpdateDto, TrackChanges: true));

	//	return NoContent();
	//}

	//[HttpDelete("{id:guid}")]
	//public async Task<IActionResult> DeleteCompany(Guid id)
	//{
	//	await _publisher.Publish(new UserDeletedNotification(id, TrackChanges: false));

	//	return NoContent();
	//}
}
