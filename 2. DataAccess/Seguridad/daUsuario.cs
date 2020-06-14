using Entities.Seguridad;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

#region Bitacora
/// <summary>
/// Autor: Miguel Ángel Trinidada Cruz
/// Fecha: 13/06/2020
/// Descripcion: Clase de operaciones CRUD para los usuarios 
/// ------------------------------------------------------------------------------------------------------------
/// Feche            Estatus                  UserName                    Descripcion
/// 
/// 
/// </summary>
#endregion Bitacora

namespace DataAccess.Seguridad
{
    public class daUsuario : DaBase<eUsuarios>
    {
        #region Constructores
        public daUsuario(String ProcesoInvocador) : base(ProcesoInvocador, cConString.QTCO, cAreas.Seg) { }
        #endregion Constructores

        /// <summary>
        /// buscar Usuario por id 
        /// </summary>
        /// <param name="id"></param>       
        public override eUsuarios Buscar(int id)
        {
            try
            {
                var x = Buscar("SspUsuarios @id=" + id);

                if (x != null)
                {
                    x.Pass = tEncription.Desencripta(x.Pass);
                    x.UserName = tEncription.Desencripta(x.UserName);
                }

                return x;
            }
            catch (Exception ex)
            {
                try { throw new daException(ex); } catch { }
            }
            return null;
        }

        /// <summary>
        /// buscar Toda la lista
        /// </summary>
        public static List<eUsuarios> ListUsuarios()
        {
            var User = SQL.SelectList<eUsuarios>(cBd.QTCO, "Sel_Usuarios");
            return User;
        }
        public eUsuarios BuscarXClaves(string name, string pass)
        {
            var s = "select * from Usuarios where rtrim(UserName)='" + tEncription.Encripta(name) + "' and rtrim(Pass)='" + tEncription.Encripta(pass) + "';";
            var x = Buscar(s);

            if (x != null)
            {
                x.Pass = tEncription.Desencripta(x.Pass);
                x.UserName = tEncription.Desencripta(x.UserName);
                x.IdUsuario = x.IdUsuario;
            }
            return x;
        }

        /// <summary>
        /// inserta, actualiza y elimina Usuarios de la bd
        /// </summary>
        /// <param name="objeto">Usuarios a eliminar solo se valida el id</param>
        /// <param name="Accion">nombre de la operación a realizar</param>
        /// <param name="ProcesoInvocador">nombre del método o proceso que invoca la acción</param>

        protected override object[] Administrar(eUsuarios objeto, String Accion)
        {
            object[] resultado = new object[2] { true, "" };
            //desarrollar

            var checkPoint = "";

            if (objeto != null)
            {
                var res = new object[3];

                checkPoint = " Asignar Parametros";

                var parametros = new List<SqlParameter>();


                switch (Accion)
                {
                    default:
                        parametros.Add(new SqlParameter("@Nombre", tDatos.ToObject((objeto.Nombre))));
                        parametros.Add(new SqlParameter("@ApellidoPaterno", tDatos.ToObject(objeto.ApellidoPaterno)));
                        parametros.Add(new SqlParameter("@ApellidoMaterno", tDatos.ToObject(objeto.ApellidoMaterno)));
                        parametros.Add(new SqlParameter("@UserName", tDatos.ToObject(tEncription.Encripta(objeto.UserName))));
                        parametros.Add(new SqlParameter("@Pass", tDatos.ToObject(tEncription.Encripta(objeto.Pass))));
                        parametros.Add(new SqlParameter("@Email", tDatos.ToObject(objeto.Email)));
                        parametros.Add(new SqlParameter("@IdRol", tDatos.ToObject(objeto.IdRol)));
                        parametros.Add(new SqlParameter("@Activo", tDatos.ToObject(objeto.Activo)));
                        parametros.Add(new SqlParameter("@RegBorrado", tDatos.ToObject(objeto.RegBorrado)));
                        if (Accion == "Insertar")
                        {
                            parametros.Add(new SqlParameter("@IdUsuario", tDatos.ToObject(objeto.IdUsuario)));
                            res = SQL.Execute(cConString.QTCO, cAreas.Users, "Ins_Usuarios", parametros, ProcesoInvocador);
                        }
                        break;
                    case "Eliminar":
                        parametros.Add(new SqlParameter("@IdUsuario", tDatos.ToObject(objeto.IdUsuario)));
                        res = SQL.Execute(cConString.QTCO, cAreas.Users, "Del_Usuarios", parametros, ProcesoInvocador);
                        break;
                }

                checkPoint = " Ejecutar";

                resultado = Errores.Control(res, cAreas.Users, Accion + " Usuarios, IdUsuario:" + objeto.IdUsuario + ". CheckPoint:" + checkPoint + " ." + ProcesoInvocador);
            }
            else
            {
                resultado[0] = false;
            }

            return resultado;
        }
        //------------------------------------Métodos Esenciales-----------------------------------------------

        /// <summary>
        /// buscar varias empresas mediante una consulta sql especifica
        /// </summary>
        /// <param name="sql">consulta sql</param>


        public List<SelectListItem> Listado(int IdUsuario, string selected)
        {
            return SQL.SelectListItems(cConString.QTCO, "select rtrim(Nombre) as 'text',rtrim(IdUsuario) as 'value' from Usuarios where IdUsuario=" + IdUsuario + " order by descripcion", selected);
        }
    }
}
