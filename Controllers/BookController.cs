using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiPrimerWebApiM3.Contexts;
using MiPrimerWebApiM3.Entities;


namespace MiPrimerWebApiM3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public BookController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET api/book
        [HttpGet("")]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return context.Books.Include(x => x.Author).ToList();
        }

        // GET api/book/5
        [HttpGet("{id}", Name="GetBook")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await context.Books.Include(x => x.Author).FirstOrDefaultAsync(x => x.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // POST api/book
        [HttpPost("")]
        public ActionResult Post([FromBody] Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
            return new CreatedAtRouteResult("GetBook", new { id = book.Id }, book);
        }

        // PUT api/book/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }

            context.Entry(value).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }


        // DELETE api/book/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> Delete(int id)
        {
            var book = await context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            context.Books.Remove(book);
            context.SaveChanges();
            return book;
        }
    }
}