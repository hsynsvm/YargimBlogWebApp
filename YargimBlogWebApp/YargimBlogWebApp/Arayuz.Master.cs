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
            rp_kategoriler.DataSource = vm.KategoriListele(false, true);
            rp_kategoriler.DataBind();
            rp_kategoriler.DataSource = vm.TumKategorileriGetir(true);
            rp_kategoriler.DataBind();

        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["uye"] = null;
            Response.Redirect("Default.aspx");
        }

        
    }
}