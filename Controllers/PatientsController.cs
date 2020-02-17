using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeCare.Data;
using WeCare.Data.Entities;

namespace WeCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly WeCareContext _context;

        public PatientsController(WeCareContext context)
        {
            _context = context;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatient()
        {
            return await _context.Patient.ToListAsync();
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _context.Patient.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        // PUT: api/Patients/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
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

        // HTTP POST: api/patients
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            _context.Patient.Add(patient);

            await _context.SaveChangesAsync();

            var journal = new Journal(patientId: patient.Id);

            _context.Journal.Add(journal);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Patient>> DeletePatient(int id)
        {
            var patient = await _context.Patient.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patient.Remove(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

        [HttpGet("{id}/journal")]
        public async Task<ActionResult<Journal>> GetPatientJournalByPatientId(int id)
        {
            var patient = await _context.Patient
                .Include(x => x.Journal)
                .ThenInclude(x => x.Entries)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient.Journal;
        }

        // HTTP POST /api/patients/1/journal/entries
        [HttpPost("{id}/journal/entries")]
        public ActionResult<JournalEntry> PostPatientJournalEntry(int id, JournalEntry journalEntry)
        {
            var patient = _context.Patient
                .Include(x => x.Journal)
                .FirstOrDefault(x => x.Id == id);

            if (patient == null)
            {
                return BadRequest();
            }

            patient.Journal.Entries.Add(journalEntry);

            _context.SaveChanges();

            return Created("", journalEntry); // 200 OK  (200-299 signalerar att allt gick bra)

            //_context.Patient.Add(patient);

            //await _context.SaveChangesAsync();

            //var journal = new Journal(patientId: patient.Id);

            //_context.Journal.Add(journal);

            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
            return Created("", null); // 201 Created
        }

        private bool PatientExists(int id)
        {
            return _context.Patient.Any(e => e.Id == id);
        }
    }
}
