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
                    lv_makaleler1.DataSource = makaleler;
                    lv_makaleler1.DataBind();
                    
                }
                else
                {
                    int katid = Convert.ToInt32(Request.QueryString["kategoriID"]);
                    List<Makale> makaleler = vm.MakaleListele(katid);
                    makaleler.Reverse();
                    lv_makaleler1.DataSource = makaleler;
                    lv_makaleler1.DataBind();
                    
                }
            }
            if (Request.QueryString.Count == 0)
            {
                lv_makaleler1.DataSource = vm.MakaleListele();
                lv_makaleler1.DataBind();
            }
            else
            {
                int kid = Convert.ToInt32(Request.QueryString["kid"]);
                lv_makaleler1.DataSource = vm.MakaleListele(kid);
                lv_makaleler1.DataBind();
            }
        }
        
        
    }
}