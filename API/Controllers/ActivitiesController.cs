using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;

        public ActivitiesController(DataContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            if (_context.Activities == null) return NotFound();
            return await _context.Activities.ToListAsync();
        }
        [HttpGet("{id}")]//activites/id
        public async Task<ActionResult<Activity?>> GetActivity(Guid id)
        {
            if (_context.Activities == null) return NotFound();
            return await _context.Activities.FindAsync(id);
        }
    }
}