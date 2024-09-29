<%@ Page Title="" Language="C#" MasterPageFile="~/Arayuz.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YargimBlogWebApp.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/Arayuz.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="lv_makaleler1" runat="server">
        <ItemTemplate>
            <div class="makale">
                <h2 style="margin: 10px 0;"><%# Eval("Baslik") %></h2>
                <img src='Resimler/MakaleResimleri/<%# Eval("KapakResim") %>' style="width: 100%" />
                <div class="ayrac"></div>
                <div class="altbilgi">
                    Yazar : <%# Eval("Yazar") %> | Kategori : <%# Eval("Kategori") %>
        Yayınlama Tarihi: <%# Eval("EklemeTarihi") %> | Görüntüleme Sayısı :
                    <%# Eval("GoruntulemeSayisi") %>
                </div>
                <div class="ayrac"></div>
                <div style="margin: 10px 0">
                    <%# Eval("Ozet") %>
         &nbsp;&nbsp;&nbsp;
                    <div class="devami">
                        <a href='MakaleIcerik.aspx?MakaleID=<%# Eval("ID") %>'>
                            <label>Devamını Oku</label></a>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>


</asp:Content>


