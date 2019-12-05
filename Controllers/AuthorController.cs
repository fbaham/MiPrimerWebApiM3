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
    public class AuthorController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public AuthorController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET api/author
        [HttpGet("")]
        public ActionResult<IEnumerable<Author>> Get()
        {
            return context.Authors.ToList();
        }

        // GET api/author/5
        [HttpGet("{id}", Name = "GetAutor")]
        public ActionResult<Author> Get(int id)
        {
            var author = context.Authors.FirstOrDefault(x => x.Id == id);
            if (author == null)
            {
                return NotFound();
            }
            return author;
        }

        // POST api/author
        [HttpPost("")]
        public ActionResult Post([FromBody] Author author)
        {
            context.Authors.Add(author);
            context.SaveChanges();
            return new CreatedAtRouteResult("GetAutor", new { id = author.Id }, author);
        }

        // PUT api/author/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Author value)
        {
            // Esto no es necesario en asp.net core 2.1
            // if (ModelState.IsValid){

            // }

            if (id != value.Id)
            {
                return BadRequest();
            }

            context.Entry(value).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        // DELETE api/author/5
        [HttpDelete("{id}")]
        public ActionResult<Author> Delete(int id)
        {
            var author = context.Authors.FirstOrDefault(x => x.Id == id);

            if (author == null)
            {
                return NotFound();
            }

            context.Authors.Remove(author);
            context.SaveChanges();
            return author;
        }
    }
}