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
    }

        
}