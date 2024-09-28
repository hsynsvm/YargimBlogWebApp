<%@ Page Title="" Language="C#" MasterPageFile="~/Arayuz.Master" AutoEventWireup="true" CodeBehind="Iletisim.aspx.cs" Inherits="YargimBlogWebApp.Iletisim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="Css/Arayuz2.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="iletisimsatir">
    <div class="iletisimbaslik">
        <label>İLETİŞİM</label>
    </div>
    <div class="iletisimicerik">
       <img src="Resimler/Icon/email-marketing.png" style="width:150px;height:120px" />
        <h3>yargimblog@hotmail.com</h3><br />
        <hr />
        <img src="Resimler/Icon/instagram.png" style="width:150px;height:120px" />
        <a href="#">YargımBlog</a><br />
        <hr />
       <img src="Resimler/Icon/facebook.png" style="width:150px;height:120px" />
        <a href="#">YargımBlog</a><br />
        <hr />
        <br />
        <p class="iletisimicerik">Adres: Tepebaşı/Eskişehir</p>
        <hr />
    </div>
</div>
</asp:Content>
