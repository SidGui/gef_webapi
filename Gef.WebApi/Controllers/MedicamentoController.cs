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
    public class MedicamentoController : ControllerBase
    {
        private Business.Medicamento.Medicamento _medicamento = null;
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                _medicamento = new Business.Medicamento.Medicamento();
                string json = JsonConvert.SerializeObject(_medicamento.GetAll());
                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _medicamento = null;
            }
            
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                _medicamento = new Business.Medicamento.Medicamento();
                string json = JsonConvert.SerializeObject(_medicamento.Get(id));
                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _medicamento = null;
            }
            
        }

        [HttpPost]
        public ActionResult<HttpContext> Post([FromBody] Model.Model.Medicamento medicamento)
        {
           try
            {
                _medicamento = new Business.Medicamento.Medicamento();
                string json = JsonConvert.SerializeObject(_medicamento.Save(medicamento));
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _medicamento = null;
            }
        }

        [HttpPut]
        public ActionResult<IEnumerable<string>> Put([FromBody] Model.Model.Medicamento medicamento)
        {
             try
            {
                _medicamento = new Business.Medicamento.Medicamento();
                string json = JsonConvert.SerializeObject(_medicamento.Alter(medicamento));
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _medicamento = null;
            }
        }

    }
}