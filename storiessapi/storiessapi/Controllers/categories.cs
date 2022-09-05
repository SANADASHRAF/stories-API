using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using storiessapi.Model;

namespace storiessapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class categories : ControllerBase
    {

        private readonly stdbcontextr _context;

        public categories(stdbcontextr context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var category = _context.categories.ToListAsync();
            return Ok(category);
        }
       
    
    
    
    
    
    
    
    }
}
