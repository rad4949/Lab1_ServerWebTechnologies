using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[EnableCors("ReactMovies")]
[Route("api/movies")]
[ApiController]
public class MoviesController : Controller
{
    private readonly TMDbApiClient _tmdbApiClient;

    public MoviesController(TMDbApiClient tmdbApiClient)
    {
        _tmdbApiClient = tmdbApiClient;
    }

    [HttpGet("popular")]
    public async Task<IActionResult> GetPopularMovies()
    {
        try
        {
            var movies = await _tmdbApiClient.GetPopularMovies();
            return Ok(movies);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
