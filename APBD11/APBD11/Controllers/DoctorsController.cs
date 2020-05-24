using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace APBD11.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly MyDbContext _context;
        public DoctorsController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_context.Doctors.ToList());
        }

        [HttpPut("update")]
        public IActionResult UpdateDoctor(Doctor doctor)
        {
            try
            {
                _context.Attach(doctor);
                _context.SaveChanges();
                return Ok("Student został zmodyfikowany");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var d = new Doctor
            {
                IdDoctor = id
            };
            _context.Attach(d);
            _context.Remove(d);
            _context.SaveChanges();
            return Ok($"Doctor {id} usunięty pomyślnie");
        }

        [HttpPost]
        public IActionResult InsertDoctor(Doctor doctor)
        {
            _context.Add(doctor);
            _context.SaveChanges();
            return Ok(_context.Doctors.ToList());
        }

        [HttpPost]
        public IActionResult Seed()
        {
            _context.Add(
                new Doctor
                {
                    IdDoctor = 1,
                    FirstName = "Pawel",
                    LastName = "Nowak",
                    Email = "pawelNowak@gmail.com"
                });
            _context.SaveChanges();
            return Ok(_context.Doctors.ToList());
        }
    }
}