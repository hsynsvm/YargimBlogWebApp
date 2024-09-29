<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="YoneticiDefault.aspx.cs" Inherits="YargimBlogWebApp.YoneticiPanel.YoneticiDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/FormSayfasi.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="yonetimpaneli">
        <div class="panel yoneticisayisi">
            <a href="YoneticiIslemleri.aspx"><img src="adminResimler/admin.png" class="icon" /></a>
            <p>Admin/Moderatör</p>
            <asp:Label ID="lblYoneticiSayisi" runat="server"></asp:Label>
        </div>
        <div class="panel makalesayisi">
            <a href="MakaleListele.aspx"><img src="adminResimler/list.png" class="icon"/></a>
            <p>Makale</p>
            <asp:Label ID="lblMakaleSayisi" runat="server"></asp:Label>
        </div>
        <div class="panel yorumsayisi">
            <a href="Yorumlar.aspx"><img src="adminResimler/comment.png" class="icon" /></a>
            <p>Yorum</p>
            <asp:Label ID="lblYorumSayisi" runat="server"></asp:Label>
        </div>
        <div class="panel uyesayisi">
            <a href="Uyeler.aspx"> <img src="adminResimler/team.png" class="icon" /></a>
            <p>Üye</p>
            <asp:Label ID="lblUyeSayisi" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
