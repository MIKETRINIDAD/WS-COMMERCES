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
/// Descripcion: Clase para la captura de errores entorno al SQL
/// ------------------------------------------------------------------------------------------------------------
/// Feche            Estatus                  UserName                    Descripcion
/// 
/// 
/// </summary>
#endregion Bitacora

public static class Errores
{
    /// <summary>
    /// Válida resultado de operaciones con bd 
    /// </summary>
    /// <param name="res">Contiene el resultado del método Administrar</param>
    /// <param name="CheckPointError">Almacenará el posible error develto</param>
    /// <returns></returns>
    public static bool validarOperacion(object[] res, string CheckPointError)
    {
        if (Convert.ToBoolean(res[0]))
        {
            CheckPointError = "";
            return true;
        }
        else
        {
            CheckPointError = tDatos.ToString(res[1]);
            return false;
        }
    }

    /// <summary>
    /// Válida resultado de operaciones con bd 
    /// </summary>
    /// <param name="res">Contiene el resultado del método Administrar</param>
    /// <param name="CheckPointError">Almacenará el posible error develto</param>
    /// <returns></returns>
    public static bool validarOperacion(object[] res)
    {
        if (Convert.ToBoolean(res[0]))
        {
            //CheckPointError = "";
            return true;
        }
        else
        {
            // CheckPointError = tDatos.ToString(res[1]);
            return false;
        }
    }
    /// <summary>
    /// Se encarga de validar las respuestas obtenidas de los métodos de la clase SQL
    /// </summary>
    /// <param name="res">Resultado devuelto por los métodos sql</param>
    /// <param name="Area">Aréa o Tabla de la Base de Datos</param>
    /// <param name="MensajeError">Mensaje de Error para Insertar en el Control de Errores, en caso de ocurrir</param>
    /// <returns></returns>

    public static object[] Control(object[] res, string Area, string MensajeError)
    {
        var resultado = new object[2] { true, "" };
        var checkPoint = "";

        if (Convert.ToBoolean(res[0]) != true)
        {
            resultado[0] = false;
            if (res[2] != null)
            {
                checkPoint = res[2].ToString();
            }

            resultado[1] = checkPoint;
            if (res[1] != null)
            {
                var ex = res[1] as Exception;
                RegistrarError.QTCO(Area, MensajeError, ex);
            }
        }
        else
        {
            resultado[1] = res[1];
        }

        return resultado;

    }
}

public static class RegistrarError
{
    //QTCO
    public static void QTCO(String Categoria, String Operacion, String Error)
    {
        General(cConString.QTCO, Categoria, Operacion, Error);
    }
    public static void QTCO(String Categoria, String Operacion, Exception Error)
    {
        General(cConString.QTCO, Categoria, Operacion, Error);
    }

    private static void General(String Sistema, String Categoria, String Operacion, SqlException SqlEx)
    {
        try
        {
            foreach (SqlError error in SqlEx.Errors)
            {
                var parametros = new List<SqlParameter>();

                parametros.Add(new SqlParameter("@area", Sistema));
                parametros.Add(new SqlParameter("@operacion", Operacion.Replace("'", "*").Replace("\n", " ").Replace("\r", " ")));
                parametros.Add(new SqlParameter("@categoria", Categoria.Replace("'", "*").Replace("\n", " ").Replace("\r", " ")));
                parametros.Add(new SqlParameter("@source", tDatos.ToString(error.Source ?? "")));
                parametros.Add(new SqlParameter("@message", tDatos.ToString(error.Message.Replace("'", "*").Replace("\n", " ").Replace("\r", " "))));
                parametros.Add(new SqlParameter("@stackTrace", tDatos.ToString(error.LineNumber)));
                parametros.Add(new SqlParameter("@targetSite", tDatos.ToString(error.State)));
                parametros.Add(new SqlParameter("@hResult", tDatos.ToString(error.State)));

                SQL.Execute(cConString.QTCO, cAreas.Error, "IspError", parametros, "Registrar Error");
            }

            if (SqlEx.InnerException != null)
            {
                General(Sistema, Categoria, Operacion, SqlEx.InnerException);
            }
        }
        catch (Exception ex)
        {
            var exx = ex;
        }
    }

