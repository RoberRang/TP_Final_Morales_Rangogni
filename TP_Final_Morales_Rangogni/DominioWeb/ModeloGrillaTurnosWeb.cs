using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TP_Final_Morales_Rangogni.DominioWeb
{
    public class ModeloGrillaTurnosWeb
    {
        private List<ModeloTurnoWeb> modeloTurnos;

        public ModeloGrillaTurnosWeb()
        {
            modeloTurnos = new List<ModeloTurnoWeb>();
        }
        public List<ModeloTurnoWeb> ObtenerListaTurnosWebDataTable(DataTable dtTurnosWeb)
        {
            ModeloTurnoWeb modeloTurnoWeb = null;
            try
            {
                foreach (DataRow drTW in dtTurnosWeb.Rows)
                {
                    modeloTurnoWeb = new ModeloTurnoWeb();
                    foreach (var objTurno in modeloTurnoWeb.GetType().GetProperties())
                    {
                        Object objVal = drTW[objTurno.Name];
                        objTurno.SetValue(modeloTurnoWeb, objVal);
                        
                    }
                    modeloTurnos.Add(modeloTurnoWeb);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return modeloTurnos;
        }
    }
}