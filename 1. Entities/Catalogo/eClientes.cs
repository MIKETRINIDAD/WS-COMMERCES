using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Catalogo
{
    #region Bitacora
    /// <summary>
    /// Autor: Miguel Ángel Trinidada Cruz
    /// Fecha: 13/06/2020
    /// Descripcion: Clase de propiedades para clientes
    /// ------------------------------------------------------------------------------------------------------------
    /// Feche            Estatus                  UserName                    Descripcion
    /// 
    /// 
    /// </summary>
    #endregion Bitacora

    public class eClientes
    {
        public int IdClente { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int RegBorrado { get; set; }
    }
}
