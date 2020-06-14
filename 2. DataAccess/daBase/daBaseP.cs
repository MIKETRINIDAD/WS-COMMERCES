using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Tools;

#region Bitacora
/// <summary>
/// Autor: Miguel Ángel Trinidada Cruz
/// Fecha: 13/06/2020
/// Descripcion: Clase para leer rows genericas dentro del sistema 
/// ------------------------------------------------------------------------------------------------------------
/// Feche            Estatus                  UserName                    Descripcion
/// 
/// 
/// </summary>
#endregion Bitacora

namespace DataAccess.Base
{
    public abstract class daBaseP<T> where T : new()
    {
        #region Propiedades
        private string procesoInvocador { get; set; }
        public String ProcesoInvocador
        {
            get { return procesoInvocador; }
        }
        private string BaseDatos { get; set; }
        private string Area { get; set; }
        private string Clase { get; set; }
        private DateTime Inicio { get; set; }
        private Nullable<DateTime> Final { get; set; }
        public List<eLog2> log { get; set; }
        private string CheckPoint { get; set; }
        public string checkPoint
        {
            get
            {
                var v = CheckPoint;
                CheckPoint = "";
                return v;
            }
            set { CheckPoint = value; }
        }
        #endregion Propiedades

        #region Constructores
        public daBaseP(String proceso, String BaseDatos, String area)
        {
            this.procesoInvocador = proceso;
            checkPoint = " Inicializar control de datos.";
            Inicio = DateTime.Now;
            Clase = this.GetType().Name;
            this.BaseDatos = BaseDatos;
            Area = area;
            AppDomain.CurrentDomain.FirstChanceException += OnError;
        }
        #endregion Constructores

        #region Métodos
        #region Lectura
        abstract public T Buscar(int Id);
        protected T Leer(DataRow row)
        {
            dynamic registro = new T();

            try
            {
                registro = tDatos.LeerAuto<T>(row);

                return registro;
            }
            catch (Exception ex)
            {
                RegistrarError.General(BaseDatos, Area, "Leer e" + Clase.Remove(0, 2) + ": " + registro.id, ex);
            }

            return default(T);
        }
        public T Buscar(String sql)
        {
            try
            {
                checkPoint = " Ejecutar consulta: " + sql;
                var tabla = SQL.SelectDataTable(BaseDatos, sql);

                if (tabla != null)
                {
                    if (tabla.Rows.Count > 0)
                    {
                        checkPoint = " Leer Row";
                        return Leer(tabla.Rows[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    throw new daException(ex);
                }
                catch { }
            }
            return default(T);
        }
        public List<T> BuscarVarios(String sql)
        {
            var listado = new List<T>();

            try
            {
                checkPoint = " Ejecutar consulta: " + sql;
                var tabla = SQL.SelectDataTable(BaseDatos, sql);


                if (tabla != null)
                {
                    checkPoint = " Iterar el DataTable Resultado.";
                    foreach (DataRow row in tabla.Rows)
                    {
                        checkPoint = " Leer row.";
                        var c = Leer(row);

                        if (c != null)
                        {
                            listado.Add(c);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    throw new daException(ex);
                }
                catch { }
            }
            return listado;
        }
        #endregion Lectura
        private void OnError(object sender, FirstChanceExceptionEventArgs e)
        {
            if (e.Exception.GetType() == typeof(daException))
            {
                var Método = "";
                try
                {
                    Método = e.Exception.TargetSite.Name;
                }
                catch { }
                RegistrarError.General(BaseDatos, Area, "Clase DataAccess: " + Clase + ". Método: " + Método + ". Proceso Invocador: " + ProcesoInvocador + ". CheckPoint: " + checkPoint, e.Exception);
            }
        }
        #endregion Métodos
    }
}
