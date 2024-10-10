using ews.Data;
using ews.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<RoomBooking>>> GetUsers()
        {
            List<RoomBooking> User = await _dataContext.RoomBooking.ToListAsync();
            return Ok(User);
        }
    }
}
