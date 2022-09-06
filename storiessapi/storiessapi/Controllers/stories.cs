using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using storiessapi.DTO;
using storiessapi.Model;

namespace storiessapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class stories : ControllerBase
    {
        private readonly stdbcontextr _context;

        public stories(stdbcontextr context)
        {
            _context = context;
        }

        private List<string> allowextention = new List<string> { ".jpg", ".png" };
        private long allowmaxsize = 1048576;


        [HttpGet]
        public async Task<IActionResult> Getstories()
        {
            var stories = await _context.stories.Include(n => n.Category).ToListAsync();
            return Ok(stories);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult>Getbyid(int id)
        {

            var story = await _context.stories.Where(n => n.Id == id).SingleOrDefaultAsync();
            if (story == null)
                return BadRequest("notfound");
            return Ok(story);
        
        }


        [HttpGet("getbycat")]
        public async Task<IActionResult> Getcat(int id)
        {

            var story = await _context.stories.Where(n => n.categoryid==id).ToListAsync();
            if (story == null)
                return BadRequest("notfound");
            return Ok(story);

        }


        [HttpPost]
        public async Task<IActionResult>create([FromForm]storiesDTO dto)
        {

            if (allowextention.Contains(Path.GetExtension(dto.img.FileName).ToLower()))
                return BadRequest("the extention must be jpg or png");
            if (dto.img.Length > allowmaxsize)
                return BadRequest("the size must be less or equal 1 MB");

            using var datastream=new MemoryStream();
            await dto.img.CopyToAsync(datastream);

            var storyad = new story
            {
                title = dto.title,
                author = dto.author,
                rate = dto.rate,
                img = datastream.ToArray(),
                categoryid = dto.categoryid,
            };
            await _context.stories.AddAsync(storyad);
            _context.SaveChanges();
            return Ok(storyad);
        }


    }
}
