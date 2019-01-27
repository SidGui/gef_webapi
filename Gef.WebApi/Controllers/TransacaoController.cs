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
    public class TransacaoController : ControllerBase
    {
        private Business.Estoque.Transacao _transacao = null;
        [HttpPost]
        public ActionResult<string> Post([FromBody] Model.Model.Transacao transacao)
        {
            if (transacao.medicamento.id == 0)
                return BadRequest("ENTER WITH A VALID ID.");

            _transacao = new Business.Estoque.Transacao();
            _transacao.Save(transacao);

            return "";
        }
    }
}