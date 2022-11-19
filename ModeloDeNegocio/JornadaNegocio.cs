using AccesoModeloBaseDatos.Dominio;
using AccesoModeloBaseDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeNegocio
{
    public class JornadaNegocio:Jornada
    {
        private readonly JornadaADO jornadaADO;
        public JornadaNegocio()
        {
            jornadaADO = new JornadaADO(ConexionStringDB.ConexionBase());
        }
        public bool AltaJornada(string descripcion, bool estado, int inicio, int fin)
        {
            try
            {
                this.IdJornada = 0;
                this.Descripcion = descripcion;
                this.Estado = estado;
                this.Inicio = inicio;
                this.Fin = fin;

                return jornadaADO.GrabarJornada(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Jornada> ListarJornadas()
        {
            return jornadaADO.ListarJornadas();
        }
        public bool ModificarJornada(int id, string descripcion, bool estado, int inicio, int fin)
        {
            try
            {
                this.IdJornada = id;
                this.Descripcion = descripcion;
                this.Estado = estado;
                this.Inicio = inicio;
                this.Fin = fin;

                return jornadaADO.GrabarJornada(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
