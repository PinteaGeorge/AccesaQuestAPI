using AccesaQuestAPI.Context;
using AccesaQuestAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccesaQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderboardTable : ControllerBase
    {
        private readonly ContextDb _context;
        public LeaderboardTable(ContextDb context)
        {
            _context = context;
        }

        [HttpGet("getleaderboard")]
        public async Task<ActionResult<User>> GetLeaderboardTable()
        {
            return Ok(await _context.Users.ToListAsync());
        }
    }
}
