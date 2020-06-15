using Entities.Seguridad;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Tools;

namespace DataAccess.Seguridad
{
    public class daRoles : DaBase<eRoles>
    {
        #region Constructores
        public daRoles(String ProcesoInvocador) : base(ProcesoInvocador, cConString.QTCO, cAreas.Roles) { }
        #endregion Constructores

        /// <summary>
        /// buscar Roles por id 
        /// </summary>
        /// <param name="id"></param>       
        public override eRoles Buscar(int id)
        {
            try
            {
                var rol = Buscar("select * from dbo.Roles where IdRol=" + id);

                return rol;
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
        public static List<eRoles> ListRoles()
        {
            var rol = SQL.SelectList<eRoles>(cBd.QTCO, "Sel_Roles");
            return rol;
        }
       
        /// <summary>
        /// inserta, actualiza y elimina Usuarios de la bd
        /// </summary>
        /// <param name="objeto">Usuarios a eliminar solo se valida el id</param>
        /// <param name="Accion">nombre de la operación a realizar</param>
        /// <param name="ProcesoInvocador">nombre del método o proceso que invoca la acción</param>

        protected override object[] Administrar(eRoles objeto, String Accion)
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
                        parametros.Add(new SqlParameter("@RegBorrado", tDatos.ToObject(objeto.RegBorrado)));
                        if (Accion == "Insertar")
                        {
                            parametros.Add(new SqlParameter("@IdRol", tDatos.ToObject(objeto.IdRoles)));
                            res = SQL.Execute(cConString.QTCO, cAreas.Roles, "Ins_Roles", parametros, ProcesoInvocador);
                        }
                        break;
                    case "Eliminar":
                        parametros.Add(new SqlParameter("@IdRol", tDatos.ToObject(objeto.IdRoles)));
                        res = SQL.Execute(cConString.QTCO, cAreas.Roles, "Del_Roles", parametros, ProcesoInvocador);
                        break;
                }

                checkPoint = " Ejecutar";

                resultado = Errores.Control(res, cAreas.Roles, Accion + " Roles, IdRol:" + objeto.IdRoles + ". CheckPoint:" + checkPoint + " ." + ProcesoInvocador);
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


        public List<SelectListItem> Listado(int IdRoles, string selected)
        {
            return SQL.SelectListItems(cConString.QTCO, "select rtrim(Nombre) as 'text',rtrim(IdRol) as 'value' from Roles where IdRol=" + IdRoles + "order by Nombre", selected);
        }
    }
}
