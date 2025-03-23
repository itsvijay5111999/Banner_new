// Controllers/BannerController.cs
using Firstwebapi.Models;
using Microsoft.AspNetCore.Mvc;



namespace Firstwebapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BannerController : ControllerBase
    {
        private static readonly List<Banner> Banners = new()
        {
            new Banner { Id = 1, Title = "Summer Sale", Description = "Enjoy up to 50% off!", ImageUrl = "https://example.com/summer.jpg" },
            new Banner { Id = 2, Title = "Winter Fest", Description = "Cozy deals just for you.", ImageUrl = "https://example.com/winter.jpg" },
            new Banner { Id = 3, Title = "Spring Clearance", Description = "Fresh deals blooming now!", ImageUrl = "https://example.com/spring.jpg" }
        };

        // GET: api/banner
        [HttpGet]
        public IActionResult GetAllBanners()
        {
            return Ok(Banners);
        }

        // GET: api/banner/2
        [HttpGet("{id}")]
        public IActionResult GetBannerById(int id)
        {
            var banner = Banners.FirstOrDefault(b => b.Id == id);
            if (banner == null)
            {
                return NotFound($"Banner with ID {id} not found.");
            }
            return Ok(banner);
        }

        // GET: api/banner/welcome
        [HttpGet("welcome")]
        public IActionResult WelcomeMessage()
        {
            return Ok("Welcome to the Banner API!");
        }

        // GET: api/banner/random
        [HttpGet("random")]
        public IActionResult GetRandomBanner()
        {
            var randomBanner = Banners[Random.Shared.Next(Banners.Count)];
            return Ok(randomBanner);
        }
    }
}
