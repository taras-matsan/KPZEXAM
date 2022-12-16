using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.Models;

namespace WEB.Controllers
{
	[Route("[controller]")]
	public class ReviewController : Controller
	{
		FilmListDBContext _context;
		public ReviewController()
		{
			_context = new FilmListDBContext();
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_context.Reviews.ToList());
		}

		int nextId => _context.Reviews.ToList().Count == 0 ? 1 : _context.Reviews.Max(x => x.ReviewId) + 1;

		[HttpPost]
		public IActionResult Post(Review Review)
		{
			Review.ReviewId = nextId;
			_context.Reviews.Add(Review);
			return Ok(Review);
		}

		[HttpPut]
		public IActionResult Put(Review Review)
		{
			var newReview = _context.Reviews.ToList().SingleOrDefault(x => x.ReviewId == Review.ReviewId);
			if (newReview == null) return NotFound();
			newReview.ReviewText = Review.ReviewText;
			return Ok(newReview);
		}

		[HttpPost]
		public IActionResult PostBody([FromBody] Review review) => Post(review);

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_context.Reviews.Remove(_context.Reviews.SingleOrDefault(x => x.ReviewId == id));
			return Ok();
		}
	}
}
