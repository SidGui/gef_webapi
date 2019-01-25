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
    public class PrincipioAtivoController : ControllerBase
    {

        private Business.Medicamento.PrincipioAtivo _principioAtivo = null;
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                _principioAtivo = new Business.Medicamento.PrincipioAtivo();
                string json = JsonConvert.SerializeObject(_principioAtivo.GetAll());
                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _principioAtivo = null;
            }

        }

        public ActionResult<string> Post([FromBody] Model.Model.PrincipioAtivo principioAtivo)
        {
            try
            {
                _principioAtivo = new Business.Medicamento.PrincipioAtivo();
                string json = JsonConvert.SerializeObject(_principioAtivo.Save(principioAtivo));
                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _principioAtivo = null;
            }
        }
    }
}