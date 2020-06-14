using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Entities.Catalogo
{
    #region Bitacora
    /// <summary>
    /// Autor: Miguel Ángel Trinidada Cruz
    /// Fecha: 13/06/2020
    /// Descripcion: Clase de propiedades para proveedores
    /// ------------------------------------------------------------------------------------------------------------
    /// Feche            Estatus                  UserName                    Descripcion
    /// 
    /// 
    /// </summary>
    #endregion Bitacora

    public class eProveedores
    {
        public int IdProveedor { get; set; }
        public string Empresa { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int RegBorrado { get; set; }
    }
}
