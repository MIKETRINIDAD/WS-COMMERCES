
using DataAccess.Seguridad;
using Entities.Seguridad;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestQA
{
    [TestClass]
    class CodeFile1
    {
        
            [TestMethod]
            public void TestMethod1()
            {
            var user = new daUsuario("");
            var usuarios = new eUsuarios();
            usuarios.IdUsuario = 3;
            usuarios.Nombre = "Developer";
            usuarios.ApellidoPaterno = "";
            usuarios.ApellidoMaterno = "";
            usuarios.UserName = "Dev";
            usuarios.Pass = "xxx";
            usuarios.Email = "dev@hotmail.com";
            usuarios.IdRol = 1;
            usuarios.Activo = true;
            usuarios.FechaCreacion = DateTime.Now;
            usuarios.RegBorrado = 0;
            user.Insert(usuarios);
            Console.WriteLine("Se inserto:" + user);
        }

        //static void Main(string[] args)
        //{
        //    var user = new daUsuario("");
        //    var usuarios = new eUsuarios();
        //    usuarios.IdUsuario = 3;
        //    usuarios.Nombre = "Developer";
        //    usuarios.ApellidoPaterno = "";
        //    usuarios.ApellidoMaterno = "";
        //    usuarios.UserName = "Dev";
        //    usuarios.Pass = "xxx";
        //    usuarios.Email = "dev@hotmail.com";
        //    usuarios.IdRol = 1;
        //    usuarios.Activo = true;
        //    usuarios.FechaCreacion = DateTime.Now;
        //    usuarios.RegBorrado = 0;
        //    user.Insert(usuarios);
        //    Console.WriteLine("Se inserto:"+ user);
        // }
    }
}
