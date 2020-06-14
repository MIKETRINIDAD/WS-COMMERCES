using DataAccess.Base;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Tools;

public class SQL
{
    /// <summary>
    /// Retorna una cadena con consulta para seleccionar varios registros string en un solo campo sql
    /// </summary>
    /// <param name="sql">consulta sql</param>
    /// <param name="asname">nombre para la columna devuelta</param>

    public static string SelectStuff(string sql, string bd)
    {
        return SelectString("select " + tSQL.stuff(sql, "ex") + ";", bd);
    }

    /// <summary>
    /// lee una consulta de la bd y la retorna en forma de lista de select list item con opcion de traer uno seleccionado
    /// </summary>
    /// <param name="BaseDatos">clave de la bd</param>
    /// <param name="sql">consulta sql</param>
    /// <param name="selected">value seleccionado</param>
    public static List<SelectListItem> SelectListItems(string BaseDatos, string sql, string selected)
    {
        var listado = new List<SelectListItem>();

        var table = SelectDataTable(BaseDatos, sql);

        foreach (DataRow row in table.Rows)
        {
            try
            {
                var item = new SelectListItem();
                item.Text = tDatos.ToString(row["text"]);
                item.Value = tDatos.ToString(row["value"]);

                if (item.Value == selected)
                {
                    item.Selected = true;
                }

                listado.Add(item);
            }
            catch (Exception ex)
            {
                RegistrarError.General(BaseDatos, cAreas.Html, "Leer SelectListItem de la consulta:" + sql, ex);
            }
        }

        return listado;
    }
    public static List<SelectListItem> ListItems(String BaseDatos, String sql, String selected)
    {
        var listado = new List<SelectListItem>();

        var table = SelectDataTable(BaseDatos, sql);

        foreach (DataRow row in table.Rows)
        {
            try
            {
                var item = new SelectListItem();
                item.Text = tDatos.ToString(row["text"]);
                item.Value = tDatos.ToString(row["value"]);

                if (item.Value == selected)
                {
                    item.Selected = true;
                }

                listado.Add(item);
            }
            catch (Exception ex)
            {
                RegistrarError.General(BaseDatos, cAreas.Html, "Leer ListItem de la consulta:" + sql, ex);
            }
        }

        return listado;
    }
    /// <summary>
    /// lee un campo byte de una consulta sql
    /// </summary>
    /// <param name="sql">consulta sql</param>
    /// <param name="BaseDatos">clave de la bd</param>   
    public static byte[] SelectBytes(String sql, String BaseDatos)
    {
        var table = SelectDataTable(BaseDatos, sql);

        if (table.Rows.Count > 0)
        {
            try
            {
                return (byte[])table.Rows[0][0];
            }
            catch
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// lee un entero devuelto de una consulta sql
    /// </summary>
    /// <param name="sql">consulta sql</param>
    /// <param name="BaseDatos">clave de la base de datos</param>
    /// <returns></returns>
    public static int SelectEntero(String sql, String BaseDatos)
    {
        int c = 0;
        try
        {
            var table = SQL.SelectDataTable(BaseDatos, sql);

            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    var row = table.Rows[0];
                    if (row != null)
                    {
                        c = tDatos.ToInt(row[0]);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            RegistrarError.General(BaseDatos, cAreas.SQL, "Select Entero, " + sql, ex);
        }

        return c;
    }

    /// <summary>
    /// lee un entero o un nulo devuelto de una consulta sql
    /// </summary>      
    /// <param name="sql">consulta sql</param>
    /// <param name="BaseDatos">clave de la base de datos</param>
    /// <returns></returns>
    public static int? SelectEnteroN(String sql, String BaseDatos)
    {
        int? c = null;

        try
        {
            var table = SQL.SelectDataTable(BaseDatos, sql);

            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    var row = table.Rows[0];
                    if (row != null)
                    {
                        c = tDatos.ToIntN(row[0]);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            RegistrarError.General(BaseDatos, cAreas.SQL, "Select Entero N, " + sql, ex);
        }

        return c;
    }

    /// <summary>
    /// lee un decimal o un nulo devuelto de una consulta sql
    /// </summary>
    /// <param name="sql">consulta sql</param>
    /// <param name="BaseDatos">clave de la base de datos</param>
    /// <returns></returns>
    public static decimal? SelectDecimal(String sql, String BaseDatos)
    {
        decimal? c = 0;
        try
        {
            var table = SQL.SelectDataTable(BaseDatos, sql);

            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    var row = table.Rows[0];
                    if (row != null)
                    {
                        c = tDatos.ToDecimal(row[0]);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            RegistrarError.General(BaseDatos, cAreas.SQL, "Select Decimal?, " + sql, ex);
        }

        if (c == null)
        {
            c = 0;
        }

        return c;
    }

    /// <summary>
    /// lee una cadea de una consulta sql
    /// </summary>
    /// <param name="sql">consulta sql</param>
    /// <param name="BaseDatos">clave de la base de datos</param>
    /// <returns></returns>
    public static String SelectString(String sql, String BaseDatos)
    {
        var c = "";
        try
        {
            var table = SQL.SelectDataTable(BaseDatos, sql);

            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    var row = table.Rows[0];
                    if (row != null)
                    {
                        c = tDatos.ToString(row[0]);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            RegistrarError.General(BaseDatos, cAreas.SQL, "Select String, " + sql, ex);
        }
        return c;
    }
    public static DateTime? SelectFecha(String sql, String BaseDatos)
    {
        DateTime? c = null;
        try
        {
            var table = SQL.SelectDataTable(BaseDatos, sql);

            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    var row = table.Rows[0];
                    if (row != null)
                    {
                        c = tDatos.ToDateTimeN(row[0]);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            RegistrarError.General(BaseDatos, cAreas.SQL, "Select Fecha?, " + sql, ex);
        }
        return c;
    }


    /// <summary>
    /// devuelven una datatable con filas y columnas devueltas por una consulta sql
    /// </summary>
    /// <param name="BaseDatos">clave de la bd</param>
    /// <param name="sql">consulta sql</param>
    /// <returns></returns>
    public static DataTable SelectDataTableQTCO(String sql)
    {
        return SelectDataTable(cConString.QTCO, sql);
    }

    public static DataTable SelectDataTable(String BaseDatos, String sql)
    {
        var conexion = Conexion.Create(BaseDatos);

        conexion.Open();

        using (var tabla = new DataTable())
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                adapter.SelectCommand = new SqlCommand(sql, conexion);
                adapter.Fill(tabla);
            }
            catch (Exception ex)
            {
                RegistrarError.General(BaseDatos, cAreas.SQL, "Buscar Dinámico para DataTable: " + sql.Replace("'", "*"), ex);
            }
            finally
            {
                try
                {
                    adapter.Dispose();
                }
                catch (Exception ex)
                {
                    RegistrarError.General(BaseDatos, cAreas.SQL, "Dispose Adapter en Buscar Dinámico para DataTable: " + sql, ex);
                }

                try
                {
                    conexion.Close();
                    conexion.Dispose();
                }
                catch (Exception ex)
                {
                    RegistrarError.General(BaseDatos, cAreas.SQL, "Cerrar y Dispose conexión en Buscar Dinámico para DataTable: " + sql, ex);
                }
            }
            return tabla;
        }
    }

    public static List<T> SelectList<T>(String BaseDatos, String sql) where T : new()
    {
        var conexion = Conexion.Create(BaseDatos);

        conexion.Open();

        using (var tabla = new DataTable())
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                adapter.SelectCommand = new SqlCommand(sql, conexion);
                adapter.Fill(tabla);
            }
            catch (Exception ex)
            {
                RegistrarError.General(BaseDatos, cAreas.SQL, "Buscar Dinámico para DataTable: " + sql.Replace("'", "*"), ex);
            }
            finally
            {
                try
                {
                    adapter.Dispose();
                }
                catch (Exception ex)
                {
                    RegistrarError.General(BaseDatos, cAreas.SQL, "Dispose Adapter en Buscar Dinámico para DataTable: " + sql, ex);
                }

                try
                {
                    conexion.Close();
                    conexion.Dispose();
                }
                catch (Exception ex)
                {
                    RegistrarError.General(BaseDatos, cAreas.SQL, "Cerrar y Dispose conexión en Buscar Dinámico para DataTable: " + sql, ex);
                }
            }

            var listado = tDatos.TableToList<T>(tabla);
            return listado;
        }
    }

    public static List<int?> SelectEnterosN(String sql, String BaseDatos)
    {
        var tabla = SelectDataTable(BaseDatos, sql);
        var listado = new List<int?>();

        foreach (DataRow row in tabla.Rows)
        {
            listado.Add(tDatos.ToIntN(row[0]));
        }

        return listado;
    }

    public static List<int> SelectEnteros(String sql, String BaseDatos)
    {
        var tabla = SelectDataTable(BaseDatos, sql);
        var listado = new List<int>();

        foreach (DataRow row in tabla.Rows)
        {
            listado.Add(tDatos.ToInt(row[0]));
        }

        return listado;
    }
    public static List<String> SelectStrings(String sql, String BaseDatos)
    {
        var tabla = SelectDataTable(BaseDatos, sql);
        var listado = new List<String>();

        foreach (DataRow row in tabla.Rows)
        {
            listado.Add(tDatos.ToString(row[0]));
        }

        return listado;
    }


    public static object[] Ejecutar(String BaseDatos, String area, String sql, String OperacionCompleta)
    {
        object[] resultado = new object[3] { true, null, "" };
        var checkPoint = "";

        checkPoint = " Crear la conexión. ";
        var conexion = Conexion.Create(BaseDatos);

        checkPoint = " Abrir la conexión. ";
        conexion.Open();

        checkPoint = " Crear SqlCommand. ";
        var cmd = new SqlCommand(sql);

        checkPoint = " Comenzar Transaction. ";
        SqlTransaction transaccion = conexion.BeginTransaction();

        cmd.Transaction = transaccion;
        cmd.Connection = conexion;

        checkPoint = " Ejecutar SQL.";
        try
        {
            cmd.ExecuteNonQuery();
            transaccion.Commit();
        }
        catch (Exception ex)
        {
            try
            {
                checkPoint = " Deshacer Transaction. ";
                transaccion.Rollback();
            }
            catch (Exception ex2)
            {
                RegistrarError.General(BaseDatos, area, checkPoint + OperacionCompleta + "-SQL:" + sql, ex2);
            }
            resultado[0] = false;
            resultado[1] = ex;
        }
        finally
        {
            try
            {
                checkPoint = " Desechar Transaction. ";
                transaccion.Dispose();
            }
            catch (Exception ex)
            {
                RegistrarError.General(BaseDatos, area, checkPoint + OperacionCompleta + "-SQL:" + sql, ex);
            }

            try
            {
                checkPoint = " Desechar SqlCommand. ";
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                RegistrarError.General(BaseDatos, area, checkPoint + OperacionCompleta + "-SQL:" + sql, ex);
            }

            try
            {
                checkPoint = " Cerrar conexión. ";
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                RegistrarError.General(BaseDatos, area, checkPoint + OperacionCompleta + "-SQL:" + sql, ex);
            }
        }

        resultado[2] = checkPoint;
        return resultado;
    }
    public static object[] Ejecutar(String sql, String BaseDatos, String area)
    {
        return Ejecutar(BaseDatos, area, sql, "Ejecutar SQL");
    }

    /// <summary>
    /// ejecuta un procedimiento almanacenado
    /// </summary>
    /// <param name="BaseDatos">clave de la base de datos</param>
    /// <param name="area">area del sistema</param>
    /// <param name="procedure">nombre del sp</param>
    /// <param name="parametros">lista de parametros</param>
    /// <param name="OperacionCompleta">breve descripcion del metodo invocador</param>
    /// <returns></returns>
    public static object[] Execute(String BaseDatos, String area, String procedure, List<SqlParameter> parametros, String OperacionCompleta)
    {
        object[] resultado = new object[3] { true, null, "" };
        var checkPoint = "";

        if (parametros.Count > 0)
        {
            checkPoint = " Crear la conexión. ";
            var conexion = Conexion.Create(BaseDatos);

            checkPoint = " Abrir la conexión. ";
            conexion.Open();

            checkPoint = " Crear SqlCommand. ";
            var cmd = new SqlCommand("[dbo].[" + procedure + "]");

            checkPoint = " Comenzar Transaction. ";
            SqlTransaction transaccion = conexion.BeginTransaction();

            cmd.Transaction = transaccion;
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;

            checkPoint = " Asignar parametros. ";

            foreach (var parametro in parametros)
            {
                cmd.Parameters.AddWithValue(parametro.ParameterName, parametro.Value);
            }

            checkPoint = " Ejecutar Procedure. ";
            try
            {
                cmd.ExecuteNonQuery();
                transaccion.Commit();
            }
            catch (Exception ex)
            {
                resultado[2] = checkPoint;
                try
                {
                    checkPoint = " Deshacer Transaction. ";
                    transaccion.Rollback();
                }
                catch (Exception ex2)
                {
                    resultado[2] = checkPoint;
                    RegistrarError.General(BaseDatos, area, checkPoint + OperacionCompleta, ex2);
                }
                resultado[0] = false;
                resultado[1] = ex;
            }
            finally
            {
                try
                {
                    checkPoint = " Desechar Transaction. ";
                    transaccion.Dispose();
                }
                catch (Exception ex)
                {
                    resultado[2] = checkPoint;
                    RegistrarError.General(BaseDatos, area, checkPoint + OperacionCompleta, ex);
                }

                try
                {
                    checkPoint = " Desechar SqlCommand. ";
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    resultado[2] = checkPoint;
                    RegistrarError.General(BaseDatos, area, checkPoint + OperacionCompleta, ex);
                }

                try
                {
                    checkPoint = " Cerrar conexión. ";
                    conexion.Close();
                    conexion.Dispose();
                }
                catch (Exception ex)
                {
                    resultado[2] = checkPoint;
                    RegistrarError.General(BaseDatos, area, checkPoint + OperacionCompleta, ex);
                }
            }
        }
        else
        {
            resultado[0] = false;
        }
        return resultado;
    }

    /// <summary>
    /// ejecuta el procedimiento almacenado especificado y retorna un valor
    /// </summary>
    /// <param name="BaseDatos">clave de la bd</param>
    /// <param name="area">area del sistema</param>
    /// <param name="procedure">nombre del sp</param>
    /// <param name="parametros">lista de parametros, el primero debe ser el parametro output</param>
    /// <param name="OperacionCompleta">breve descripcion de la tarea invocadora realizada </param>
    /// <returns></returns>
    public static object[] ExecuteOutPut(String BaseDatos, String area, String procedure, List<SqlParameter> parametros, String OperacionCompleta)
    {
        object[] resultado = new object[3] { true, null, "" };
        var checkPoint = "";

        if (parametros.Count > 0)
        {
            checkPoint = " Crear la conexión. ";
            var conexion = Conexion.Create(BaseDatos);

            checkPoint = " Abrir la conexión. ";
            conexion.Open();

            checkPoint = " Crear SqlCommand. ";
            var cmd = new SqlCommand("[dbo].[" + procedure + "]");

            checkPoint = " Comenzar Transaction. ";
            SqlTransaction transaccion = conexion.BeginTransaction();

            cmd.Transaction = transaccion;
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;

            checkPoint = " Asignar parametro de retorno.";
            var parametroR = parametros.FirstOrDefault();
            cmd.Parameters.AddWithValue(parametroR.ParameterName, parametroR.Value);
            cmd.Parameters[parametroR.ParameterName].Direction = ParameterDirection.Output;

            parametros.Remove(parametroR);

            checkPoint = " Asignar parametros. ";
            foreach (var parametro in parametros)
            {
                cmd.Parameters.AddWithValue(parametro.ParameterName, parametro.Value);
            }

            checkPoint = " Ejecutar Procedure. ";
            int result = 0;

            try
            {
                cmd.ExecuteNonQuery();
                resultado[1] = result = tDatos.ToInt(cmd.Parameters[parametroR.ParameterName].Value);
                transaccion.Commit();
            }
            catch (Exception ex)
            {
                resultado[2] = checkPoint;
                try
                {
                    checkPoint = " Deshacer Transaction. ";
                    transaccion.Rollback();
                }
                catch (Exception ex2)
                {
                    resultado[2] = checkPoint;
                    RegistrarError.General(BaseDatos, area, checkPoint + OperacionCompleta, ex2);
                }
                resultado[0] = false;
                resultado[1] = ex;
            }
            finally
            {
                try
                {
                    checkPoint = " Desechar Transaction. ";
                    transaccion.Dispose();
                }
                catch (Exception ex)
                {
                    resultado[2] = checkPoint;
                    RegistrarError.General(BaseDatos, area, checkPoint + OperacionCompleta, ex);
                }

                try
                {
                    checkPoint = " Desechar SqlCommand. ";
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    resultado[2] = checkPoint;
                    RegistrarError.General(BaseDatos, area, checkPoint + OperacionCompleta, ex);
                }

                try
                {
                    checkPoint = " Cerrar conexión. ";
                    conexion.Close();
                    conexion.Dispose();
                }
                catch (Exception ex)
                {
                    resultado[2] = checkPoint;
                    RegistrarError.General(BaseDatos, area, checkPoint + OperacionCompleta, ex);
                }
            }
        }
        else
        {
            resultado[0] = false;
        }
        return resultado;
    }


}