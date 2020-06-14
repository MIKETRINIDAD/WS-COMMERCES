using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Base
{
    #region Bitacora
    /// <summary>
    /// Autor: Miguel Ángel Trinidada Cruz
    /// Fecha: 13/06/2020
    /// Descripcion: Clase de propiedades para bases
    /// ------------------------------------------------------------------------------------------------------------
    /// Feche            Estatus                  UserName                    Descripcion
    /// 
    /// 
    /// </summary>
    #endregion Bitacora
    public abstract class eBase
    {
        #region Propiedades
        [Required]
        public int id { get; set; }
        [Required]
        public int usuarioId { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public int RegBorrado { get; set; }
        #endregion Propiedades

        #region Constructores
        public eBase(int Id)
        {
            id = Id;
        }
        public eBase() { }
        #endregion Constructores
    }
}
