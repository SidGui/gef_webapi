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
    public class UnidadeMedidaController : ControllerBase
    {

        private Business.Estoque.UnidadeMedida _unidadeMedida = null;
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                _unidadeMedida = new Business.Estoque.UnidadeMedida();
                string json = JsonConvert.SerializeObject(_unidadeMedida.GetAll());
                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _unidadeMedida = null;
            }

        }
    }
}