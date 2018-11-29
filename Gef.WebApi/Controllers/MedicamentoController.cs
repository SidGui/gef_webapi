using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gef.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> Get(int id)
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public ActionResult<HttpContext> Post([FromBody] object medicamento)
        {
            return null;
        }

        [HttpPut]
        public ActionResult<IEnumerable<string>> Put([FromBody] object medicamento)
        {
            return new string[] { "value1", "value2" };
        }

    }
}