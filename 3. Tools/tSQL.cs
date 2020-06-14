using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class tSQL
{
    public static string stuff(string sql, string asname)
    {
        return "(STUFF((" + sql + " FOR XML PATH('')), 1, 1, '')) as '" + asname + "'";
    }
}