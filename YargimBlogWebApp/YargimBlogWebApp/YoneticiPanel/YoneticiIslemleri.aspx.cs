using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace YargimBlogWebApp.YoneticiPanel
{
    public partial class YoneticiIslemleri : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            Yonetici y = (Yonetici)Session["Yonetici"];
            if (y != null)
            {
                if (y.YoneticiTur == "Admin")
                {
                    yetkili.Visible = true;
                    yetkisiz.Visible = false;
                }
            }

            lv_yetki.DataSource = vm.YetkiListele();
            lv_yetki.DataBind();

            ddl_yetki.DataSource = vm.YetkiListele();
            ddl_yetki.DataBind();
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!(vm.varmi(tb_kullaniciAdi.Text, tb_mail.Text, "Yoneticiler")))
            {
                if (!string.IsNullOrEmpty(tb_kullaniciAdi.Text))
                {
                    if (!string.IsNullOrEmpty(tb_ad.Text))
                    {
                        if (!string.IsNullOrEmpty(tb_soyad.Text))
                        {
                            if (!string.IsNullOrEmpty(tb_kullaniciAdi.Text))
                            {
                                if (!string.IsNullOrEmpty(tb_mail.Text))
                                {
                                    if (!string.IsNullOrEmpty(tb_sifre.Text))
                                    {
                                        Yonetici y = new Yonetici();

                                    }
                                    else
                                    {
                                        pnl_basarisiz.Visible = true;
                                        lbl_bilgi.Text = "Lütfen bir şifre giriniz.";
                                    }
                                }
                                else
                                {
                                    pnl_basarisiz.Visible = true;
                                    lbl_bilgi.Text = "Lütfen bir mail adresi giriniz.";
                                }
                            }
                            else
                            {
                                pnl_basarisiz.Visible = true;
                                lbl_bilgi.Text = "Lütfen bir kullanıcı adı giriniz.";
                            }
                        }
                        else
                        {
                            pnl_basarisiz.Visible = true;
                            lbl_bilgi.Text = "Lütfen soyadınızı giriniz.";
                        }
                    }
                    else
                    {
                        pnl_basarisiz.Visible = true;
                        lbl_bilgi.Text = "Lütfen adınızı giriniz.";
                    }
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    lbl_bilgi.Text = "Lütfen bir kullanıcı adı giriniz.";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                lbl_bilgi.Text = "Böyle bir yönetici zaten var.";
            }
        }

        protected void lbtn_yetkiEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_yetkiAdi.Text))
            {
                vm.YetkiOlustur(tb_yetkiAdi.Text);
                ddl_yetki.DataSource = vm.YetkiListele();
                ddl_yetki.DataBind();
                tb_yetkiAdi.Text = "";
            }
        }

        protected void lv_yetki_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }
    }
}