using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private List<string> extention = new List<string> { ".jpg", ".png" };

        [HttpPost]
        public async Task<IActionResult>create([FromForm]storiesDTO dto)
        {
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
