using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace YargimBlogWebApp
{
    public partial class UyeGiris : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_giris_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_mail.Text))
            {
                if (!tb_mail.Text.Contains("@") || !tb_mail.Text.Contains(".com"))
                {
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Geçersiz e-posta adresi";
                }
                else if (!string.IsNullOrEmpty(tb_sifre.Text))
                {
                    Uye u = vm.UyeGiris(tb_mail.Text, tb_sifre.Text);
                    if (u != null)
                    {
                        if (u.ID != 0)
                        {
                            if (u.Durum)
                            {
                                Session["uye"] = u;
                                Response.Redirect("Default.aspx");
                            }
                            else
                            {
                                pnl_basarisiz.Visible = true;
                                lbl_mesaj.Text = "Hesabınız askıya alınmıştır. Yönetici ile görüşünüz!";
                            }
                        }
                        else
                        {
                            pnl_basarisiz.Visible = true;
                            lbl_mesaj.Text = "Kullanıcı bulunamadı. Bilgileri kontrol ediniz";
                        }
                    }
                    else
                    {
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "Bir hata oluştu lütfen daha sonra deneyiniz";
                    }
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Şifre boş bırakılamaz";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "E-posta boş bırakılamaz";
            }
        }
    }
}