using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data.Sql;

namespace Control_para_consultorio_medico
{
    class ConexionDB
    {

        public string cadenaconexion()
        {
            string StrCnnString = @"Data Source = JUANURRUTIA-PC; Initial Catalog = consultorio; Integrated Security = true";
            return StrCnnString;
        }
    }
}
