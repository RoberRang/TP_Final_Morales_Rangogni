using AccesoModeloBaseDatos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccesoModeloBaseDatos
{
    public partial class Acceso : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["UserSessionId"] = null;
            }
        }

        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {            
            bool auth = Membership.ValidateUser(UserAccess.UserName, UserAccess.Password);
            
            //if (auth)
            //{
            //    Usuario obj = UsuarioLN.getInstance().AccesoSistema(UserAccess.UserName, UserAccess.Password);
            //    if (obj != null)
            //    {
            //        UserSession _SessionManager = new UserSession(Session);
            //        //SessionManager.UserSessionId = objEmpleado.ID.ToString();
            //        _SessionManager.UserSessionEmpleado = obj;
            //        FormsAuthentication.RedirectFromLoginPage(UserAccess.UserName, false);
            //    }
            //    else
            //    {
            //        Response.Write("<script>alert('USUARIO INCORRECTO.')</script>");
            //    }
            //}
            //else
            //{
            //    Response.Write("<script>alert('DATOS INCORRECTOS')</script>");
            
        }
    }
}