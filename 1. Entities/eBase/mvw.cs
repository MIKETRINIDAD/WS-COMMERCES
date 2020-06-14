using System;
using System.Collections.Generic;
#region Bitacora
/// <summary>
/// Autor: Miguel Ángel Trinidada Cruz
/// Fecha: 13/06/2020
/// Descripcion: Clase de propiedades para movimientos y procesos internos dentro del sistema errores
/// ------------------------------------------------------------------------------------------------------------
/// Feche            Estatus                  UserName                    Descripcion
/// 
/// 
/// </summary>
#endregion Bitacora

#region Base
public abstract class mvwBase
{
    public mvwMsjs mensajes { get; set; }

    public mvwBase()
    {
        mensajes = new mvwMsjs();
    }
}
#endregion Base

#region Mensajes
public class mvwMsjs
{
    public List<String> avisos { get; set; }
    public List<String> errores { get; set; }
    public Boolean cerrar { get; set; }
    public String alert { get; set; }
    public String script { get; set; }

    public mvwMsjs(List<String> avisos, List<String> errores)
    {
        this.avisos = avisos;
        this.errores = errores;
    }
    public mvwMsjs()
    {
        avisos = new List<String>();
        errores = new List<String>();
    }
}
#endregion Mensajes

#region Errores
public class mvwError : mvwBase
{
    public List<Exception> excepciones { get; set; }
    public string en { get; set; }
    public string en2 { get; set; }
    public string desde { get; set; }
    public mvwError()
    {
        excepciones = new List<Exception>();
    }
}
#endregion Errores