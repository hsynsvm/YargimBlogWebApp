<%@ Page Title="" Language="C#" MasterPageFile="~/Arayuz.Master" AutoEventWireup="true" CodeBehind="MakaleIcerik.aspx.cs" Inherits="YargimBlogWebApp.MakaleIcerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/Arayuz.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="makale">
        <div class="resim">
            <asp:Image ID="img_resim" runat="server" />
        </div>
        <div class="baslik">
            <h2>
                <asp:Literal ID="ltrl_baslik" runat="server"></asp:Literal>
            </h2>
        </div>
        <div class="bilgi">
            <label>Kategori:</label>
            <asp:Literal ID="ltrl_kategori" runat="server"></asp:Literal>
            <span style="font-weight: bold; font-size: 25pt; color: dimgray; padding-left: 5px; padding-right: 5px;">.</span>

            <label>Yazar:</label>
            <asp:Literal ID="ltrl_Yazar" runat="server"></asp:Literal>
            <span style="font-weight: bold; font-size: 25pt; color: dimgray; padding-left: 5px; padding-right: 5px;">.</span>

            <label>Tarih:</label>
            <asp:Literal ID="ltrl_Tarih" runat="server"></asp:Literal>
            <span style="font-weight: bold; font-size: 25pt; color: dimgray; padding-left: 5px; padding-right: 5px;">.</span>
        </div>
        <div class="ozet">
            <asp:Literal ID="ltrl_Icerik" runat="server"></asp:Literal>
        </div>
        </div>
    <div class="YorumKutusu">
        <h3>Yorumlar</h3>
        <asp:Repeater ID="rp_yorumlar" runat="server">
            <ItemTemplate>
                <div class="Yorum">
                    <div class="Icerik">
                        <%#Eval("Icerik") %>
                    </div>
                    <div class="Bilgiler">
                        Uye: <%#Eval("UyeIsim") %> | Tarih: <%#Eval("EklemeTarihi") %>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="YorumPanel">
        <div class="baslik">
            <h3>Yorum Paneli</h3>
        </div>
        <asp:Panel ID="pnl_girisvar" runat="server">
            <div class="satir">
                <asp:TextBox ID="tb_yorum" runat="server" TextMode="MultiLine" CssClass="FormMetinKutu"></asp:TextBox>
            </div>
            <div class="satir" style="margin-top: 20px;">
                <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizpanel" Visible="false">
                    <asp:Label ID="lbl_hatamesaj" runat="server"></asp:Label>
                </asp:Panel>
                <asp:LinkButton ID="lbtn_ekle" runat="server" CssClass="FormYorumButon" OnClick="lbtn_ekle_Click">Yorum Gönder</asp:LinkButton>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnl_girisYok" runat="server">
            <label style="text-align: center; display: block; margin-top: 20px;">Yorum yapabilmek için lütfen <a href="UyeGiris.aspx">Giriş</a> yapınız.</label>

        </asp:Panel>
    </div>

</asp:Content>
