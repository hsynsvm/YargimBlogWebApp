<%@ Page Title="" Language="C#" MasterPageFile="~/UyePanel/UyePanel.Master" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="YargimBlogWebApp.UyePanel.Profil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/UyeGiris.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <div class="FormTasiyici">
    <div class="FormBaslik">
        <h3>Profil Ayarları</h3>
    </div>
    <div class="FormIcerik">
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizpanel" Visible="false">
            <asp:Label ID="lbl_hatamesaj" runat="server"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarilipanel" Visible="false">
            <label>Profil başarıyla güncellenmiştir</label>
        </asp:Panel>
        <div class="satir">
            <label class="Formetiket">Kullanıcı Adı</label>
            <asp:TextBox ID="tb_kullaniciadi" runat="server" CssClass="metinkutu"></asp:TextBox>
        </div>
        <div class="satir">
            <label class="Formetiket">İsim</label>
            <asp:TextBox ID="tb_isim" runat="server" CssClass="metinkutu" ></asp:TextBox>
        </div>
        <div class="satir">
            <label class="Formetiket">Soyisim</label>
            <asp:TextBox ID="tb_soyisim" runat="server" CssClass="metinkutu" ></asp:TextBox>
        </div>
        <div class="satir">
            <label class="Formetiket">E-mail</label>
            <asp:TextBox ID="tb_email" runat="server" CssClass="metinkutu" ></asp:TextBox>
        </div>
        <div class="satir">
            <label class="Formetiket">Şifre</label>
            <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinkutu" TextMode="Password" ></asp:TextBox>
        </div>
        <div class="satir">
            <label class="Formetiket">Durum</label><br />
            <asp:CheckBox ID="cb_durum" runat="server"  />
            <small style="color: dimgray">(Eğer işaretli ise profil güncelleme aktif olur)</small>
        </div>
        <div class="satir">
            <asp:Button ID="lbtn_ekle" runat="server" CssClass="FormButton" Text="Profil Güncelle" OnClick="lbtn_ekle_Click" />
        </div>
    </div>
</div>
</asp:Content>
