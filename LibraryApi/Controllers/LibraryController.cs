using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using trackingapi.Data;
using trackingapi.Models;

namespace trackingapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly LibraryDbContext _context;
        public LibraryController(LibraryDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Library>> GetList()
        {
            return await _context.Libraries.ToListAsync();
        }
        [HttpGet("id")]
        [ProducesResponseType(typeof(Library), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _context.Libraries.FindAsync(id);
            return book == null ? NotFound() : Ok(book);   
        }
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Create(Library library)
        {
            await _context.Libraries.AddAsync(library);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById),new { id= library.Id }, library);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Library book)
        {
            if (id != book.Id) return BadRequest();
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        //kodda değişiklik yapıldı
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete (int id, Library book)
        {
            var bookToDelete = await _context.Libraries.FindAsync(id);
            if (bookToDelete == null) return NotFound();
            _context.Libraries.Remove(bookToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
