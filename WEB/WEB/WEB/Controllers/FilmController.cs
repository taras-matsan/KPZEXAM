using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.Models;

namespace WEB.Controllers
{
	[Route("[controller]")]
	public class FilmController : Controller
	{
		FilmListDBContext _context;
		public FilmController() 
		{
			_context = new FilmListDBContext();
		}

		[HttpGet]
		public IActionResult Get() 
		{
			return Ok(_context.Films.ToList());
		}

		int nextId => _context.Films.ToList().Count == 0 ? 1 : _context.Films.Max(x => x.FilmId) + 1;

		[HttpPost]
		public IActionResult Post(Film film)
		{
			film.FilmId = nextId;
			_context.Films.Add(film);
			return Ok(film);
		}


		[HttpPost]
		public IActionResult PostBody([FromBody] Film film) => Post(film);

		[HttpPut]
		public IActionResult Put(Film film)
		{
			var newfilm = _context.Films.ToList().SingleOrDefault(x => x.FilmId == film.FilmId);
			if (newfilm == null) return NotFound() ;
			newfilm.FilmName = film.FilmName;
			newfilm.FilmPath = film.FilmPath;
			return Ok(newfilm);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id) 
		{
			_context.Films.Remove(_context.Films.SingleOrDefault(x => x.FilmId == id));
			return Ok();
		}
	}
}
