using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TP_Final_Morales_Rangogni.Dominio
{
    static public class ConexionStringDB
    {
        //Modificar el valor con el name del atributo de conectionstring del web.config
        private const string NOMBRE_CONFIG_DB = "ClinicaDB_RR2";
        static public string ConexionBase()
        {
            return ConfigurationManager.ConnectionStrings[NOMBRE_CONFIG_DB].ToString();
        }
    }
}