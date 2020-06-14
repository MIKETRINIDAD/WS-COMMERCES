using Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Seguridad
{
    #region Bitacora
    /// <summary>
    /// Autor: Miguel Ángel Trinidada Cruz
    /// Fecha: 13/06/2020
    /// Descripcion: Clase de propiedades para roles
    /// ------------------------------------------------------------------------------------------------------------
    /// Feche            Estatus                  UserName                    Descripcion
    /// 
    /// 
    /// </summary>
    #endregion Bitacora

    public class eRoles : eBase
    {
        public int IdRoles { get; set; }
        public string Nombre { get; set; }
    }
}
