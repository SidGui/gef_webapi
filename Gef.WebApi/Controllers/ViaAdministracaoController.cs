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
    public class ViaAdministracaoController : ControllerBase
    {

        private Business.Medicamento.ViaAdministracao _viaAdministracao = null;
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                _viaAdministracao = new Business.Medicamento.ViaAdministracao();
                string json = JsonConvert.SerializeObject(_viaAdministracao.GetAll());
                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _viaAdministracao = null;
            }

        }
    }
}