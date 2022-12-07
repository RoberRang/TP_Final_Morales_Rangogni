using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeNegocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService(string dominio, string usuario, string password)
        {
            server = new SmtpClient();

            server.Port = 587;
            server.Host = dominio; //smtp.live.com
            server.UseDefaultCredentials = false;
            server.Credentials = new NetworkCredential(usuario, password);  
            server.EnableSsl = true;

        }
        private void ArmarCorreo(string emailDestino, string nombrePaciente, string fechaTurno, string nombreMedico, string apellidoMedico, string horaTurno)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@clinicamora.com");
            email.To.Add(emailDestino);
            email.Subject = "<h3>Turno confirmado Clinica Mora<h3>";
            email.IsBodyHtml = true;
            email.Body = "<h3>Confimacion de Turno Clinica Mora<h3> <br>" +
                "Hola " + nombrePaciente + "como estas,<br>" +
                " Queriamos recordarte que el dia" + fechaTurno + ", tenes una visita con el Dr. " + nombreMedico + " " + apellidoMedico + " a " +
                "las" + horaTurno + ".<br>Por favor cualquier duda o cambio avisanos para poder reprogramarlo. <br>Saludos, <br>Administracion Clinica Mora <br> 0800-333-MORA";
        }

        public bool EnviarEmail(string emailDestino, string nombrePaciente, string fechaTurno, string nombreMedico, string apellidoMedico, string horaTurno)
        {
            bool envio = false;
            try
            {
                ArmarCorreo(emailDestino, nombrePaciente, fechaTurno, nombreMedico, apellidoMedico, horaTurno);
                server.Send(email);
                return envio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
