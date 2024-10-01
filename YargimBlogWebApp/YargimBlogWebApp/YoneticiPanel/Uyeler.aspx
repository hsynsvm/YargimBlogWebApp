<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="Uyeler.aspx.cs" Inherits="YargimBlogWebApp.YoneticiPanel.Uyeler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/FormSayfasi.css" rel="stylesheet" />
    <link href="Css/ListeSayfasi.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Üyeler</h3>
        </div>
        <asp:ListView ID="lv_uyeler" runat="server" OnItemCommand="lv_uyeler_ItemCommand">
            <LayoutTemplate>
                <table cellpadding="0" cellspacing="0" class="tablo">
                    <tr>
                        <th style="text-align: center">ID</th>
                        <th>İsim</th>
                        <th>Soyisim</th>
                        <th>Kullanıcı Adı</th>
                        <th>Email</th>
                        <th>Üyelik Tarihi</th>
                        <th>Durum</th>
                        <th>Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center"><%# Eval("ID") %></td>
                    <td><%# Eval("Isim") %></td>
                    <td><%# Eval("Soyisim") %></td>
                    <td><%# Eval("KullaniciAdi") %></td>
                    <td><%# Eval("Mail") %></td>
                    <td><%# Eval("UyelikTarihi") %></td>
                    <td><%# Eval("Durum") %></td>
                    <td>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="sil"><img src="adminResimler/delete.png" class="delete"/></asp:LinkButton>
                        <asp:LinkButton ID="lbtn_durum" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="durum"><img src="adminResimler/edit.png" class="edit" /></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>

</asp:Content>
