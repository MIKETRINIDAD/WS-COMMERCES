using System;
using System.Collections;
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
    public class RolesController : ControllerBase
    {
        #region Listado
        // GET: api/<RolesController>
        [HttpGet]
        public IEnumerable<eRoles> Get()
        {
            var rol = new List<eRoles>();
            var t = Task.Run(() =>
            {
                rol = daRoles.ListRoles();
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
            return rol;
        }
        #endregion Listado

        #region CRUD
        // POST api/<UsuariosController>
        [HttpPost]
        public IEnumerable Post(eRoles roles)
        {
            var rol = new daRoles("Insertar roles");
            bool valida = false;
            if (!ModelState.IsValid)
            {
                yield return BadRequest(ModelState);
            }
            var t = Task.Run(() =>
            {
                valida = rol.Insert(roles);
            }
            );

            if (t.Wait(TimeSpan.FromSeconds(10)))
            {
                t.Dispose();
            }

            yield return Ok(valida);
        }

        // PUT api/<UsuariosController>/5
        [HttpPut]
        public IEnumerable Put(eRoles roles)
        {
            var rol = new daRoles("Actualizar roles");
            bool valida = false;
            if (!ModelState.IsValid)
            {
                yield return BadRequest(ModelState);
            }
            var t = Task.Run(() =>
            {
                valida = rol.Update(roles);
            }
            );

            if (t.Wait(TimeSpan.FromSeconds(10)))
            {
                t.Dispose();
            }

            yield return Ok(valida);
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public IEnumerable Delete(int id)
        {
            var rol = new daRoles("Eliminar rol");
            bool valida = false;
            if (!ModelState.IsValid)
            {
                yield return BadRequest(ModelState);
            }
            var t = Task.Run(() =>
            {
                valida = rol.Delete(id);
            }
            );

            if (t.Wait(TimeSpan.FromSeconds(10)))
            {
                t.Dispose();
            }

            yield return Ok(valida);
        }
        #endregion CRUD
    }
}
