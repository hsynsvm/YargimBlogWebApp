using System;
using System.Collections.Generic;
using System.Data;
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
                        if (string.IsNullOrEmpty(okuyucu.GetString(10)))
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
        public int YoneticiSayisiGetir()
        {
            SqlCommand komut = new SqlCommand();
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Yoneticiler";
                komut.Parameters.Clear();
                komut.Connection = baglanti;
                baglanti.Open();
                return (int)komut.ExecuteScalar();
            }
            catch
            {
                return -1;
            }
            finally
            {
                if (baglanti.State != ConnectionState.Closed)
                    baglanti.Close();
            }
        }
        public int MakaleSayisiGetir()
        {
            SqlCommand komut = new SqlCommand();
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Makaleler";
                komut.Parameters.Clear();
                komut.Connection = baglanti;
                baglanti.Open();
                return (int)komut.ExecuteScalar();
            }
            catch
            {
                return -1;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public int UyeSayisiGetir()
        {
            SqlCommand komut = new SqlCommand();
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Uyeler";
                komut.Parameters.Clear();
                komut.Connection = baglanti;
                baglanti.Open();
                return (int)komut.ExecuteScalar();
            }
            catch
            {
                return -1;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public int YorumSayisiGetir()
        {
            SqlCommand komut = new SqlCommand();
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Yorumlar";
                komut.Parameters.Clear();
                komut.Connection = baglanti;
                baglanti.Open();
                return (int)komut.ExecuteScalar();
            }
            catch
            {
                return -1;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public List<Yonetici> TumYoneticileriGetir()
        {
            List<Yonetici> yoneticiler = new List<Yonetici>();

            try
            {
                komut.CommandText = "SELECT ID, YoneticiTurID, Isim, Soyisim, KullaniciAdi, Mail, Sifre, Durum FROM Yoneticiler";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Yonetici yonetici = new Yonetici();
                    yonetici.ID = okuyucu.GetInt32(0);
                    yonetici.YoneticiTurID = okuyucu.GetInt32(1);
                    yonetici.Isim = okuyucu.GetString(2);
                    yonetici.Soyisim = okuyucu.GetString(3);
                    yonetici.KullaniciAdi = okuyucu.GetString(4);
                    yonetici.Mail = okuyucu.GetString(5);
                    yonetici.Sifre = okuyucu.GetString(6);
                    yonetici.Durum = okuyucu.GetBoolean(7);
                    yoneticiler.Add(yonetici);
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
        public void YoneticiSil(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM Yoneticiler WHERE ID=@id";
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
        public void YoneticiDurumDegistir(int id)
        {
            try
            {
                komut.CommandText = "SELECT Durum FROM Yoneticiler WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                bool durum = Convert.ToBoolean(komut.ExecuteScalar());

                komut.CommandText = "UPDATE Yoneticiler SET Durum=@durum WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                komut.Parameters.AddWithValue("@durum", !durum);
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }
        public bool YoneticiEkle(Yonetici yonetici)
        {
            try
            {
                komut.CommandText = "INSERT INTO Yoneticiler(YoneticiTurID, Isim, Soyisim, KullaniciAdi, Mail, Sifre, Durum) VALUES(@yoneticiTurID, @isim, @soyisim, @kullaniciAdi, @mail, @sifre, @durum)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@yoneticiTurID", yonetici.YoneticiTurID);
                komut.Parameters.AddWithValue("@isim", yonetici.Isim);
                komut.Parameters.AddWithValue("@soyisim", yonetici.Soyisim);
                komut.Parameters.AddWithValue("@kullaniciAdi", yonetici.KullaniciAdi);
                komut.Parameters.AddWithValue("@mail", yonetici.Mail);
                komut.Parameters.AddWithValue("@sifre", yonetici.Sifre);
                komut.Parameters.AddWithValue("@durum", yonetici.Durum);
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
        public Yonetici YoneticiBilgisiGetir(int yoneticiID)
        {
            try
            {
                komut.CommandText = "SELECT ID, Isim, Soyisim, KullaniciAdi, Mail, Durum, Sifre FROM Yoneticiler WHERE ID = @yoneticiID";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@yoneticiID", yoneticiID);

                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                Yonetici yonetici = null;
                if (okuyucu.Read())
                {
                    yonetici = new Yonetici();
                    yonetici.ID = okuyucu.GetInt32(0);
                    yonetici.Isim = okuyucu.GetString(1);
                    yonetici.Soyisim = okuyucu.GetString(2);
                    yonetici.KullaniciAdi = okuyucu.GetString(3);
                    yonetici.Mail = okuyucu.GetString(4);
                    yonetici.Durum = okuyucu.GetBoolean(5);
                    yonetici.Sifre = okuyucu.GetString(6);
                }
                return yonetici;
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
        public bool YoneticiProfilGuncelle(int yoneticiID, string isim, string soyisim, string kullaniciAdi, string mail, string yeniSifre)
        {
            try
            {
                Yonetici yonetici = YoneticiBilgisiGetir(yoneticiID);
                if (yonetici == null)
                    return false;

                komut.CommandText = "UPDATE Yoneticiler SET Isim = @isim, Soyisim = @soyisim, KullaniciAdi = @kullaniciAdi, Mail = @mail, Sifre = @yeniSifre WHERE ID = @yoneticiID";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@isim", isim);
                komut.Parameters.AddWithValue("@soyisim", soyisim);
                komut.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                komut.Parameters.AddWithValue("@mail", mail);
                komut.Parameters.AddWithValue("@yeniSifre", yeniSifre);
                komut.Parameters.AddWithValue("@yoneticiID", yoneticiID);

                baglanti.Open();
                int etkilenenSatirSayisi = komut.ExecuteNonQuery();

                if (etkilenenSatirSayisi == 0)
                    return false;

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
        public List<Kategori> TumKategorileriGetir(bool durum)
        {
            List<Kategori> kategoriler = new List<Kategori>();

            try
            {
                komut.CommandText = "SELECT ID, Isim, Aciklama, Durum FROM Kategoriler WHERE Durum=@d";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@d", durum);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Kategori kat = new Kategori();
                    kat.ID = okuyucu.GetInt32(0);
                    kat.Isim = okuyucu.GetString(1);
                    kat.Aciklama = okuyucu.GetString(2);
                    kat.Durum = okuyucu.GetBoolean(3);
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
        public Uye UyeGetir(string kullaniciAdi)
        {
            try
            {
                komut.CommandText = "SELECT ID, Isim, Soyisim, Mail, UyelikTarihi, Durum FROM Uyeler WHERE KullaniciAdi = @kullaniciAdi";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);

                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                Uye u = null;
                while (okuyucu.Read())
                {
                    u = new Uye();
                    u.ID = okuyucu.GetInt32(0);
                    u.Isim = okuyucu.GetString(1);
                    u.Soyisim = okuyucu.GetString(2);
                    u.KullaniciAdi = kullaniciAdi;
                    u.Mail = okuyucu.GetString(3);
                    u.UyelikTarihi = okuyucu.GetDateTime(4);
                    u.Durum = okuyucu.GetBoolean(5);
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
        public bool UyeDuzenle(Uye u)
        {
            try
            {
                komut.CommandText = "UPDATE Uyeler SET Isim=@isim,Soyisim=@soyisim,KullaniciAdi=@kadi,Mail=@mail,UyelikTarihi=@uyet, Durum=@durum WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", u.ID);
                komut.Parameters.AddWithValue("@isim", u.Isim);
                komut.Parameters.AddWithValue("@Soyisim", u.Soyisim);
                komut.Parameters.AddWithValue("@kadi", u.KullaniciAdi);
                komut.Parameters.AddWithValue("@email", u.Mail);
                komut.Parameters.AddWithValue("@uyet", u.UyelikTarihi);
                komut.Parameters.AddWithValue("@durum", u.Durum);
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
        public void UyeSil(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM Uyeler WHERE ID=@id";
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
        public void UyeDurumDegistir(int id)
        {
            try
            {
                komut.CommandText = "SELECT Durum FROM Uyeler WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                bool durum = Convert.ToBoolean(komut.ExecuteScalar());

                komut.CommandText = "UPDATE Uyeler SET Durum=@durum WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                komut.Parameters.AddWithValue("@durum", !durum);
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }
        public Uye UyeGiris(string mail, string sifre)
        {
            try
            {
                Uye u = new Uye();
                komut.CommandText = "SELECT * FROM Uyeler WHERE Mail = @e AND Sifre = @s";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@e", mail);
                komut.Parameters.AddWithValue("@s", sifre);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    u.ID = okuyucu.GetInt32(0);
                    u.Isim = okuyucu.GetString(1);
                    u.Soyisim = okuyucu.GetString(2);
                    u.KullaniciAdi = okuyucu.GetString(3);
                    u.Mail = okuyucu.GetString(4);
                    u.Sifre = okuyucu.GetString(5);
                    u.UyelikTarihi = okuyucu.GetDateTime(6);
                    u.Durum = okuyucu.GetBoolean(7);
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
        public bool UyeOl(Uye u)
        {
            try
            {
                komut.CommandText = "INSERT INTO Uyeler(Isim, Soyisim, KullaniciAdi, Mail, Sifre, UyelikTarihi, Durum) VALUES(@isim, @soyisim, @kadi, @mail, @sifre, @uyetarih, @durum)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@isim", u.Isim);
                komut.Parameters.AddWithValue("@soyisim", u.Soyisim);
                komut.Parameters.AddWithValue("@kadi", u.KullaniciAdi);
                komut.Parameters.AddWithValue("@email", u.Mail);
                komut.Parameters.AddWithValue("@sifre", u.Sifre);
                komut.Parameters.AddWithValue("@uyetarih", u.UyelikTarihi);
                komut.Parameters.AddWithValue("@durum", u.Durum);
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
        public Uye UyeBilgisiGetir(int uyeID)
        {
            try
            {
                komut.CommandText = "SELECT ID, Isim, Soyisim, KullaniciAdi, Mail, UyelikTarihi, Durum, Sifre FROM Uyeler WHERE ID = @uyeID";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@uyeID", uyeID);

                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                Uye uye = null;
                if (okuyucu.Read())
                {
                    uye = new Uye();
                    uye.ID = okuyucu.GetInt32(0);
                    uye.Isim = okuyucu.GetString(1);
                    uye.Soyisim = okuyucu.GetString(2);
                    uye.KullaniciAdi = okuyucu.GetString(3);
                    uye.Mail = okuyucu.GetString(4);
                    uye.UyelikTarihi = okuyucu.GetDateTime(5);
                    uye.Durum = okuyucu.GetBoolean(6);
                    uye.Sifre = okuyucu.GetString(7);
                }
                return uye;
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
        public bool UyeSifreGuncelle(int uyeID, string yeniSifre)
        {
            try
            {
                Uye uye = UyeBilgisiGetir(uyeID);
                if (uye == null)
                    return false;

                komut.CommandText = "UPDATE Uyeler SET Sifre = @yeniSifre WHERE ID = @uyeID AND Sifre = @eskiSifre";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@yeniSifre", yeniSifre);
                komut.Parameters.AddWithValue("@uyeID", uyeID);
                komut.Parameters.AddWithValue("@eskiSifre", uye.Sifre);

                baglanti.Open();
                int etkilenenSatirSayisi = komut.ExecuteNonQuery();

                if (etkilenenSatirSayisi == 0)
                    return false;

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
        public Uye UyeMailGetir(string email)
        {
            try
            {
                komut.CommandText = "SELECT ID, Isim, Soyisim, KullaniciAdi, UyelikTarihi, Durum FROM Uyeler WHERE Email = @email";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@email", email);

                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                Uye uye = null;
                if (okuyucu.Read())
                {
                    uye = new Uye();
                    uye.ID = okuyucu.GetInt32(0);
                    uye.Isim = okuyucu.GetString(1);
                    uye.Soyisim = okuyucu.GetString(2);
                    uye.KullaniciAdi = okuyucu.GetString(3);
                    uye.Mail = email;
                    uye.UyelikTarihi = okuyucu.GetDateTime(4);
                    uye.Durum = okuyucu.GetBoolean(5);
                }
                return uye;
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
        public bool UyeProfilGuncelle(int uyeID, string isim, string soyisim, string kullaniciAdi, string email, string yeniSifre)
        {
            try
            {
                Uye uye = UyeBilgisiGetir(uyeID);
                if (uye == null)
                    return false;

                komut.CommandText = "UPDATE Uyeler SET Isim = @isim, Soyisim = @soyisim, KullaniciAdi = @kullaniciAdi, Mail = @mail, Sifre = @yeniSifre WHERE ID = @uyeID";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@isim", isim);
                komut.Parameters.AddWithValue("@soyisim", soyisim);
                komut.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                komut.Parameters.AddWithValue("@email", email);
                komut.Parameters.AddWithValue("@yeniSifre", yeniSifre);
                komut.Parameters.AddWithValue("@uyeID", uyeID);

                baglanti.Open();
                int etkilenenSatirSayisi = komut.ExecuteNonQuery();

                if (etkilenenSatirSayisi == 0)
                    return false;

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

        #region Yorum Metotlari
        public bool YorumEkle(Yorum yorum)
        {
            try
            {
                komut.CommandText = "INSERT INTO Yorumlar (MakaleID, UyeID, Icerik, EklemeTarihi, Durum) VALUES (@makaleID, @uyeID, @icerik, @eklemetarihi, @durum)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@makaleID", yorum.MakaleID);
                komut.Parameters.AddWithValue("@uyeID", yorum.UyeID);
                komut.Parameters.AddWithValue("@icerik", yorum.Icerik);
                komut.Parameters.AddWithValue("@eklemetarihi", yorum.EklemeTarihi);
                komut.Parameters.AddWithValue("@durum", yorum.Durum);
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
        public List<Yorum> TumYorumlariGetir()
        {
            List<Yorum> yorumlar = new List<Yorum>();

            try
            {
                komut.CommandText = "SELECT ID, MakaleID, UyeID, Icerik, EklemeTarihi, Durum FROM Yorumlar";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Yorum yorum = new Yorum();
                    yorum.ID = okuyucu.GetInt32(0);
                    yorum.MakaleID = okuyucu.GetInt32(1);
                    yorum.UyeID = okuyucu.GetInt32(2);
                    yorum.Icerik = okuyucu.GetString(3);
                    yorum.EklemeTarihi = okuyucu.GetDateTime(4);
                    yorum.Durum = okuyucu.GetBoolean(5);
                    yorumlar.Add(yorum);
                }
                return yorumlar;
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
        public void YorumSil(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM Yorumlar WHERE ID=@id";
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
        public void YorumDurumDegistir(int id)
        {
            try
            {
                komut.CommandText = "SELECT Durum FROM Yorumlar WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                bool durum = Convert.ToBoolean(komut.ExecuteScalar());

                komut.CommandText = "UPDATE Yorumlar SET Durum=@durum WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                komut.Parameters.AddWithValue("@durum", !durum);
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }
        public bool YorumDuzenle(Yorum yorum)
        {
            try
            {
                komut.CommandText = "UPDATE Yorumlar SET MakaleID=@makaleID, UyeID=@uyeID, Icerik=@icerik, Eklemetarihi=@eklemetarihi, Durum=@durum WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", yorum.ID);
                komut.Parameters.AddWithValue("@makaleID", yorum.MakaleID);
                komut.Parameters.AddWithValue("@uyeID", yorum.UyeID);
                komut.Parameters.AddWithValue("@icerik", yorum.Icerik);
                komut.Parameters.AddWithValue("@eklemetarihi", yorum.EklemeTarihi);
                komut.Parameters.AddWithValue("@durum", yorum.Durum);
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
        public List<Yorum> YorumlariGetir(int makaleID)
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                komut.CommandText = "SELECT y.ID, y.MakaleID, y.UyeID, y.Icerik, y.Eklemetarihi, y.Durum, u.Isim, u.Soyisim FROM Yorumlar y INNER JOIN Uyeler u ON y.Uye_ID = u.ID WHERE y.MakaleID = @makaleID";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@makaleID", makaleID);

                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Yorum yorum = new Yorum();
                    yorum.ID = okuyucu.GetInt32(0);
                    yorum.MakaleID = okuyucu.GetInt32(1);
                    yorum.UyeID = okuyucu.GetInt32(2);
                    yorum.Icerik = okuyucu.GetString(3);
                    yorum.EklemeTarihi = okuyucu.GetDateTime(4);
                    yorum.Durum = okuyucu.GetBoolean(5);
                    yorum.UyeIsim = okuyucu.GetString(6) + " " + okuyucu.GetString(7);
                    yorumlar.Add(yorum);
                }
                return yorumlar;
            }
            catch
            {
                return yorumlar;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public List<Yorum> UyeninYorumlariniGetir(int uyeID)
        {
            List<Yorum> uyeninYorumlari = new List<Yorum>();

            try
            {
                komut.CommandText = "SELECT ID, MakaleID, UyeID, Icerik, Eklemetarihi, Durum FROM Yorumlar WHERE UyeID = @UyeID";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@UyeID", uyeID);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Yorum yorum = new Yorum();
                    yorum.ID = okuyucu.GetInt32(0);
                    yorum.MakaleID = okuyucu.GetInt32(1);
                    yorum.UyeID = okuyucu.GetInt32(2);
                    yorum.Icerik = okuyucu.GetString(3);
                    yorum.EklemeTarihi = okuyucu.GetDateTime(4);
                    yorum.Durum = okuyucu.GetBoolean(5);
                    uyeninYorumlari.Add(yorum);
                }
                return uyeninYorumlari;
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

    }
    #endregion
}