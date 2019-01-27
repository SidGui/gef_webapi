using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonPatch;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gef.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {

        private Business.Estoque.Estoque _estoque = null;
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                _estoque = new Business.Estoque.Estoque();
                string json = JsonConvert.SerializeObject(_estoque.GetAll());
                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _estoque = null;
            }

        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                _estoque = new Business.Estoque.Estoque();
                string json = JsonConvert.SerializeObject(_estoque.Get(id));
                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                _estoque = null;
            }

        }
        [HttpPost]
        public ActionResult<string> Post([FromBody] Model.Model.Estoque estoque)
        {
            try {
                if(estoque == null || estoque.medicamento.id == 0)
                    return BadRequest("ENTER WITH A VALID ESTOQUE.");
                
                _estoque = new Business.Estoque.Estoque();
                string json = JsonConvert.SerializeObject(_estoque.Save(estoque));
                return Ok();
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
                throw ex;
            }
            finally {
                _estoque = null;
            }
        }

          [HttpPut("{id}")]
        public ActionResult<IEnumerable<string>> Put(int id, [FromBody] Model.Model.Estoque estoque)
        {
            try {
                if(id == 0)
                    return BadRequest("ENTER WITH A VALID ID.");

                _estoque = new Business.Estoque.Estoque();
                string json = JsonConvert.SerializeObject(_estoque.Alter(id, estoque));
                return Ok("DATA CHANGED SUCCESSFUL");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _estoque = null;
            }
        }
    }
}