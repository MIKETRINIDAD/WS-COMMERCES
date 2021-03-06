﻿using System;
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
        public IEnumerable Post(eUsuarios usuarios)
        {
            var usuario = new daUsuario("Insertar usuario");
            bool valida = false;
            if (!ModelState.IsValid)
            {
                yield return BadRequest(ModelState);
            }
            var t = Task.Run(() =>
            {
                valida = usuario.Insert(usuarios);
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
        public IEnumerable Put(eUsuarios usuarios)
        {
            var usuario = new daUsuario("Actualizar usuario");
            bool valida = false;
            if (!ModelState.IsValid)
            {
                yield return BadRequest(ModelState);
            }
            var t = Task.Run(() =>
            {
                valida = usuario.Update(usuarios);
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
            var usuario = new daUsuario("Eliminar usuario");
            bool valida = false;
            if (!ModelState.IsValid)
            {
                yield return BadRequest(ModelState);
            }
            var t = Task.Run(() =>
            {
                valida = usuario.Delete(id);
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
