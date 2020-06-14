using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class tDatos
    {
        public static String obtenerAniosMesesDias(DateTime newdt, DateTime olddt)
        {
            Int32 anios;
            Int32 meses;
            Int32 dias;
            String str = "";

            anios = (newdt.Year - olddt.Year);
            meses = (newdt.Month - olddt.Month);
            dias = (newdt.Day - olddt.Day) + 1;

            if (meses < 0)
            {
                anios -= 1;
                meses += 12;
            }
            if (dias < 0)
            {
                meses -= 1;
                dias += DateTime.DaysInMonth(newdt.Year, newdt.Month);
            }

            if (anios > 0)
            {
                if (anios == 1)
                {
                    str = str + anios.ToString() + " AÑO, ";
                }
                else
                {
                    str = str + anios.ToString() + " AÑOS, ";

                }
            }
            if (meses > 0)
            {
                if (meses == 1)
                {
                    str = str + meses.ToString() + " MES, ";
                }
                else
                {
                    str = str + meses.ToString() + " MESES, ";
                }
            }
            if (dias > 0)
            {
                if (dias == 1)
                {
                    str = str + dias.ToString() + " DIA ";
                }
                else
                {
                    str = str + dias.ToString() + " DIAS ";
                }
            }


            return str;
        }



        #region Operaciones con Propiedades y tipos de Datos
        public static DataTable ListToTable<T>(List<T> lista) where T : new()
        {
            var tabla = new DataTable();


            return tabla;
        }
        public static List<T> TableToList<T>(DataTable tabla) where T : new()
        {
            List<T> listado = new List<T>();

            if (tabla != null)
            {
                if (tabla.Rows.Count > 0)
                {
                    foreach (DataRow row in tabla.Rows)
                    {
                        var item = tDatos.LeerAuto<T>(row);

                        listado.Add(item);
                    }
                }
            }

            return listado;
        }
        public static T LeerAuto<T>(DataRow row) where T : new()
        {
            var objeto = new T();
            var propiedades = GetProperties(objeto);

            foreach (var p in propiedades)
            {
                try
                {
                    var v = row[p.Name];
                    SetValue(p.Name, objeto, v);
                }
                catch { }
            }

            return objeto;
        }

        public static T CopyProperties<T>(Object obj1) where T : new()
        {
            var obj2 = new T();
            try
            {
                var pobj1 = tDatos.GetProperties(obj1);

                foreach (var v in pobj1)
                {
                    try
                    {

                        var v2 = tDatos.GetValue(v.Name, obj1);
                        tDatos.SetValue(v.Name, obj2, v2);
                    }
                    catch (Exception ex) { var exx = ex; }
                }
            }
            catch (Exception ex)
            {
                var y = ex;
            }
            return obj2;
        }

        public static T CopyProperties<T>(Object obj1, T obj2)
        {
            try
            {
                var pobj1 = tDatos.GetProperties(obj1);

                foreach (var v in pobj1)
                {
                    try
                    {
                        var v2 = tDatos.GetValue(v.Name, obj1);
                        tDatos.SetValue(v.Name, obj2, v2);
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                var y = ex;
            }
            return obj2;
        }


        public static List<PropertyInfo> GetProperties(object objeto)
        {
            if (objeto != null)
            {
                return objeto.GetType().GetProperties().Where(x => x.PropertyType == typeof(int) ||
                                                                    x.PropertyType == typeof(int?) ||
                                                                    x.PropertyType == typeof(String) ||
                                                                    x.PropertyType == typeof(string) ||
                                                                    x.PropertyType == typeof(Decimal) ||
                                                                    x.PropertyType == typeof(Decimal?) ||
                                                                    x.PropertyType == typeof(decimal) ||
                                                                    x.PropertyType == typeof(decimal?) ||
                                                                    x.PropertyType == typeof(char) ||
                                                                    x.PropertyType == typeof(Char) ||
                                                                    x.PropertyType == typeof(char?) ||
                                                                    x.PropertyType == typeof(Char?) ||
                                                                    x.PropertyType == typeof(double) ||
                                                                    x.PropertyType == typeof(Double) ||
                                                                    x.PropertyType == typeof(double?) ||
                                                                    x.PropertyType == typeof(Double?) ||
                                                                    x.PropertyType == typeof(DateTime) ||
                                                                    x.PropertyType == typeof(DateTime?) ||
                                                                    x.PropertyType == typeof(byte?[]) ||
                                                                    x.PropertyType == typeof(byte[]) ||
                                                                    x.PropertyType == typeof(Byte[]) ||
                                                                    x.PropertyType == typeof(Byte?[]) ||
                                                                    x.PropertyType == typeof(bool) ||
                                                                    x.PropertyType == typeof(bool?) ||
                                                                    x.PropertyType == typeof(Boolean) ||
                                                                    x.PropertyType == typeof(Boolean?) ||
                                                                    x.PropertyType == typeof(Object) ||
                                                                    x.PropertyType == typeof(object)).ToList();
            }
            else
            {
                return new List<PropertyInfo>();
            }
        }

        public static object ToObject<T>(T objeto)
        {
            var tipo = typeof(T);

            if (tipo == typeof(int) || tipo == typeof(int?))
            {
                if (objeto != null)
                {
                    return objeto;
                }
                else
                {
                    return 0;
                }
            }
            else if (tipo == typeof(String) || tipo == typeof(string))
            {
                if (objeto != null)
                {
                    return objeto;
                }
                else
                {
                    return "";
                }
            }
            else if (tipo == typeof(decimal) || tipo == typeof(decimal?) || tipo == typeof(Decimal) || tipo == typeof(Decimal?))
            {
                if (objeto != null)
                {
                    return objeto;
                }
                else
                {
                    return 0;
                }
            }
            else if (tipo == typeof(DateTime))
            {
                if (objeto != null)
                {
                    return objeto;
                }
                else
                {
                    return DateTime.Now;
                }
            }
            else if (tipo == typeof(double) || tipo == typeof(double?) || tipo == typeof(Double) || tipo == typeof(Double?))
            {
                if (objeto != null)
                {
                    return objeto;
                }
                else
                {
                    return 0;
                }
            }
            else if (tipo == typeof(bool) || tipo == typeof(bool?) || tipo == typeof(Boolean) || tipo == typeof(Boolean?))
            {
                if (objeto != null)
                {
                    return objeto;
                }
                else
                {
                    return 0;
                }
            }
            else if (tipo == typeof(DateTime?))
            {
                if (objeto != null)
                {
                    return objeto;
                }
                else
                {
                    return DBNull.Value;
                }
            }
            else if (tipo == typeof(Byte[]) || tipo == typeof(byte[]) || tipo == typeof(Byte?[]) || tipo == typeof(byte?[]))
            {
                if (objeto != null)
                {
                    return objeto;
                }
                else
                {
                    return 0;
                }
            }
            return "0";
        }
        public static byte[] ToBytes(Object objeto)
        {
            var n = objeto.GetType().FullName;
            if (objeto.GetType().FullName.ToLower().Contains("byte[]"))
            {
                try
                {
                    return (byte[])objeto;
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }
        //ToDateTime
        public static DateTime ToDateTime(DateTime? fecha)
        {
            try
            {
                return Convert.ToDateTime(fecha);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        public static DateTime ToDateTime(Object fecha)
        {
            try
            {
                return Convert.ToDateTime(fecha);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        public static Double ToDouble(Object num)
        {
            try
            {
                if (num != null)
                {
                    return Convert.ToDouble(num);
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
        public static DateTime ToDateTime(String fecha)
        {
            try
            {
                return Convert.ToDateTime(fecha);
            }
            catch
            {
                return DateTime.Now;
            }
        }

        public static DateTime? ToDateTimeN(string fecha)
        {
            try
            {
                return Convert.ToDateTime(fecha);
            }
            catch
            {
                return null;
            }
        }

        public static DateTime? ToDateTimeN(object fecha)
        {
            try
            {
                if (fecha != null)
                {
                    if (!String.IsNullOrEmpty(fecha.ToString()))
                    {
                        return Convert.ToDateTime(fecha);
                    }
                }
            }
            catch
            {
            }
            return null;
        }

        //ToString
        public static String ToString(decimal? valor, String format)
        {
            try
            {
                if (valor != null)
                {
                    var f = String.Format(format, tDatos.ToDecimal(valor));
                    return f;
                }
                else
                {
                    return "0.00";
                }
            }
            catch
            {
                return "0.00";
            }
        }
        public static String ToString(DateTime? fecha, String format)
        {
            try
            {
                if (fecha != null)
                {
                    var f = Convert.ToDateTime(fecha).ToString(format);
                    return f;
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }
        public static String ToString(DateTime? fecha)
        {
            try
            {
                return (Convert.ToDateTime(fecha)).ToString("dd/MM/yyyy");
            }
            catch
            {
                return "";
            }
        }
        public static String ToString(object cadena)
        {
            try
            {
                if (cadena != null)
                {
                    return cadena.ToString();
                }
                else
                {
                    return String.Empty;
                }
            }
            catch
            {
                return "";
            }
        }

        public static String ToString(string cadena)
        {
            try
            {
                return cadena.ToString();
            }
            catch
            {
                return "";
            }
        }
        public static String ToString(decimal? cadena)
        {
            try
            {
                if (cadena != null)
                {
                    return cadena.ToString();
                }
                else
                {
                    return "0";
                }
            }
            catch
            {
                return "0";
            }
        }
        //Trim
        public static string Trim(string cadena)
        {
            try
            {
                return cadena.Trim();
            }
            catch
            {
                return "";
            }
        }
        //ToBool
        public static Boolean ToBool(bool? valor)
        {
            try
            {
                return Convert.ToBoolean(valor);
            }
            catch
            {
                return false;
            }
        }
        public static Boolean ToBool(object valor)
        {
            try
            {
                return Convert.ToBoolean(valor);
            }
            catch
            {
                return false;
            }
        }
        //ToInt
        public static int ToInt(string numero)
        {
            var n = 0;
            try
            {
                n = Convert.ToInt32(ReemplazarSimbolos(numero).Replace(",", ""));
            }
            catch
            {
                n = 0;
            }
            return n;
        }
        public static int ToInt(object numero)
        {
            var n = 0;
            try
            {
                n = Convert.ToInt32(numero);
            }
            catch
            {
                n = 0;
            }
            return n;
        }
        public static int? ToIntN(object numero)
        {
            int? n = 0;
            try
            {
                if (numero != null)
                {
                    n = Convert.ToInt32(numero);
                }
                else
                {
                    n = null;
                }
            }
            catch
            {
                n = null;
            }
            return n;
        }

        public static int ToInt(decimal? numero)
        {
            var n = 0;
            try
            {
                n = Convert.ToInt32(numero);
            }
            catch
            {
                n = 0;
            }
            return n;
        }

        public static List<int> ToInt(List<int?> numeros)
        {
            var listado = new List<int>();

            foreach (var n in numeros.Where(x => x != null).ToList())
            {
                listado.Add(ToInt(n));
            }

            return listado;
        }

        public static List<int?> ToInt(List<int> numeros)
        {
            var listado = new List<int?>();

            foreach (var n in numeros)
            {
                listado.Add(ToInt(n));
            }

            return listado;
        }

        //ToDecimal
        public static decimal ToDecimal(string numero)
        {
            try
            {
                var n = ReemplazarSimbolos(numero).Replace(",", "");
                return Convert.ToDecimal(n);
            }
            catch
            {
                return 0;
            }
        }
        public static decimal ToDecimal(double numero)
        {
            try
            {
                return Convert.ToDecimal(Convert.ToString(numero));
            }
            catch
            {
                return 0;
            }
        }
        public static decimal ToDecimal(double? numero)
        {
            try
            {
                return Convert.ToDecimal(numero);
            }
            catch
            {
                return 0;
            }
        }
        public static decimal ToDecimal(decimal? numero)
        {
            try
            {
                if (numero != null)
                {
                    return Convert.ToDecimal(numero);
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
        public static decimal ToDecimal(int numero)
        {
            try
            {
                return Convert.ToDecimal(numero);
            }
            catch
            {
                return 0;
            }
        }
        public static decimal ToDecimal(object numero)
        {
            if (numero != null)
            {
                try
                {
                    return Convert.ToDecimal(numero);
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }


        public static object GetValue(string Property, object Objeto)
        {
            var value = Objeto.GetType().GetProperties().Single(prop => prop.Name == Property).GetValue(Objeto);

            return value;
        }




        public static object SetValue(string Property, Object Objeto, Object value)
        {
            try
            {
                var pType = Objeto.GetType().GetProperties().Single(prop => prop.Name == Property).PropertyType;

                if (pType == typeof(int) ||
                    pType == typeof(int?))
                {
                    Objeto.GetType().GetProperties().Single(prop => prop.Name == Property).SetValue(Objeto, tDatos.ToInt(value));
                }
                else if (pType == typeof(String) ||
                    pType == typeof(string))
                {
                    Objeto.GetType().GetProperties().Single(prop => prop.Name == Property).SetValue(Objeto, tDatos.ToString(value));
                }
                else if (pType == typeof(bool) ||
                    pType == typeof(bool?) ||
                    pType == typeof(Boolean) ||
                    pType == typeof(Boolean?))
                {
                    Objeto.GetType().GetProperties().Single(prop => prop.Name == Property).SetValue(Objeto, tDatos.ToBool(value));
                }
                else if (pType == typeof(decimal) ||
                    pType == typeof(decimal?) ||
                    pType == typeof(Decimal) ||
                    pType == typeof(Decimal?))
                {
                    Objeto.GetType().GetProperties().Single(prop => prop.Name == Property).SetValue(Objeto, tDatos.ToDecimal(value));
                }
                else
                if (pType == typeof(DateTime?))
                {
                    Objeto.GetType().GetProperties().Single(prop => prop.Name == Property).SetValue(Objeto, tDatos.ToDateTimeN(value));
                }
                else if (pType == typeof(DateTime))
                {
                    Objeto.GetType().GetProperties().Single(prop => prop.Name == Property).SetValue(Objeto, tDatos.ToDateTime(value));
                }
                else if (pType == typeof(Double) ||
                    pType == typeof(Double?) ||
                    pType == typeof(double) ||
                    pType == typeof(double?))
                {
                    Objeto.GetType().GetProperties().Single(prop => prop.Name == Property).SetValue(Objeto, tDatos.ToDouble(value));
                }
                else if (pType == typeof(Byte[]) ||
                    pType == typeof(byte[]))
                {
                    Objeto.GetType().GetProperties().Single(prop => prop.Name == Property).SetValue(Objeto, tDatos.ToBytes(value));
                }
                else if (pType == typeof(Object) ||
                    pType == typeof(object))
                {
                    Objeto.GetType().GetProperties().Single(prop => prop.Name == Property).SetValue(Objeto, value);
                }
            }
            catch// (Exception ex)
            {
                //   var exx = ex;
            }

            return Objeto;
        }
        #endregion Operaciones con Propiedades y tipos de Datos

        public static List<int> ToList(List<int?> lista)
        {
            var lista2 = new List<int>();

            foreach (var l in lista)
            {
                lista2.Add(tDatos.ToInt(l));
            }

            return lista2;
        }
        public static List<int?> ToList(List<int> lista)
        {
            var lista2 = new List<int?>();

            foreach (var l in lista)
            {
                lista2.Add(l);
            }

            return lista2;
        }



        public static String SiNo(bool? valor)
        {
            if (tDatos.ToBool(valor))
            {
                return "Sí";
            }
            else
            {
                return "No";
            }
        }

        public static int AñosTranscurridos(DateTime fechaInicial, DateTime fechaFinal)
        {
            var año = fechaFinal.AddTicks(-fechaInicial.Ticks).Year - 1;
            return tDatos.ToInt(año);
        }



        #region Operaciones númericas
        public static decimal Redondear(decimal numeroAredondear)
        {
            var negativo = false;

            if (numeroAredondear < 0)
            {
                negativo = true;
                numeroAredondear *= -1;
            }

            decimal numeroRedondeado = numeroAredondear;

            if (numeroAredondear != 0)
            {
                var split1 = numeroAredondear.ToString().Split('.');
                var entero1 = tDatos.ToDecimal(split1[0]);

                if (split1.Count() > 1)
                {
                    if (split1[1].Count() >= 3)
                    {
                        var decimal1 = tDatos.ToDecimal(split1[1].Substring(0, 3)) / 10;
                        var split2 = decimal1.ToString().Split('.');

                        var entero2 = tDatos.ToDecimal(split2[0]);
                        decimal decimal2 = tDatos.ToDecimal(split1[1].Substring(2, 1));

                        if (decimal2 >= 5)
                        {
                            numeroRedondeado = entero1 + (Math.Ceiling(decimal1) / 100);//redondear hacia arriba
                        }
                        else
                        {
                            numeroRedondeado = entero1 + (Math.Floor(decimal1) / 100);//redondear hacia arriba
                        }
                    }
                }
                else
                {
                    numeroRedondeado = entero1;
                }
            }
            else
            {
                numeroRedondeado = 0;
            }

            try
            {
                numeroRedondeado = Math.Round(numeroRedondeado, 2);
            }
            catch { }

            if (negativo)
            {
                numeroRedondeado *= -1;
            }

            return numeroRedondeado;
        }
        public static decimal Redondear(decimal? cantidad)
        {
            return Redondear(tDatos.ToDecimal(cantidad));
        }
        public static decimal Redondear(double cantidad)
        {
            return Redondear(tDatos.ToDecimal(cantidad));
        }
        public static decimal Redondear(double? cantidad)
        {
            return Redondear(tDatos.ToDecimal(cantidad));
        }
        public static decimal RedondearTomando3(decimal? cantidad)
        {
            return Redondear(tDatos.ToDecimal(cantidad));
        }
        public static decimal RedondearTomando3(decimal cantidad)
        {
            return Redondear(cantidad);
        }
        #endregion Operaciones númericas


        //paginados
        public static int pagina(string pag)
        {
            var posicion = tDatos.ToInt(pag) - 1;
            var pagina = "1";
            if (posicion > 0)
            {
                pagina = posicion + "00";
            }
            return tDatos.ToInt(pagina);
        }

        public static string RemoverAComa(string cadena)
        {
            if (cadena.Contains(","))
            {
                return cadena.Remove(cadena.IndexOf(","), cadena.Length - (cadena.IndexOf(",")));
            }
            else
            {
                return cadena;
            }
        }


        public static string DescripcionEntreFechas(DateTime? fechaInicial, DateTime? fechaFinal)
        {
            return DescripcionEntreFechas(ToDateTime(fechaInicial), ToDateTime(fechaFinal));
        }

        public static string DescripcionEntreFechas(DateTime fechaInicial, DateTime fechaFinal)
        {
            var resultado = "";

            if (fechaInicial == fechaFinal)
            {
                resultado = "Del " + fechaInicial.ToString("dd") + " de " + tDatos.getMes(fechaInicial.Month) + " del " + fechaFinal.Year.ToString();
            }
            else
            {
                //mes y año igual
                if ((fechaFinal.Month == fechaInicial.Month) && (fechaInicial.Year == fechaFinal.Year))
                {
                    resultado = "Del " + fechaInicial.ToString("dd") + " al " + fechaFinal.ToString("dd") + " de " + tDatos.getMes(fechaInicial.Month) + " del " + fechaFinal.Year.ToString();
                }
                //solo año igual
                else if (fechaInicial.Year == fechaFinal.Year)
                {
                    resultado = "Del " + fechaInicial.ToString("dd") + " de " + tDatos.getMes(fechaInicial.Month) + " al " + fechaFinal.ToString("dd") + " de " + tDatos.getMes(fechaFinal.Month) + " del " + fechaFinal.Year.ToString();
                }
                else
                {
                    resultado = "Del " + fechaInicial.ToString("dd") + " de " + tDatos.getMes(fechaInicial.Month) + " del " + fechaInicial.Year.ToString() + " al " + fechaFinal.ToString("dd") + " de " + tDatos.getMes(fechaFinal.Month) + " del " + fechaFinal.Year.ToString();
                }
            }
            return resultado;
        }

        //tipos de datos
        //correcion de acentos y simbolos 
        public static string ReemplazarSimbolosBanca(string cadena)
        {
            cadena = cadena.Replace("(", " ");
            cadena = cadena.Replace(")", " ");
            cadena = cadena.Replace(".", " ");
            cadena = cadena.Replace(",", " ");
            cadena = cadena.Replace("°", " ");
            cadena = cadena.Replace("'", " ");
            cadena = cadena.Replace("!", " ");
            cadena = cadena.Replace("#", " ");
            cadena = cadena.Replace("%", " ");
            cadena = cadena.Replace("=", " ");
            cadena = cadena.Replace("?", " ");
            cadena = cadena.Replace("¡", " ");
            cadena = cadena.Replace("¿", " ");
            cadena = cadena.Replace("*", " ");
            cadena = cadena.Replace("{", " ");
            cadena = cadena.Replace("}", " ");
            cadena = cadena.Replace("[", " ");
            cadena = cadena.Replace("]", " ");
            cadena = cadena.Replace(">", " ");
            cadena = cadena.Replace("<", " ");
            cadena = cadena.Replace(";", " ");
            cadena = cadena.Replace(":", " ");
            cadena = cadena.Replace("_", " ");
            cadena = cadena.Replace("-", " ");
            cadena = cadena.Replace("+", " ");
            cadena = cadena.Replace("-", " ");
            cadena = cadena.Replace("&", " ");
            cadena = cadena.Replace("|", " ");
            cadena = cadena.Replace("/", " ");
            cadena = cadena.Replace("á", "a");
            cadena = cadena.Replace("é", "e");
            cadena = cadena.Replace("í", "i");
            cadena = cadena.Replace("ó", "o");
            cadena = cadena.Replace("ú", "u");
            cadena = cadena.Replace("Á", "A");
            cadena = cadena.Replace("É", "E");
            cadena = cadena.Replace("Í", "I");
            cadena = cadena.Replace("Ó", "O");
            cadena = cadena.Replace("Ú", "U");
            cadena = cadena.Replace("ü", "u");
            cadena = cadena.Replace("ö", "o");
            cadena = cadena.Replace("Ü", "U");
            cadena = cadena.Replace("Ö", "O");
            cadena = cadena.Replace("Ñ", "N");
            cadena = cadena.Replace("ñ", "n");

            return cadena;
        }
        public static string ReemplazarSimbolos(string cadena)
        {
            cadena = cadena.Replace("&nbsp;", "");
            cadena = cadena.Replace("&#209;", "Ñ");
            cadena = cadena.Replace("&#211;", "Ó");
            cadena = cadena.Replace("&#193;", "Á");
            cadena = cadena.Replace("Ã¡", "á");
            cadena = cadena.Replace("&#201;", "É");
            cadena = cadena.Replace("&amp;", "");
            cadena = cadena.Replace("&#205;", "Í");
            cadena = cadena.Replace("&#218;", "Ú");
            cadena = cadena.Replace("&#220;", "Ü");
            cadena = cadena.Replace("&#225;", "á");
            cadena = cadena.Replace("&#233;", "é");
            cadena = cadena.Replace("&#237;", "í");
            cadena = cadena.Replace("&#241;", "ñ");
            cadena = cadena.Replace("&#243;", "ó");
            cadena = cadena.Replace("&#250;", "ú");
            cadena = cadena.Replace("&#252;", "ü");
            cadena = cadena.Replace("&#39;", "'");
            cadena = cadena.Replace("Ãº", "ú");

            return cadena;
        }
        //devuelve fecha escrita sin dia
        public static string FechaLargaSD(DateTime? fecha)
        {
            var fech = "";

            fech = Convert.ToDateTime(fecha).ToLongDateString()
                .Replace("lunes, ", "")
                .Replace("martes, ", "")
                .Replace("miércoles, ", "")
                .Replace("jueves, ", "")
                .Replace("viernes, ", "")
                .Replace("sábado, ", "")
                .Replace("domingo, ", "");
            return fech;
        }
        public static string LSString(List<string> lista)
        {
            var cadena = "''";

            if (lista.Count > 0)
            {
                cadena = "";
                foreach (var n in lista)
                {
                    cadena = "," + "'" + n + "'" + cadena;
                }

                cadena = cadena.Substring(1, (cadena.Length - 1));
            }
            return cadena;
        }
        public static string LNumerosString(List<int?> lista)
        {
            var cadena = "0";

            if (lista.Count > 0)
            {
                cadena = "";
                foreach (var n in lista)
                {
                    cadena = "," + n + cadena;
                }

                cadena = cadena.Substring(1, (cadena.Length - 1));
            }
            return cadena;
        }
        public static string LNumerosString(List<int> lista)
        {
            var cadena = "0";

            if (lista.Count > 0)
            {
                cadena = "";
                foreach (var n in lista)
                {
                    cadena = "," + n + cadena;
                }

                cadena = cadena.Substring(1, (cadena.Length - 1));
            }
            return cadena;
        }

        public static String DiferenciaFechas(DateTime fechaReciente, DateTime fechaAntigua)
        {
            Int32 anios;
            Int32 meses;
            Int32 dias;
            String str = " ";

            anios = (fechaReciente.Year - fechaAntigua.Year);
            meses = (fechaReciente.Month - fechaAntigua.Month);
            dias = (fechaReciente.Day - fechaAntigua.Day);

            if (meses < 0)
            {
                anios -= 1;
                meses += 12;
            }
            if (dias < 0)
            {
                meses -= 1;
                dias += DateTime.DaysInMonth(fechaReciente.Year, fechaReciente.Month);
            }

            if (anios < 0)
            {
                return "Fecha Invalida";
            }
            if (anios > 0)
                str = str + anios.ToString() + " años ";
            if (meses > 0)
                str = str + meses.ToString() + " meses ";
            if (dias > 0)
                str = str + dias.ToString() + " dias";

            return str.Replace(" 1 años", "1 año").Replace(" 1 meses", " 1 mes").Replace(" 1 dias", " 1 día").TrimStart();
        }


        public static string getMes(int? mes)
        {
            switch (mes)
            {
                case 1:
                    return "Enero";
                case 2:
                    return "Febrero";
                case 3:
                    return "Marzo";
                case 4:
                    return "Abril";
                case 5:
                    return "Mayo";
                case 6:
                    return "Junio";
                case 7:
                    return "Julio";
                case 8:
                    return "Agosto";
                case 9:
                    return "Septiembre";
                case 10:
                    return "Octubre";
                case 11:
                    return "Noviembre";
                case 12:
                    return "Diciembre";
            }
            return "";
        }


        public static List<string> SepararCadena(string cadena, string @char)
        {
            var cadenas = new List<string>();
            int Length = cadena.Length;
            while (Length != 0)
            {
                int startIndex = cadena.IndexOf(@char);
                if (startIndex != -1)
                {
                    cadenas.Add(cadena.Substring(0, startIndex));
                    cadena = cadena.Remove(0, startIndex + 1);
                }
                else
                {
                    cadenas.Add(cadena);
                    cadena = "";
                }
                Length = cadena.Length;
            }

            return cadenas;
        }


        public static List<int> SepararCadenaN(string cadena, string @char)
        {
            var numeros = SepararCadena(cadena, @char);
            var listado = new List<int>();

            foreach (var n in numeros)
            {
                listado.Add(tDatos.ToInt(n));
            }

            return listado;
        }

        public static string[] SepararCadenaIzqDer(string valor, string iden)
        {
            var cadenas = new string[2];

            int index = valor.IndexOf(iden);

            if (index != -1)
            {
                cadenas[0] = valor.Remove(0, index + 1);
                cadenas[1] = valor.Remove(index + 1, (valor.Length - index));
            }

            return cadenas;
        }
        //separar cadena string.- buscar iden en la cadena y guardar el valor de la derecha apartir del iden
        public static string SepararCadenastring(string valor, string iden)
        {
            int startIndex = valor.IndexOf(iden);
            if (startIndex != -1)
            {

                valor = valor.Remove(0, startIndex + 1);
            }

            return valor;
        }


    }
}
