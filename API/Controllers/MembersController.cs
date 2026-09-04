using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")] // localhost:5002/api/members
    [ApiController]
    public class MembersController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var members = await context.Users.ToListAsync();

            return members;
        }

        [HttpGet("{Id}")] // localhost:5002/api/members/bob-id
        public async Task<ActionResult<AppUser>> GetMember(string Id)
        {
            var member = await context.Users.FindAsync(Id);

            if (member == null ) return NotFound();
            
            return member;
        }

        // My bad attempt at getting one user, didn't know where to get Id [HttpGet]
        // public ActionResult<IReadOnlyList<AppUser>> GetMember(string Id)
        // {
        //     var member = context.Users.GetById(Id).ToList();

        //     return member;
        // }

    }
}
