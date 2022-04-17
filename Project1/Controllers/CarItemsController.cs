
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project1.Models;
using Project1.Services;

namespace Project1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarItemsController : ControllerBase
    {

        private readonly CarsService _carsService;
        private readonly ILogger _logger;

        public CarItemsController(CarsService carsService, ILogger<CarItemsController> logger)
        {
            _carsService = carsService;
            _logger = logger;
        }

        // GET: /CarItems
        [HttpGet]
        public async Task<List<Car>> Get() {
            _logger.LogInformation("GET: /caritems");
            return await _carsService.GetAsync();
        }

        // GET: /CarItems/BMW
        [HttpGet("{brand}")]
        public async Task<List<Car>> Get(string brand) {
            _logger.LogInformation("GET: /caritems/brand");
            return await _carsService.GetAsync(brand);
        }

        // POST: /CarItems
        [HttpPost]
        public async Task<IActionResult> Post(Car newCar)
        {
            _logger.LogInformation("POST: /caritems");
            await _carsService.CreateAsync(newCar);

            return CreatedAtAction(nameof(Get), new { id = newCar.Id }, newCar);
        }

        // DELETE: /CarItems/5
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            _logger.LogInformation("DELETE: /caritems/{id}");
            var book = await _carsService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _carsService.RemoveAsync(id);

            return NoContent();
        }
    }
}
