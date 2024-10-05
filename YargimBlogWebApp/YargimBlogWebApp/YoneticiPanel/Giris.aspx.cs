using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace YargimBlogWebApp.YoneticiPanel
{
    public partial class Giris : System.Web.UI.Page
    {
        VeriModel veriModel = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_girisYap_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_mail.Text))
            {
                if (!string.IsNullOrEmpty(tb_sifre.Text))
                {
                    Yonetici yonetici = veriModel.YoneticiGiris(tb_mail.Text,tb_sifre.Text);
                    if (yonetici != null)
                    {
                        if (yonetici.ID != 0)
                        {
                            if (yonetici.Durum)
                            {
                                Session["GirisYapanYonetici"] = yonetici;
                                Response.Redirect("YoneticiDefault.aspx");
                            }
                           
                        }
                        else
                        {
                            pnl_basarisiz.Visible = true;
                            lbl_mesaj.Text = "Kullanıcı Bulunamadı!";
                        }
                    }
                    else
                    {
                        pnl_basarisiz.Visible=true;
                        lbl_mesaj.Text = "Şifrenizi veya Kullanıcı Adınızı yanlış girdiniz!";
                    }
                }
                else
                {
                    pnl_basarisiz.Visible=true;
                    lbl_mesaj.Text = "Şifre alanı boş bırakılamaz!";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Mail adresi boş bırakılamaz!";
            }
        }
    }
}