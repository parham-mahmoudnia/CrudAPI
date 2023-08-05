using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersisApiTask.Data;
using PersisApiTask.Models;
using System.Collections;

namespace PersisApiTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityTypeController : Controller
    {
        private readonly PersisApiTaskDbContext _context;
        public ActivityTypeController(PersisApiTaskDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityType>>> GetActivitys()
        {
            if (_context.ActivityTypes == null)
            {
                return NotFound();

            }
            return await _context.ActivityTypes.ToListAsync();
        }
       

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityType>> GetActivity(int id)
        {
            if (_context.ActivityTypes == null)
            {
                return NotFound();
            }
            var activityType = await _context.ActivityTypes.FindAsync(id);
            if (activityType == null)
            {
                return NotFound();
            }
            return activityType;
        }
       
        [HttpPost]
        public async Task<ActionResult<ActivityType>> PostActivity(ActivityType activityType)
        {
            try
            {
                _context.ActivityTypes.Add(activityType);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetActivity), new { id = activityType.Id }, activityType);
            }
            catch (Exception)
            { 
                throw new ApplicationException("You didn't complete the fields correctly");
            }

        }


        [HttpPut]
        public async Task<ActionResult<ActivityType>> PutActivity(int id, ActivityType activityType)
        {
            if (id != activityType.Id)
            {
                return BadRequest();
            }
            _context.Entry(activityType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityTypeAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }
        private bool ActivityTypeAvailable(int id)
        {
            return (_context.ActivityTypes?.Any(x => x.Id == id)).GetValueOrDefault();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ActivityType>> DeleteActivity(int id)
        {
            if (_context.ActivityTypes == null)
            {
                return NotFound();
            }

            var activity = await _context.ActivityTypes.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }
            _context.ActivityTypes.Remove(activity);
            await _context.SaveChangesAsync();
            return Ok();
        }




    }
}
