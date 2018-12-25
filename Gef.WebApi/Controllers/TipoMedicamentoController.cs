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
    public class TipoMedicamentoController : ControllerBase
    {

        private Business.Medicamento.TipoMedicamento _tipoMedicamento = null;
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                _tipoMedicamento = new Business.Medicamento.TipoMedicamento();
                string json = JsonConvert.SerializeObject(_tipoMedicamento.GetAll());
                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _tipoMedicamento = null;
            }

        }
    }
}