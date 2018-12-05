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
            finally
            {
                _estoque = null;
            }

        }
    }
}