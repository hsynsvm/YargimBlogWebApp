using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace YargimBlogWebApp.YoneticiPanel
{
    public partial class Uyeler : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_uyeler.DataSource = vm.TumUyeleriGetir();
            lv_uyeler.DataBind(); 
        }

        protected void lv_uyeler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                vm.UyeSil(id);
            }
            if (e.CommandName == "durum")
            {
                vm.UyeDurumDegistir(id);
            }

            lv_uyeler.DataSource = vm.TumUyeleriGetir();
            lv_uyeler.DataBind();
        }
    }
}