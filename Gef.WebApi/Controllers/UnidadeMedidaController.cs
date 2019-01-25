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

        [HttpPost]
        public ActionResult<bool> Post([FromBody] Model.Model.UnidadeMedida unidadeMedida)
        {
            try
            {
                _unidadeMedida = new Business.Estoque.UnidadeMedida();
               string json = JsonConvert.SerializeObject(_unidadeMedida.Save(unidadeMedida));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
        //public Task<ActionResult<bool>> Post([FromBody] Model.Model.UnidadeMedida unidadeMedida)
        //{
        //    try
        //    {
        //        _unidadeMedida = new Business.Estoque.UnidadeMedida();
        //        Task<string> json = JsonConvert.SerializeObject(_unidadeMedida.Save());
        //        return ;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {

        //    }
        //}
    }
}