using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace YargimBlogWebApp.UyePanel
{
    public partial class Profil : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Uye uye = Session["uye"] as Uye;
                if (uye != null)
                {
                    tb_kullaniciadi.Text = uye.KullaniciAdi;
                    tb_isim.Text = uye.Isim;
                    tb_soyisim.Text = uye.Soyisim;
                    tb_email.Text = uye.Mail;
                    cb_durum.Checked = uye.Durum;
                }
            }
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            string email = tb_email.Text;
            string yeniSifre = tb_sifre.Text;
            string isim = tb_isim.Text;
            string soyisim = tb_soyisim.Text;
            string kullaniciAdi = tb_kullaniciadi.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(yeniSifre) || string.IsNullOrEmpty(isim) || string.IsNullOrEmpty(soyisim) || string.IsNullOrEmpty(kullaniciAdi))
            {
                pnl_basarisiz.Visible = true;
                lbl_hatamesaj.Text = "Lütfen tüm alanları doldurun!";
                return;
            }

            Uye uye = Session["uye"] as Uye;
            if (uye != null)
            {
                if (vm.UyeProfilGuncelle(uye.ID, isim, soyisim, kullaniciAdi, email, yeniSifre))
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
                lbl_hatamesaj.Text = "Geçersiz email adresi!";
            }
        }
    }
}