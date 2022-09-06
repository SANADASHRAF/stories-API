using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using storiessapi.DTO;
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
        public async Task<IActionResult> Getallcategory()
        {
            var category = await _context.categories.ToListAsync();
            return Ok(category);
        }


        [HttpPost]
        public async Task<IActionResult>createcatageory(createdto dto)
        {
            var category=new Category { Name=dto.name};
            await _context.categories.AddAsync(category);
            _context.SaveChanges();
            return Ok (category);
            
        }


        [HttpPut("{id}")]
        public async Task<IActionResult>updatecategory(int id, [FromBody] createdto dto)
        {
            var category=await  _context.categories.SingleOrDefaultAsync(c => c.Id == id);
            if (category == null)
                return BadRequest($"the category with {id} not found");

            category.Name=dto.name;
            _context.SaveChanges();
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delcategory(int id)
        {
            var category = await _context.categories.SingleOrDefaultAsync(c => c.Id == id);
            if (category == null)
                return BadRequest($"the category with {id} not found");

            _context.categories.Remove(category);
            _context.SaveChanges();
            return Ok (category);

        }







    }
}
