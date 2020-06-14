using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Bitacora
/// <summary>
/// Autor: Miguel Ángel Trinidada Cruz
/// Fecha: 13/06/2020
/// Descripcion: Clase para la conexión de SQL 
/// ------------------------------------------------------------------------------------------------------------
/// Feche            Estatus                  UserName                    Descripcion
/// 
/// 
/// </summary>
#endregion Bitacora

namespace DataAccess.Base
{
    public class Conexion 
    {
        public static SqlConnection QTCO()
        {
            return new SqlConnection("Server=DESKTOP-6VEKJHN;initial catalog=MICROREST;integrated security=True;Connect Timeout=150;");
        }

        public static SqlConnection Create(String sistema)
        {
            switch (sistema)
            {
                case "Quantico":
                case "QTCO":
                    return QTCO();
            }
            return null;
        }
    }
}
