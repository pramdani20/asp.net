using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organisasi_WebApi.Models;

namespace Organisasi_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnggotaController : ControllerBase
    {
        private AnggotaContext _context;

        public AnggotaController(AnggotaContext context)
        {
            this._context = context;
        }

        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<AnggotaItem>> GetAnggotaItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(AnggotaContext)) as AnggotaContext;
            //return new string[] { "value1", "value2" };
            return _context.GetAllanggota();
        }

        //Get : api/user/{id}
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<IEnumerable<AnggotaItem>> GetAnggotaItem(String id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(AnggotaContext)) as AnggotaContext;
            return _context.Getanggota(id);
        }
    }
}