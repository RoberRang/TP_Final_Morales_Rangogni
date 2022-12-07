using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final_Morales_Rangogni
{
    public partial class ErrorWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MensajeError"] != null)
                lblMensajeError.Text = Session["MensajeError"].ToString();
        }

        protected void lbtnDefaultLogin_Click(object sender, EventArgs e)
        {
            if (Session["EmpleadoLogin"] == null)
                Response.Redirect("Default.aspx", false);
            else
                Response.Redirect("SiteDefaultWeb.aspx", false);

        }
    }
}