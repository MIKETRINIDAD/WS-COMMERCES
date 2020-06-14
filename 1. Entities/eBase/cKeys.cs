using System;

#region Bitacora
/// <summary>
/// Autor: Miguel Ángel Trinidada Cruz
/// Fecha: 13/06/2020
/// Descripcion: Clase de propiedades para movimientos y procesos internos dentro del sistema 
/// ------------------------------------------------------------------------------------------------------------
/// Feche            Estatus                  UserName                    Descripcion
/// 
/// 
/// </summary>
#endregion Bitacora

public static class cConString
{
    public static string QTCO { get { return "QTCO"; } }
}
public static class cSystem
{
    public static string Quantico { get { return "Quantico"; } }
}

public static class cBd
{
    public static string SIAP => "SIAP";
    public static string SIAPRH => "SIAPRH";
    public static string SAPYN => "SAPYN";
    public static string IMSS => "IMSS";
    public static string NOM => "Nóminas";
    public static string NOMSA => "Nominas";
    public static string RECO => "RECO";
    public static string FACT => "Facturación";
    public static string QTCO => "QTCO";
    public static string user => "publicador";
    public static string password => "publ/2017**";
}

public static class cPlz
{
    public static String VHT { get { return "Villahermosa"; } }
    public static String MEY { get { return "Mérida"; } }
    public static String CME { get { return "Ciudad del Carmen"; } }
}



public static class cOp
{
    public static string Insert { get { return "Insertar"; } }
    public static string Update { get { return "Actualizar"; } }
    public static string Delete { get { return "Eliminar"; } }
}
public static class cPms
{
    public static String Raiz { get { return "RARCH"; } }
    public static String ClaveP { get { return "PLAZACLAVE"; } }
    public static String NameP { get { return "PLAZANAME"; } }
}
public static class cAreas
{
    public static string Cats { get { return "Catálogos"; } }
    public static string Seg { get { return "Seguridad"; } }
    public static string Error { get { return "Errores"; } }
    public static string Utls { get { return "Utilerías"; } }
    public static string Html { get { return "Html"; } }
    public static string SQL { get { return "SQL"; } }
    public static string Users { get { return "Usuarios"; } }
    public static string Roles { get { return "Roles"; } }
    public static string Permisos { get { return "Permisos"; } }
    public static string Parametros { get { return "Parametros"; } }
    public static string ProyectosDepartamentos { get { return "ProyectosDepartamentos"; } }
    public static string Proyectos { get { return "Proyectos"; } }
    public static string Plazas { get { return "Plazas"; } }
    public static string Clientes { get { return "Clientes"; } }
    public static string PeriodosNominas { get { return "Periodos Nominas"; } }
    public static string DetalleTimbrado { get { return "DetalleTimbrado"; } }
    public static string Personas { get { return "Personas"; } }
    public static string PersonasEmpleados { get { return "PersonasEmpleados"; } }
    public static string DetallesNominas { get { return "DetallesNominas"; } }
}
