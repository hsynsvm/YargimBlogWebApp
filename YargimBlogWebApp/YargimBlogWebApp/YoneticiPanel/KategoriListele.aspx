<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="KategoriListele.aspx.cs" Inherits="YargimBlogWebApp.YoneticiPanel.KategoriListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/ListeSayfasi.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sayfaBaslik">
        <h3>Kategoriler</h3>
    </div>
    <div class="tabloTasiyici">
        <asp:ListView ID="lv_Kategoriler" runat="server" OnItemCommand="lv_Kategoriler_ItemCommand">
            <LayoutTemplate>
                <table>
                    <tr>
                        <th>ID</th
                        <th>İsim</th>
                        <th>Açıklama</th>
                        <th>Durum</th>
                        <th>Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Isim") %></td>
                    <td><%# Eval("Aciklama") %></td>
                    <td><%# Eval("Durum") %></td>
                    <td>
                        <a href='KategoriDuzenle.aspx?kategoriId=<%# Eval("ID") %>' class="tablobutton duzenle">
                            <img src="adminResimler/edit.png" /></a>
                        <asp:LinkButton ID="lbtn_durum" runat="server" class="tablobutton durum" CommandArgument='<%# Eval("ID") %>' CommandName="durum">
                             <img src="adminResimler/arrow.png" />
                         </asp:LinkButton>
                         <asp:LinkButton ID="lbtn_sil" runat="server" class="tablobutton sil" CommandArgument='<%# Eval("ID") %>' CommandName="sil"> 
                              <img src="adminResimler/delete.png" />
                         </asp:LinkButton>
                      </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
