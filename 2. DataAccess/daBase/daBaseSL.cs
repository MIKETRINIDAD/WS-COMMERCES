using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Base
{
    #region Bitacora
    /// <summary>
    /// Autor: Miguel Ángel Trinidada Cruz
    /// Fecha: 13/06/2020
    /// Descripcion: Clase del constructor 
    /// ------------------------------------------------------------------------------------------------------------
    /// Feche            Estatus                  UserName                    Descripcion
    /// 
    /// 
    /// </summary>
    #endregion Bitacora
    public abstract class DaBaseSL<U> : daBaseP<U> where U : new()
    {
        #region Constructores
        public DaBaseSL(String proceso, String baseDatos, String area) : base(proceso, baseDatos, area) { }
        #endregion Constructores

        #region Métodos

        #endregion Métodos
    }
}
