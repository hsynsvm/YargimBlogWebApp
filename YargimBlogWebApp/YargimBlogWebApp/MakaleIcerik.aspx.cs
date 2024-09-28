using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace YargimBlogWebApp
{
    public partial class MakaleIcerik : System.Web.UI.Page
    {
        VeriModel vm = new VeriModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["MakaleID"]);
                Makale m = vm.MakaleGetir(id);
                ltrl_baslik.Text = m.Baslik;
                ltrl_Icerik.Text = m.Icerik;
                ltrl_kategori.Text = m.Kategori;
                ltrl_Yazar.Text = m.Yazar;
                img_resim.ImageUrl = "Resimler/MakaleResimleri/" + m.KapakResim;

                rp_yorumlar.DataSource = vm.YorumlariGetir(id);
                rp_yorumlar.DataBind();

                if (Session["uye"] != null)
                {
                    pnl_girisvar.Visible = true;
                    pnl_girisYok.Visible = false;
                }
                else
                {
                    pnl_girisvar.Visible = false;
                    pnl_girisYok.Visible = true;
                }

            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (Session["uye"] != null)
            {
                try
                {
                    int makaleID = Convert.ToInt32(Request.QueryString["MakaleID"]);
                    Uye u = Session["uye"] as Uye;
                    if (u != null)
                    {
                        int uyeID = u.ID;
                        string icerik = tb_yorum.Text;

                        Yorum yeniYorum = new Yorum();
                        yeniYorum.MakaleID = makaleID;
                        yeniYorum.UyeID = uyeID;
                        yeniYorum.Icerik = icerik;
                        yeniYorum.EklemeTarihi = DateTime.Now;
                        yeniYorum.Durum = true;

                        string uyeIsim = u.Isim + " " + u.Soyisim;
                        yeniYorum.UyeIsim = uyeIsim;

                        VeriModel db = new VeriModel();
                        bool eklemeBasarili = db.YorumEkle(yeniYorum);

                        if (eklemeBasarili)
                        {
                            Response.Redirect(Request.RawUrl);
                        }
                        else
                        {
                            pnl_basarisiz.Visible = true;
                            lbl_hatamesaj.Text = "Yorum eklenirken bir hata oluştu. Lütfen tekrar deneyin.";
                        }
                    }
                    else
                    {
                        pnl_basarisiz.Visible = true;
                        lbl_hatamesaj.Text = "Kullanıcı bilgileri alınamadı.";
                    }
                }
                catch (Exception ex)
                {
                    pnl_basarisiz.Visible = true;
                    lbl_hatamesaj.Text = "Bir hata oluştu: " + ex.Message;
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                lbl_hatamesaj.Text = "Yorum yapabilmek için giriş yapmalısınız.";
            }
        }
    }
}