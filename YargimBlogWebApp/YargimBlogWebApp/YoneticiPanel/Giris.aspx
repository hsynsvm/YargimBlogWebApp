<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="YargimBlogWebApp.YoneticiPanel.Giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>YargimBlogWebAppYoneticiPanelGiris</title>
    <link href="Css/girisCss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="tasiyici">
            <div class="sol">
                <h3>Giriş Yapınız</h3>
                <div style="border-bottom:1px solid silver;padding-bottom:10px;margin:10px 0;"></div>
                <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="panelBasarisiz" Visible="false">
                    <asp:Label ID="lbl_mesaj" runat="server">Kullanıcı Bulunamadı</asp:Label>   
                </asp:Panel>
                <div class="satir">
                    <label>Mail</label><br />
                    <asp:TextBox ID="tb_mail" runat="server" CssClass="metinKutu" placeholder="@hotmail.com" Text="hsynsvm@hotmail.com"></asp:TextBox>
                </div>
                <div class="satir">
                    <label>Şifre</label><br />
                    <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinKutu" placeholder="123?***" TextMode="Password"></asp:TextBox>
                </div>
                <div class="satir">
                    <asp:Button ID="btn_girisYap" runat="server" OnClick="btn_girisYap_Click" Text="Yönetici Giriş" CssClass="girisButton" />
                </div>
                <div class="satir">
                    <a href="../SifremiUnuttum.aspx">Şifremi Unuttum</a>
                </div>
            </div>
            <div class="sag">
                <h2 class="baslik">Yönetici Giriş Paneline Hoşgeldiniz</h2>
                <br />
                <br />
                Bu Alandan Üye Girişi Yapılmamaktadır!
                <br />
                Üye Girişi Yapmak İçin
                <br />
                <br />
                <br />
                <a href="../UyeGiris.aspx" class="uyelink">Üye Giriş</a>
            </div>
            <div style="clear:both"></div>
        </div>
    </form>
</body>
</html>
