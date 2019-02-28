using ServicioWeb.Modelos.Entidades;
using ServicioWeb.Negocio.Modulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioWeb.WebApi.Controllers
{
    [RoutePrefix("api/PruebaService")]
    public class ValuesController : ApiController

    {
        PruebaManager pruebaManager = new PruebaManager();
        [Route("ListadoPrueba")]
        [HttpGet]
        public List<EntPrueba> get()
        {            
            return this.pruebaManager.dameEntidad();
        }
        [Route("SolicitudFiltro")]
        [HttpPost]
        public List<EntPrueba> post()
        {
            EntPrueba filtro = new EntPrueba();
            {
                filtro.Id =11;
                filtro.Nombre = "Perro";
            }
            return this.pruebaManager.dameRegistros(filtro);
        }
        [Route("ActualizaPrueba")]
        [HttpPut]
        public string put()
        {
            FiltroPrueba filtro = new FiltroPrueba();
            {
                filtro.Jugue_Id = 13;
                filtro.Jugue_Nombre = "LUIS";
            }
            return this.pruebaManager.ActualizacionPrueba(filtro);
        }
        [Route("EliminacionPrueba")]
        [HttpDelete]
        public string delete()
        {
            FiltroPrueba filtro = new FiltroPrueba();
            {
                filtro.Jugue_Id = 13;
                filtro.Jugue_Nombre = "LUIS";

            }

            return this.pruebaManager.EliminarRegistro(filtro);
        }



        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}       


        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
