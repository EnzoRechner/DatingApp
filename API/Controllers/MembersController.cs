using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class MembersController(AppDbContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var members = await context.Users.ToListAsync();

            return members;
        }
        [Authorize]
        [HttpGet("{Id}")] // localhost:5001/api/members/bob-id
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
