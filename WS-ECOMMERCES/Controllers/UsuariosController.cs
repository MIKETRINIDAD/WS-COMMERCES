using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Seguridad;
using Entities.Seguridad;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WS_ECOMMERCES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        #region Listados
        // GET: api/<UsuariosController>
        [HttpGet]
        public IEnumerable<eUsuarios> Get()
        {
            var User = new List<eUsuarios>();
            var t = Task.Run(() =>
            {
                User = daUsuario.ListUsuarios();
            }
            );

            if (t.Wait(TimeSpan.FromSeconds(300)))
            {
                t.Dispose();
            }

            if (User == null)
            {
                 NotFound();
            }
            return User;
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        #endregion Listados

        #region CRUD
        // POST api/<UsuariosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion CRUD
    }
}
