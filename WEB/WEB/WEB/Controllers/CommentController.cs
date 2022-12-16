using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.Models;

namespace WEB.Controllers
{
	[Route("[controller]")]
	public class CommentController : Controller
	{
		FilmListDBContext _context;
		public CommentController() 
		{
			_context = new FilmListDBContext();
		}

		[HttpGet]
		public IActionResult Get() 
		{
			return Ok(_context.Comments.ToList());
		}

		int nextId => _context.Comments.ToList().Count == 0 ? 1 : _context.Comments.Max(x => x.CommentId) + 1;

		[HttpPost]
		public IActionResult Post(Comment Comment)
		{
			Comment.CommentId = nextId;
			_context.Comments.Add(Comment);
			return Ok(Comment);
		}

		[HttpPost]
		public IActionResult PostBody([FromBody] Comment comment) => Post(comment);

		[HttpPut]
		public IActionResult Put(Comment Comment)
		{
			var newComment = _context.Comments.ToList().SingleOrDefault(x => x.CommentId == Comment.CommentId);
			if (newComment == null) return NotFound() ;
			newComment.CommentText = Comment.CommentText;
			return Ok(newComment);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_context.Films.Remove(_context.Films.SingleOrDefault(x => x.FilmId == id));
			return Ok();
		}
	}
}
