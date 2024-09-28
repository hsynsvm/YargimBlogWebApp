<%@ Page Title="" Language="C#" MasterPageFile="~/Arayuz.Master" AutoEventWireup="true" CodeBehind="SifremiUnuttum.aspx.cs" Inherits="YargimBlogWebApp.SifremiUnuttum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/Arayuz.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tasiyici">
        <div class="GirisKutu">
            <div class="baslik">
                <h2>Şifremi Unuttum</h2>
            </div>
            <div class="GirisForm">
                <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizpanel" Visible="false">
                    <asp:Label ID="lbl_hatamesaj" runat="server"></asp:Label>
                </asp:Panel>
                <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarilipanel" Visible="false">
                    <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                </asp:Panel>
                <div class="satir">
                    <asp:TextBox ID="tb_mail" runat="server" CssClass="FormMetinKutu" placeholder="Mail Adresiniz"></asp:TextBox>
                </div>
                <div class="satir">
                    <asp:TextBox ID="tb_yenisifre" TextMode="Password" runat="server" CssClass="FormMetinKutu" placeholder="Yeni Şifre Giriniz"></asp:TextBox>
                </div>
                <div class="satir">
                    <asp:Button ID="btn_tikla" runat="server" Text="Yeni Şifre Oluştur" CssClass="FormGirisButon" OnClick="btn_tikla_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
