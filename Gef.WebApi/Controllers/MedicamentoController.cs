using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.JsonPatch;

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
                return Ok(json);
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
                return Ok(json);
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
                if(medicamento == null || string.IsNullOrEmpty(medicamento.nomeMedicamento))
                    return BadRequest("ENTER WITH A VALID MEDICAMENTO.");

                _medicamento = new Business.Medicamento.Medicamento();
                string json = JsonConvert.SerializeObject(_medicamento.Save(medicamento));
                return Ok("DATA INSERT SUCCESSFUL");
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

        [HttpPut("{id}")]
        public ActionResult<IEnumerable<string>> Put(int id, [FromBody] Model.Model.Medicamento medicamento)
        {
            try {
                if(id == 0)
                    return BadRequest("ENTER WITH A VALID ID.");

                _medicamento = new Business.Medicamento.Medicamento();
                string json = JsonConvert.SerializeObject(_medicamento.Alter(id, medicamento));
                return Ok("DATA CHANGED SUCCESSFUL");
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
        // [HttpPatch("update/{id}")]
        // public ActionResult<IEnumerable<string>> Patch(int id, [FromBody]JsonPatchDocument<Model.Model.Medicamento> medicamento)
        // {
        //     try {
        //         _medicamento = new Business.Medicamento.Medicamento();
        //         medicamento.ApplyTo(_medicamento.Get(id).FirstOrDefault());
        //     }
        //     catch(Exception ex) {
        //         throw ex;
        //     }
        //     finally {

        //     }
        // }

    }
}