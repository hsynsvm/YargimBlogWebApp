using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class VeriModel
    {
        SqlConnection baglanti; SqlCommand komut;
        public VeriModel()
        {
            baglanti = new SqlConnection(BaglantiYollari.baglantiYolu);
            komut = baglanti.CreateCommand();
        }

        #region Metotlar

        #region Yonetici Metotlari
        public Yonetici YoneticiGiris(string mail, string sifre)
        {
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE Mail = @mail AND Sifre = @sifre";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@mail", mail);
                komut.Parameters.AddWithValue("@sifre", sifre);
                baglanti.Open();

                int sayi = Convert.ToInt32(komut.ExecuteScalar());
                if (sayi == 1)
                {
                    komut.CommandText = "SELECT Y.ID, Y.YoneticiTurID, YT.Isim, Y.Isim, Y.Soyisim, Y.KullaniciAdi, Y.Mail, Y.Sifre, Y.Durum, Y.Silinmis, Y.Foto FROM Yoneticiler AS Y JOIN YoneticiTurleri AS YT ON Y.YoneticiTurID = YT.ID WHERE Y.Mail = @mail AND Y.Sifre = @sifre";
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@mail", mail);
                    komut.Parameters.AddWithValue("@sifre", sifre);
                    SqlDataReader okuyucu = komut.ExecuteReader();
                    Yonetici y = new Yonetici();
                    while (okuyucu.Read())
                    {
                        y.ID = okuyucu.GetInt32(0);
                        y.YoneticiTurID = okuyucu.GetInt32(1);
                        y.YoneticiTur = okuyucu.GetString(2);
                        y.Isim = okuyucu.GetString(3);
                        y.Soyisim = okuyucu.GetString(4);
                        y.KullaniciAdi = okuyucu.GetString(5);
                        y.Mail = okuyucu.GetString(6);
                        y.Sifre = okuyucu.GetString(7);
                        y.Durum = okuyucu.GetBoolean(8);
                        y.Silinmis = okuyucu.GetBoolean(9);
                        if(string.IsNullOrEmpty(okuyucu.GetString(10)))
                        {
                            y.Foto = "none.png";
                        }
                        else
                        {
                            y.Foto = okuyucu.GetString(10);
                        }
                    }
                    return y;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public bool varmi(string kullaniciAdi,string mail,string tablo)
        {
            try
            {
                int mailSayi = 0;
                int kullanici = 0;

                komut.CommandText = "SELECT COUNT(*) FROM @tablo WHERE KullaniciAdi=@kAdi";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@tablo",tablo);
                komut.Parameters.AddWithValue("@kAdi", kullaniciAdi);
                baglanti.Open();
                kullanici = Convert.ToInt32(komut.ExecuteScalar());
                komut.CommandText = "SELECT COUNT(*) FROM @tablo WHERE Mail=@mail";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@tablo", tablo);
                komut.Parameters.AddWithValue("@mail", mail);
                mailSayi = Convert.ToInt32(komut.ExecuteScalar());

                if (kullanici > 0 || mailSayi > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {

                return true;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public void YoneticiEkle(Yonetici y)
        {
            try
            {
                komut.CommandText = "INSERT INTO Yoneticiler(YoneticiTurID,YoneticiTur,Isim,Soyisim,KullaniciAdi,Mail,Sifre,Durum,Silinmis,Foto) VALUES(@yoneticiturid,@yoneticitur,@ısim,@soyisim,@kullaniciadi,@mail,@sifre,@durum,@silinmis,@foto)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@yoneticiturid", y.YoneticiTurID);
                komut.Parameters.AddWithValue("@yoneticitur", y.YoneticiTur);
                komut.Parameters.AddWithValue("@ısim", y.Isim);
                komut.Parameters.AddWithValue("@soyisim", y.Soyisim);
                komut.Parameters.AddWithValue("@kullaniciadi", y.KullaniciAdi);
                komut.Parameters.AddWithValue("@mail", y.Mail);
                komut.Parameters.AddWithValue("@sifre", y.Sifre);
                komut.Parameters.AddWithValue("@durum", y.Durum);
                komut.Parameters.AddWithValue("@silinmis", y.Silinmis);
                komut.Parameters.AddWithValue("@foto", y.Foto);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }
        public List<Yonetici>YoneticiListele()
        {
            List<Yonetici> yoneticiler = new List<Yonetici>();
            try
            {
                komut.CommandText = "SELECT Y.ID,Y.YoneticiTurID,Y.YoneticiTur,Y.KullaniciAdi,Y.Durum,Y.Foto FROM Yoneticiler AS Y";
                komut.Parameters.Clear();
                baglanti.Open() ;
                SqlDataReader okuyucu = komut.ExecuteReader();
                while(okuyucu.Read())
                {
                    Yonetici y = new Yonetici();
                    y.ID = okuyucu.GetInt32(0);
                    y.YoneticiTurID = okuyucu.GetInt32(1);
                    y.YoneticiTur = okuyucu.GetString(2);
                    y.KullaniciAdi = okuyucu.GetString(3);
                    y.Durum = okuyucu.GetBoolean(4);
                    y.Foto = okuyucu.GetString(5);
                }
                return yoneticiler;
            }
            catch 
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public void YetkiOlustur(string yetki)
        {
            try
            {
                komut.CommandText = "INSERT INTO YoneticiTurleri(ID) VALUES(@id)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", yetki);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }
        public List<Yonetici> YetkiListele()
        {
            List<Yonetici> gorevListele = new List<Yonetici>();
            try
            {
                komut.CommandText = "SELECT YoneticiTurID,YoneticiTur, Yonetici FROM Yoneticiler";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Yonetici gorev = new Yonetici();
                    gorev.YoneticiTurID = okuyucu.GetInt32(0);
                    gorev.YoneticiTur = okuyucu.GetString(1);
                    gorevListele.Add(gorev);
                }
                return gorevListele;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public bool YetkiSil(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM Yoneticiler WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                komut.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }
        #endregion

        #region Kategori Metotlari
        public bool KategoriEkle(Kategori kat)
        {
            try
            {
                komut.CommandText = "INSERT INTO Kategoriler(Isim,Aciklama,Durum,Silinmis) VALUES(@isim,@aciklama,@durum,@silinmis)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@isim", kat.Isim);
                komut.Parameters.AddWithValue("@aciklama", kat.Aciklama);
                komut.Parameters.AddWithValue("@durum", kat.Durum);
                komut.Parameters.AddWithValue("@silinmis", kat.Silinmis);
                baglanti.Open();
                komut.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public List<Kategori> KategoriListele()
        {
            List<Kategori> kategoriler = new List<Kategori>();

            try
            {
                komut.CommandText = "SELECT ID, Isim, Aciklama, Durum, Silinmis FROM Kategoriler";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    Kategori kat = new Kategori();
                    kat.ID = reader.GetInt32(0);
                    kat.Isim = reader.GetString(1);
                    kat.Aciklama = reader.GetString(2);
                    kat.Durum = reader.GetBoolean(3);
                    kat.Silinmis = reader.GetBoolean(4);
                    kategoriler.Add(kat);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public List<Kategori> KategoriListele(bool silinmis)
        {
            List<Kategori> kategoriler = new List<Kategori>();

            try
            {
                komut.CommandText = "SELECT ID, Isim, Aciklama, Durum, Silinmis FROM Kategoriler WHERE Silinmis=@silinmis";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@silinmis", silinmis);
                baglanti.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    Kategori kat = new Kategori();
                    kat.ID = reader.GetInt32(0);
                    kat.Isim = reader.GetString(1);
                    kat.Aciklama = reader.GetString(2);
                    kat.Durum = reader.GetBoolean(3);
                    kat.Silinmis = reader.GetBoolean(4);
                    kategoriler.Add(kat);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public List<Kategori> KategoriListele(bool silinmis, bool durum)
        {
            List<Kategori> kategoriler = new List<Kategori>();

            try
            {
                komut.CommandText = "SELECT ID, Isim, Aciklama, Durum, Silinmis FROM Kategoriler WHERE Silinmis=@silinmis AND Durum =@durum";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@silinmis", silinmis);
                komut.Parameters.AddWithValue("@durum", durum);
                baglanti.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    Kategori kat = new Kategori();
                    kat.ID = reader.GetInt32(0);
                    kat.Isim = reader.GetString(1);
                    kat.Aciklama = reader.GetString(2);
                    kat.Durum = reader.GetBoolean(3);
                    kat.Silinmis = reader.GetBoolean(4);
                    kategoriler.Add(kat);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public void KategoriSilHardDelete(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM Kategoriler WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }
        public void KategoriSil(int id)
        {
            try
            {
                komut.CommandText = "UPDATE Kategoriler SET Silinmis = 1 WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }
        public void KategoriDurumDegistir(int id)
        {
            try
            {
                komut.CommandText = "SELECT Durum FROM Kategoriler WHERE ID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                bool durum = Convert.ToBoolean(komut.ExecuteScalar());
                komut.CommandText = "UPDATE Kategoriler SET Durum=@durum WHERE ID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@durum", !durum);
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }
        public Kategori KategoriGetir(int id)
        {
            try
            {
                komut.CommandText = "SELECT ID, Isim, Aciklama, Durum, Silinmis FROM Kategoriler WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                Kategori kat = new Kategori();

                while (okuyucu.Read())
                {
                    kat.ID = okuyucu.GetInt32(0);
                    kat.Isim = okuyucu.GetString(1);
                    kat.Aciklama = okuyucu.GetString(2);
                    kat.Durum = okuyucu.GetBoolean(3);
                    kat.Silinmis = okuyucu.GetBoolean(4);
                }
                return kat;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public bool KategoriGuncelle(Kategori k)
        {
            try
            {
                komut.CommandText = "UPDATE Kategoriler SET Isim=@isim, Aciklama=@aciklama, Durum=@durum WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", k.ID);
                komut.Parameters.AddWithValue("@isim", k.Isim);
                komut.Parameters.AddWithValue("@aciklama", k.Aciklama);
                komut.Parameters.AddWithValue("@durum", k.Durum);
                baglanti.Open();
                komut.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }
        #endregion

        #region Makale Metotlari

        public bool MakaleEkle(Makale mak)
        {
            try
            {
                komut.CommandText = "INSERT INTO Makaleler(KategoriID, YazarID, Baslik, Ozet, Icerik, EklemeTarihi, GoruntulemeSayisi, KapakResim, Durum) VALUES(@kategoriID, @yazarID, @baslik, @ozet, @icerik, @eklemeTarihi, @goruntulemeSayisi, @kapakResim, @durum)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@kategoriID", mak.KategoriID);
                komut.Parameters.AddWithValue("@yazarID", mak.YazarID);
                komut.Parameters.AddWithValue("@baslik", mak.Baslik);
                komut.Parameters.AddWithValue("@ozet", mak.Ozet);
                komut.Parameters.AddWithValue("@icerik", mak.Icerik);
                komut.Parameters.AddWithValue("@eklemeTarihi", mak.EklemeTarihi);
                komut.Parameters.AddWithValue("@goruntulemeSayisi", mak.GoruntulemeSayisi);
                komut.Parameters.AddWithValue("@kapakResim", mak.KapakResim);
                komut.Parameters.AddWithValue("@durum", mak.Durum);
                baglanti.Open();
                komut.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public List<Makale> MakaleListele()
        {
            List<Makale> makaleler = new List<Makale>();
            try
            {
                komut.CommandText = "SELECT M.ID, M.KategoriID, K.Isim, M.YazarID, Y.KullaniciAdi, M.Ozet, M.Icerik, M.Baslik, M.EklemeTarihi, M.GoruntulemeSayisi, M.KapakResim, M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON M.KategoriID = K.ID JOIN Yoneticiler AS Y ON M.YazarID = Y.ID";
                komut.Parameters.Clear();

                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Makale mak = new Makale();
                    mak.ID = okuyucu.GetInt32(0);
                    mak.KategoriID = okuyucu.GetInt32(1);
                    mak.Kategori = okuyucu.GetString(2);
                    mak.YazarID = okuyucu.GetInt32(3);
                    mak.Yazar = okuyucu.GetString(4);
                    mak.Ozet = okuyucu.GetString(5);
                    mak.Icerik = okuyucu.GetString(6);
                    mak.Baslik = okuyucu.GetString(7);
                    mak.EklemeTarihi = okuyucu.GetDateTime(8);
                    mak.GoruntulemeSayisi = okuyucu.GetInt64(9);
                    mak.KapakResim = okuyucu.GetString(10);
                    mak.Durum = okuyucu.GetBoolean(11);
                    makaleler.Add(mak);
                }
                return makaleler;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public List<Makale> MakaleListele(int kid)
        {
            List<Makale> makaleler = new List<Makale>();
            try
            {
                komut.CommandText = "SELECT M.ID, M.KategoriID, K.Isim, M.YazarID, Y.KullaniciAdi, M.Ozet, M.Icerik, M.Baslik, M.EklemeTarihi, M.GoruntulemeSayisi, M.KapakResim, M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON M.KategoriID = K.ID JOIN Yoneticiler AS Y ON M.YazarID = Y.ID WHERE M.KategoriID = @kid";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@kid", kid);

                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Makale mak = new Makale();
                    mak.ID = okuyucu.GetInt32(0);
                    mak.KategoriID = okuyucu.GetInt32(1);
                    mak.Kategori = okuyucu.GetString(2);
                    mak.YazarID = okuyucu.GetInt32(3);
                    mak.Yazar = okuyucu.GetString(4);
                    mak.Ozet = okuyucu.GetString(5);
                    mak.Icerik = okuyucu.GetString(6);
                    mak.Baslik = okuyucu.GetString(7);
                    mak.EklemeTarihi = okuyucu.GetDateTime(8);
                    mak.GoruntulemeSayisi = okuyucu.GetInt64(9);
                    mak.KapakResim = okuyucu.GetString(10);
                    mak.Durum = okuyucu.GetBoolean(11);
                    makaleler.Add(mak);
                }
                return makaleler;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public Makale MakaleGetir(int id)
        {
            try
            {
                komut.CommandText = "SELECT M.ID, M.KategoriID, K.Isim, M.YazarID, Y.KullaniciAdi, M.Ozet, M.Icerik, M.Baslik, M.EklemeTarihi, M.GoruntulemeSayisi, M.KapakResim, M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON M.KategoriID = K.ID JOIN Yoneticiler AS Y ON M.YazarID = Y.ID WHERE M.ID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();

                SqlDataReader okuyucu = komut.ExecuteReader();
                Makale mak = new Makale();
                while (okuyucu.Read())
                {
                    mak.ID = okuyucu.GetInt32(0);
                    mak.KategoriID = okuyucu.GetInt32(1);
                    mak.Kategori = okuyucu.GetString(2);
                    mak.YazarID = okuyucu.GetInt32(3);
                    mak.Yazar = okuyucu.GetString(4);
                    mak.Ozet = okuyucu.GetString(5);
                    mak.Icerik = okuyucu.GetString(6);
                    mak.Baslik = okuyucu.GetString(7);
                    mak.EklemeTarihi = okuyucu.GetDateTime(8);
                    mak.GoruntulemeSayisi = okuyucu.GetInt64(9);
                    mak.KapakResim = okuyucu.GetString(10);
                    mak.Durum = okuyucu.GetBoolean(11);
                }
                return mak;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public bool MakaleDuzenle(Makale mak)
        {
            try
            {
                komut.CommandText = "UPDATE Makaleler SET KategoriID=@kategoriId, Baslik=@baslik, Icerik=@icerik, Ozet=@ozet, KapakResim=@kapakresim, Durum=@durum WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@kategoriId", mak.KategoriID);
                komut.Parameters.AddWithValue("@baslik", mak.Baslik);
                komut.Parameters.AddWithValue("@icerik", mak.Icerik);
                komut.Parameters.AddWithValue("@ozet", mak.Ozet);
                komut.Parameters.AddWithValue("@kapakresim", mak.KapakResim);
                komut.Parameters.AddWithValue("@durum", mak.Durum);
                komut.Parameters.AddWithValue("@id", mak.ID);
                baglanti.Open();
                komut.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public void MakaleSil(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM Yorumlar WHERE MakaleID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                komut.ExecuteNonQuery();
                komut.CommandText = "DELETE FROM Makaleler WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }

        #endregion

        #region Uye Metotlari
        public List<Uye> TumUyeleriGetir()
        {
            List<Uye> uyeler = new List<Uye>();

            try
            {
                komut.CommandText = "SELECT ID,Isim,Soyisim,KullaniciAdi,Mail,Sifre,UyelikTarihi,Durum,Silinmis FROM Uyeler";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Uye u = new Uye();
                    u.ID = okuyucu.GetInt32(0);
                    u.Isim = okuyucu.GetString(1);
                    u.Soyisim = okuyucu.GetString(2);
                    u.KullaniciAdi = okuyucu.GetString(3);
                    u.Mail = okuyucu.GetString(4);
                    u.UyelikTarihi = okuyucu.GetDateTime(5);
                    u.Durum = okuyucu.GetBoolean(6);
                    u.Silinmis = okuyucu.GetBoolean(7);
                    uyeler.Add(u);
                }
                return uyeler;
            }
            catch
            {

                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public Uye UyeGetir(int id)
        {
            try
            {
                komut.CommandText = "SELECT ID,Isim,Soyisim,KullaniciAdi,Mail,UyelikTarihi,Durum FROM Uyeler WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                Uye u = new Uye();
                while (okuyucu.Read())
                {
                    u.ID = okuyucu.GetInt32(0);
                    u.Isim = okuyucu.GetString(1);
                    u.Soyisim = okuyucu.GetString(2);
                    u.KullaniciAdi = okuyucu.GetString(3);
                    u.Mail = okuyucu.GetString(4);
                    u.UyelikTarihi = okuyucu.GetDateTime(5);
                    u.Durum = okuyucu.GetBoolean(6);
                    u.Silinmis = okuyucu.GetBoolean(7);
                }
                return u;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }
        #endregion

        #endregion
    }
}