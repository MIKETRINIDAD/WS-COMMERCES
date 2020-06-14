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
    /// Descripcion: Clase de propiedades para usuarios
    /// ------------------------------------------------------------------------------------------------------------
    /// Feche            Estatus                  UserName                    Descripcion
    /// 
    /// 
    /// </summary>
    #endregion Bitacora

    public class eUsuarios : eBase
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public int IdRol { get; set; }
        public bool Activo { get; set; }
    }
}
