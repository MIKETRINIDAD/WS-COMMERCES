using System;
using System.Collections.Generic;
using System.Text;

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
public class eLog
{
    public string Valor { get; set; }

    public eLog(string valor1)
    {
        this.Valor = valor1;
    }
    public eLog() { }
}

[Serializable]
public class eLog2
{
    public string Valor1 { get; set; }
    public string Valor2 { get; set; }

    public eLog2(string valor1, string valor2)
    {
        this.Valor1 = valor1;
        this.Valor2 = valor2;
    }
    public eLog2() { }
}

[Serializable]
public class eLog3
{
    public string Valor1 { get; set; }
    public string Valor2 { get; set; }
    public string Valor3 { get; set; }

    public eLog3(decimal valor1, string valor2, string valor3)
    {
        Inicializar(valor1, valor2, valor3);
    }
    public eLog3(string valor1, string valor2, string valor3)
    {
        Inicializar(valor1, valor2, valor3);
    }
    private void Inicializar<T, U, V>(T valor1, U valor2, V valor3)
    {
        try
        {
            this.Valor1 = valor1.ToString();
        }
        catch { }
        try
        {
            this.Valor2 = valor2.ToString();
        }
        catch { }
        try
        {
            this.Valor3 = valor3.ToString();
        }
        catch { }
    }
    public eLog3() { }
}

