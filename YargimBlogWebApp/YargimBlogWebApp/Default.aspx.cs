using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace YargimBlogWebApp
{
    public partial class Default : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count == 0)
                {
                    List<Makale> makaleler = vm.MakaleListele();
                    makaleler.Reverse();
                    lv_makaleler.DataSource = makaleler;
                    lv_makaleler.DataBind();
                    pnlDataPager.Visible = lv_makaleler.Items.Count > 0;
                }
                else
                {
                    int katid = Convert.ToInt32(Request.QueryString["kategoriID"]);
                    List<Makale> makaleler = vm.MakaleListele(katid);
                    makaleler.Reverse();
                    lv_makaleler.DataSource = makaleler;
                    lv_makaleler.DataBind();
                    pnlDataPager.Visible = lv_makaleler.Items.Count > 0;
                }
            }
        }
        protected void lv_makaleler_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            if (Request.QueryString.Count == 0)
            {
                List<Makale> makaleler = vm.MakaleListele();
                makaleler.Reverse();
                lv_makaleler.DataSource = makaleler;
                lv_makaleler.DataBind();
            }
            else
            {
                int katid = Convert.ToInt32(Request.QueryString["kategoriID"]);
                List<Makale> makaleler = vm.MakaleListele(katid);
                makaleler.Reverse();
                lv_makaleler.DataSource = makaleler;
                lv_makaleler.DataBind();
            }
        }
    }
}