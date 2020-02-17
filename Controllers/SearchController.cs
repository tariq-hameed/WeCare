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
    public class SearchController : ControllerBase
    {
        private readonly WeCareContext context;

        public SearchController(WeCareContext context)
        {
            this.context = context;
        }

        // HTTP GET http://localhost:5000/api/search?q=test
        [HttpGet]
        public ActionResult<IList<Patient>> Search([FromQuery] string q)
        {
            var patients = context.Patient.Where(x => x.FirstName.Contains(q))
                .ToList();

            return patients;
        }
    }
}
