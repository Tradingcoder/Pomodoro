using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoursApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HoursApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HourController : ControllerBase
    {
        private readonly HourContext _context;

        public HourController(HourContext context)
        {
            _context = context;

            if (_context.HourItems.Count() == 0)
            {
                _context.HourItems.Add(new HourItem { PomodoroGoal = "Create controller" });
                _context.SaveChanges();
            }

        }

        [HttpGet]
        public ActionResult<List<HourItem>> GetAll()
        {
            return _context.HourItems.ToList();
        }
        
    }
}
