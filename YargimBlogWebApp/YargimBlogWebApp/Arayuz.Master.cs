using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace YargimBlogWebApp
{
    public partial class Arayuz : System.Web.UI.MasterPage
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uye"] != null)
            {
                Uye u = Session["uye"] as Uye;
                pnl_girisvar.Visible = true;
                pnl_girisyok.Visible = false;
                ltrl_uye.Text = u.KullaniciAdi;
            }
            else
            {
                pnl_girisvar.Visible = false;
                pnl_girisyok.Visible = true;
            }
           

        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["uye"] = null;
            Response.Redirect("Default.aspx");
        }

        
    }
}