    private static void General(String Sistema, String Categoria, String Operacion, NullReferenceException nullEx)
    {
        try
        {
            var parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@area", Sistema));
            parametros.Add(new SqlParameter("@operacion", Operacion.Replace("'", "*").Replace("\n", " ").Replace("\r", " ")));
            parametros.Add(new SqlParameter("@categoria", Categoria.Replace("'", "*").Replace("\n", " ").Replace("\r", " ")));
            parametros.Add(new SqlParameter("@source", tDatos.ToString(nullEx.Source ?? "")));
            parametros.Add(new SqlParameter("@message", tDatos.ToString(nullEx.Message.Replace("'", "*").Replace("\n", " ").Replace("\r", " "))));
            parametros.Add(new SqlParameter("@stackTrace", tDatos.ToString(nullEx.TargetSite)));
            parametros.Add(new SqlParameter("@targetSite", tDatos.ToString(nullEx.TargetSite)));
            parametros.Add(new SqlParameter("@hResult", tDatos.ToString(nullEx.HResult)));

            SQL.Execute(cConString.QTCO, cAreas.Error, "IspError", parametros, "Registrar Error");

            if (nullEx.InnerException != null)
            {
                General(Sistema, Categoria, Operacion, nullEx.InnerException);
            }
        }
        catch (Exception ex)
        {
            var exx = ex;
        }
    }

    public static void General(String Sistema, String Categoria, String Operacion, String Error)
    {
        try
        {
            var parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@area", Sistema));
            parametros.Add(new SqlParameter("@operacion", Operacion.Replace("'", "*").Replace("\n", " ").Replace("\r", " ")));
            parametros.Add(new SqlParameter("@categoria", Categoria.Replace("'", "*").Replace("\n", " ").Replace("\r", " ")));
            parametros.Add(new SqlParameter("@source", " "));
            parametros.Add(new SqlParameter("@message", Error.Replace("'", "*").Replace("\n", " ").Replace("\r", " ")));
            parametros.Add(new SqlParameter("@stackTrace", " "));
            parametros.Add(new SqlParameter("@targetSite", " "));
            parametros.Add(new SqlParameter("@hResult", " "));

            SQL.Execute(cConString.QTCO, cAreas.Error, "IspError", parametros, "Registrar Error");
        }
        catch (Exception ex)
        {
            var exx = ex;
        }
    }
    public static void General(String BaseDatos, String AreaSistema, String Operacion, Exception Excepcion)
    {
        if (Excepcion.GetType() == typeof(SqlException))
        {
            General(BaseDatos, AreaSistema, Operacion, Excepcion as SqlException);
        }
        else if (Excepcion.GetType() == typeof(NullReferenceException))
        {
            General(BaseDatos, AreaSistema, Operacion, Excepcion as NullReferenceException);
        }
        else
        {
            var continuar = true;
            var nv = 1;
            do
            {
                try
                {
                    var parametros = new List<SqlParameter>();

                    parametros.Add(new SqlParameter("@area", BaseDatos));
                    parametros.Add(new SqlParameter("@operacion", Operacion.Replace("'", "*").Replace("\n", " ").Replace("\r", " ")));
                    parametros.Add(new SqlParameter("@categoria", AreaSistema));
                    parametros.Add(new SqlParameter("@source", (Excepcion.Source != null ? Excepcion.Source.Replace("'", "*").Replace("\n", " ").Replace("\r", " ") : "")));
                    parametros.Add(new SqlParameter("@message", Excepcion.Message.Replace("'", "*").Replace("\n", " ").Replace("\r", " ")));
                    parametros.Add(new SqlParameter("@stackTrace", Excepcion.StackTrace.Replace("'", "*").Replace("\n", " ").Replace("\r", " ")));
                    parametros.Add(new SqlParameter("@targetSite", Excepcion.TargetSite.ToString().Replace("'", "*").Replace("\n", " ").Replace("\r", " ")));
                    parametros.Add(new SqlParameter("@hResult", "'" + Excepcion.HResult.ToString().Replace("'", "*").Replace("\n", " ").Replace("\r", " ") + "'"));

                    SQL.Execute(cConString.QTCO, cAreas.Error, "IspError", parametros, "Registrar Error");

                    if (Excepcion.InnerException != null)
                    {
                        Excepcion = Excepcion.InnerException;
                    }
                    else
                    {
                        continuar = false;
                    }
                }
                catch (Exception ex)
                {
                    var ex2 = ex;
                    continuar = false;
                }
                nv++;
            } while (continuar && nv < 2);
        }
    }

    /*Fin*/
}
