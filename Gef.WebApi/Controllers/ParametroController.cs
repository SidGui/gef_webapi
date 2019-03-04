using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gef.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametroController : ControllerBase
    {
        private Business.Configuracao.Parametro _parametro = null;
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                _parametro = new Business.Configuracao.Parametro();
                string json = JsonConvert.SerializeObject(_parametro.GetAll());
                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _parametro = null;
            }

        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                _parametro = new Business.Configuracao.Parametro();
                string json = JsonConvert.SerializeObject(_parametro.Get(id));
                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _parametro = null;
            }

        }
        [HttpPost]
        public ActionResult<string> Post([FromBody] Model.Model.Parametro parametro)
        {
            try
            {
                if (parametro == null)
                    return BadRequest("ENTER WITH A VALID PARAMETER");

                _parametro = new Business.Configuracao.Parametro();
                string json = JsonConvert.SerializeObject(_parametro.Save(parametro));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw ex;
            }
            finally
            {
                _parametro = null;
            }
        }

        [HttpPut("{id}")]
        public ActionResult<IEnumerable<string>> Put(int id, [FromBody] Model.Model.Parametro parametro)
        {
            try
            {
                if (id == 0)
                    return BadRequest("ENTER WITH A VALID ID.");

                _parametro = new Business.Configuracao.Parametro();
                string json = JsonConvert.SerializeObject(_parametro.Alter(id, parametro));
                return Ok("DATA CHANGED SUCCESSFUL");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _parametro = null;
            }
        }
    }
}