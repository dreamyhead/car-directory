
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project1.Models;

namespace Project1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarItemsController : ControllerBase
    {
        private readonly CarContext _context;

        public CarItemsController(CarContext context)
        {
            _context = context;
        }

        // GET: /CarItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCarItems()
        {
            return await _context.Cars.ToListAsync();
        }

        // GET: /CarItems/BMW
        [HttpGet("{brand}")]
        public async Task<List<Car>> GetCarItems(string brand)
        {
            var carItems = await _context.Cars
                .Where(b => b.Brand.Contains(brand))
                .ToListAsync();
            return carItems;
        }

        // POST: /CarItems
        [HttpPost]
        public async Task<ActionResult<Car>> PostCarItems(Car carItems)
        {
            _context.Cars.Add(carItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarItems), new { id = carItems.Id }, carItems);
        }

        // DELETE: /CarItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarItems(long id)
        {
            var carItems = await _context.Cars.FindAsync(id);
            if (carItems == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(carItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarItemsExists(long id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
