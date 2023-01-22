using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Incident_and_Infrastructure_Management.Models;
using Incident_and_Infrastructure_Management.Models.Data;

namespace Incident_and_Infrastructure_Management.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Controllers.StudentController>>> GetStudent()
        //{
        //  if (_context.Student == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Student.ToListAsync();
        //}

        // GET: api/Student/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Controllers.StudentController>> GetStudent(Guid id)
        //{
        //  if (_context.Student == null)
        //  {
        //      return NotFound();
        //  }
        //    var student = await _context.Student.FindAsync(id);

        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    return student;
        //}

        // PUT: api/Student/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(Guid id, Controllers.StudentController student)
        {
            //if (id != student.Id)
            //{
            //    return BadRequest();
            //}

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Student
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //public async Task<ActionResult<Controllers.StudentController>> PostStudent(Controllers.StudentController student)
        //{
        //  if (_context.Student == null)
        //  {
        //      return Problem("Entity set 'ApplicationDbContext.Student'  is null.");
        //  }
        //   // _context.Student.Add(student);
        //    await _context.SaveChangesAsync();

        //    //return CreatedAtAction("GetStudent", new { id = student. }, student);
        //}

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            if (_context.Student == null)
            {
                return NotFound();
            }
            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(Guid id)
        {
            return (_context.Student?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
