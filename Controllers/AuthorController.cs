using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiPrimerWebApiM3.Contexts;
using MiPrimerWebApiM3.Models;
using MiPrimerWebApiM3.Entities;
using AutoMapper;

namespace MiPrimerWebApiM3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public AuthorController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET api/author
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> Get()
        {
            var authors= await context.Authors.ToListAsync();
            var authorsDTO = mapper.Map<List<AuthorDTO>>(authors);
            return authorsDTO;
        }

        // GET api/author/5
        [HttpGet("{id}", Name = "GetAutor")]
        public async Task<ActionResult<AuthorDTO>> Get(int id)
        {
            var author = await context.Authors.Include(x => x.Books).FirstOrDefaultAsync(x => x.Id == id);
            if (author == null)
            {
                return NotFound();
            }
            var authorDTO = mapper.Map<AuthorDTO>(author);
            return authorDTO;
        }

        // POST api/author
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Author author)
        {
            context.Authors.Add(author);
            await context.SaveChangesAsync();
            var authorDTO = mapper.Map<AuthorDTO>(author);
            return new CreatedAtRouteResult("GetAutor", new { id = author.Id }, authorDTO);
        }

        // PUT api/author/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Author value)
        {
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
        public async Task<ActionResult<Author>> Delete(int id)
        {
            var author = await context.Authors.FirstOrDefaultAsync(x => x.Id == id);

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