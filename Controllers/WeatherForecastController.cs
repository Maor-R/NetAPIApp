using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{


    [ApiController]
    [Route("[controller]")] //or if you want [Route("api/GetWeatherForecast")]
    public class WeatherForecastController : Controller
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

         private readonly WeatherForecastDBContext _context;
        public WeatherForecastController(WeatherForecastDBContext  context)
        {
            _context = context;
        }


         [HttpGet("/bb/{id:int}")]  // GET /bb/2
         public IEnumerable<WeatherForecast> Get2(int id)
        {
            Console.WriteLine("test{0}", id);

            _context.wf.Add(new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });
            _context.SaveChanges();
            Console.WriteLine("test2");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }




        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            
            _context.wf.Add(new WeatherForecast {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });
            _context.SaveChanges();
            Console.WriteLine("test");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        
        }


        // DELETE: api/DCandidate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WeatherForecast>> DeleteDCandidate(int id)
        {
            var dCandidate = await _context.wf.FindAsync(id);
            if (dCandidate == null)
            {
                return NotFound();
            }

            _context.wf.Remove(dCandidate);
            await _context.SaveChangesAsync();

            return dCandidate;
        
        }


        // POST: api/DCandidate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<WeatherForecast>> PostDCandidate(WeatherForecast dCandidate)
        {
            _context.wf.Add(dCandidate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCandidate", new { id = dCandidate.Id }, dCandidate);
        }



    }
}
