using AccesaQuestAPI.Context;
using AccesaQuestAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccesaQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestController : ControllerBase
    {
        private readonly ContextDb _context;
        public QuestController(ContextDb context)
        {
            _context = context;
        }

        [HttpGet("getcommonquests")]
        public async Task<ActionResult<CommonQuests>> GetCommonQuests()
        {
            return Ok(await _context.CommonQuests.ToListAsync());
        }

        [HttpPost("addnewquest")]
        public async Task<IActionResult> AddNewQuest([FromBody] CompletedQuestsFromUser quest)
        {
            try
            {
                await _context.CompletedQuestsFromUsers.AddAsync(quest);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }

        [HttpGet("getuserquest/{userId}")]
        public async Task<ActionResult> GetUserQuest(int userId)
        {
            return Ok(await _context.CompletedQuestsFromUsers
                .Where(u => u.UserId == userId)
                .ToListAsync());
        }

        [HttpGet("getotheruserquest/{userId}")]
        public async Task<ActionResult> GetOtherUserQuest(int userId)
        {
            return Ok(await _context.CompletedQuestsFromUsers
                .Where(u => u.UserId != userId)
                .ToListAsync());
        }

        [HttpDelete("deleteuserquest/{questId}")]
        public async Task<int> DeleteUserQuest(int questId)
        {
            var quest = await _context.CompletedQuestsFromUsers
                .Where(x => x.Id == questId)
                .FirstOrDefaultAsync();
            _context.CompletedQuestsFromUsers.Remove(quest);
            return await _context.SaveChangesAsync();
        }
    }
}
