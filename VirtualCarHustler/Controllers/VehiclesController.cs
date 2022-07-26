using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VirtualCarHustler.Models;

namespace VirtualCarHustler.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AllVehiclesController : ControllerBase
    {
        private DataContext _dataContext;
        public AllVehiclesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int count = 10)
        {
            var vehiclesToReturn = await _dataContext.Vehicles
                .Skip((page - 1) * count)
                .Take(count)
                .ToListAsync();

            return Ok(vehiclesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _dataContext.Vehicles.FirstOrDefaultAsync(elem => elem.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleModel taskToCreate)
        {
            await _dataContext.Vehicles.AddAsync(taskToCreate);
            await _dataContext.SaveChangesAsync();
            return CreatedAtAction("GetById", new { taskToCreate.Id }, taskToCreate);
        }

    }
}
