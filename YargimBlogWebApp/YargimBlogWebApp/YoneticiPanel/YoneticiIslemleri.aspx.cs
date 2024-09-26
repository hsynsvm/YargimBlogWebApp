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
            lv_kullanicilar.DataSource = vm.TumYoneticileriGetir();
            lv_kullanicilar.DataBind();
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_isim.Text) ||
              string.IsNullOrEmpty(tb_soyisim.Text) ||
              string.IsNullOrEmpty(tb_kullaniciadi.Text) ||
              string.IsNullOrEmpty(tb_mail.Text) ||
              string.IsNullOrEmpty(tb_sifre.Text))
            {
                pnl_basarisiz.Visible = true;
                lbl_hatamesaj.Text = "Lütfen tüm alanları doldurunuz!";
            }
            else
            {
                try
                {
                    int yoneticiTurID = Convert.ToInt32(rb_YoneticiTur_ID.SelectedValue);
                    string isim = tb_isim.Text;
                    string soyisim = tb_soyisim.Text;
                    string kullaniciAdi = tb_kullaniciadi.Text;
                    string email = tb_mail.Text;
                    string sifre = tb_sifre.Text;
                    bool durum = cb_durum.Checked;

                    Yonetici yonetici = new Yonetici()
                    {
                        YoneticiTurID = yoneticiTurID,
                        Isim = isim,
                        Soyisim = soyisim,
                        KullaniciAdi = kullaniciAdi,
                        Mail = email,
                        Sifre = sifre,
                        Durum = durum
                    };

                    if (vm.YoneticiEkle(yonetici))
                    {
                        pnl_basarisiz.Visible = false;
                        pnl_basarili.Visible = true;
                    }
                    else
                    {
                        pnl_basarisiz.Visible = true;
                        lbl_hatamesaj.Text = "Yönetici ekleme işlemi başarısız!";
                    }
                }
                catch (Exception ex)
                {
                    pnl_basarisiz.Visible = true;
                    lbl_hatamesaj.Text = "Bir hata oluştu: " + ex.Message;
                }
            }
        }

        protected void lv_kullanicilar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                vm.YoneticiSil(id);
            }
            if (e.CommandName == "durum")
            {
                vm.YoneticiDurumDegistir(id);
            }

            lv_kullanicilar.DataSource = vm.TumYoneticileriGetir();
            lv_kullanicilar.DataBind();
        }

        protected void lbtn_profil_Click(object sender, EventArgs e)
        {
            string mail = tb_email.Text;
            string yeniSifre = tb_sifre.Text;
            string isim = tb_isim.Text;
            string soyisim = tb_soyisim.Text;
            string kullaniciAdi = tb_kullaniciadi.Text;

            if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(yeniSifre) || string.IsNullOrEmpty(isim) || string.IsNullOrEmpty(soyisim) || string.IsNullOrEmpty(kullaniciAdi))
            {
                pnl_basarisiz.Visible = true;
                lbl_hatamesaj.Text = "Lütfen tüm alanları doldurun!";
                return;
            }

            Yonetici yonetici = Session["yonetici"] as Yonetici;
            if (yonetici != null)
            {
                if (vm.YoneticiProfilGuncelle(yonetici.ID, isim, soyisim, kullaniciAdi, mail, yeniSifre))
                {
                    pnl_basarili.Visible = true;
                    lbl_hatamesaj.Text = "Profil başarıyla güncellenmiştir";
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    lbl_hatamesaj.Text = "Profil güncelleme işlemi başarısız!";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                lbl_hatamesaj.Text = "Geçersiz mail adresi!";
            }
        }
    }

        
}