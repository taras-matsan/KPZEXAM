using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.Models;

namespace WEB.Controllers
{
	[Route("[controller]")]
	public class SubscriberController : Controller
	{
		FilmListDBContext _context;
		public SubscriberController()
		{
			_context = new FilmListDBContext();
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_context.Subscribers.ToList());
		}

		int nextId => _context.Subscribers.ToList().Count == 0 ? 1 : _context.Subscribers.Max(x => x.SubscriberId) + 1;

		[HttpPost]
		public IActionResult Post(Subscriber Subscriber)
		{
			Subscriber.SubscriberId = nextId;
			_context.Subscribers.Add(Subscriber);
			return Ok(Subscriber);
		}

		[HttpPut]
		public IActionResult Put(Subscriber Subscriber)
		{
			var newSubscriber = _context.Subscribers.ToList().SingleOrDefault(x => x.SubscriberId == Subscriber.SubscriberId);
			if (newSubscriber == null) return NotFound();
			newSubscriber.SubscriberNick = Subscriber.SubscriberNick;
			return Ok(newSubscriber);
		}


		[HttpPost]
		public IActionResult PostBody([FromBody] Subscriber subscriber) => Post(subscriber);

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_context.Subscribers.Remove(_context.Subscribers.SingleOrDefault(x => x.SubscriberId == id));
			return Ok();
		}
	}
}
