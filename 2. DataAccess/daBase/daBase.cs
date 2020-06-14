using DataAccess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Bitacora
/// <summary>
/// Autor: Miguel Ángel Trinidada Cruz
/// Fecha: 13/06/2020
/// Descripcion: Clase de manupulación de procesos internos dentro del sistema 
/// ------------------------------------------------------------------------------------------------------------
/// Feche            Estatus                  UserName                    Descripcion
/// 
/// 
/// </summary>
#endregion Bitacora

public abstract class DaBase<T> : daBaseP<T> where T : new()
{
    #region Constructores
    public DaBase(String proceso, String baseDatos, String area) : base(proceso, baseDatos, area) { }
    #endregion Constructores

    #region Métodos
    #region Métodos Esenciales
    public bool Insert(T objeto)
    {
        var res = Administrar(objeto, cOp.Insert);
        return Errores.validarOperacion(res);
    }
    public bool Update(T objeto)
    {
        var res = Administrar(objeto, cOp.Update);
        return Errores.validarOperacion(res);
    }
    public bool Delete(int id)
    {
        var obj = new T();
        dynamic obj2 = obj;
        obj2.id = id;
        var res = Administrar(obj2, cOp.Delete);
        return Errores.validarOperacion(res);
    }

    /// <summary>
    /// metodo que administra operaciones para manipulacion de datos
    /// </summary>
    /// <param name="objeto">registro a manipular</param>
    /// <param name="Accion">tipo de accion a realizar</param>
    /// <returns></returns>
    abstract protected Object[] Administrar(T objeto, String Accion);
    #endregion Métodos Esenciales   
    #endregion Métodos
}

