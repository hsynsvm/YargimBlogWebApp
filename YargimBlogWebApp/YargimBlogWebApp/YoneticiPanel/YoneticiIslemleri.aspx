<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="YoneticiIslemleri.aspx.cs" Inherits="YargimBlogWebApp.YoneticiPanel.YoneticiIslemleri" %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/Yonetici.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="yetkisiz" runat="server" Visible="false">
        <div class="anaTasiyici">
            <div class="yetkiKutusu">
                <label class="yetkiMesaj">Sadece Yöneticiler İşlem Yapabilir!</label>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel ID="yetkili" runat="server" Visible="true">
    <div class="anaTasiyici">
        <div class="sol">
            <div class="kutuBaslik">
                Yönetici Kayıt
            </div>
            <div class="kutuIcerik" style="min-height:300px;">
                <div class="yoneticiSatir">
                    <label>Ad</label><br />
                    <asp:TextBox ID="tb_ad" runat="server" CssClass="tbStyle"></asp:TextBox>
                </div>
                <div class="yoneticiSatir">
                    Soyad<br />
                    <asp:TextBox ID="tb_soyad" runat="server" CssClass="tbStyle"></asp:TextBox>
                </div>
                <div class="yoneticiSatir">
                    Kullanıcı Adı<br />
                    <asp:TextBox ID="tb_kullaniciAdi" runat="server" CssClass="tbStyle"></asp:TextBox>
                </div>
                <div class="yoneticiSatir">
                    Mail<br />
                    <asp:TextBox ID="tb_mail" runat="server" CssClass="tbStyle"></asp:TextBox>
                </div>
                <div class="yoneticiSatir">
                    Şifre<br />
                    <asp:TextBox ID="tb_sifre" runat="server" CssClass="tbStyle"></asp:TextBox>
                </div>
                <div class="yoneticiSatir">
                    Yetki<br />
                    <asp:DropDownList ID="ddl_yetki" runat="server" CssClass="ddlStyle" DataTextField="GorevAdi" DataValueField="ID"></asp:DropDownList>
                </div>
                <div class="yoneticiSatir">
                    Profil Fotoğrafı
                    <asp:FileUpload ID="fu_profilResmi" runat="server" />
                </div>
                <div class="yoneticiSatir" style="margin-top:30px; text-align:center">
                    <asp:LinkButton ID="lbtn_ekle" runat="server" CssClass="ekleButon" OnClick="lbtn_ekle_Click" Text="Kayıt"></asp:LinkButton>
                </div>
                <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizPanel" Visible="false">
                    <asp:Label ID="lbl_bilgi" runat="server" CssClass="bilgi">Başarısız!</asp:Label>
                </asp:Panel>
            </div>
        </div>
       
        <div class="sol" style="">
            <div class="kutuBaslik">
               Yetki Oluştur
            </div>
            <div class="kutuIcerik" style="min-height:200px; width:682px; ">
                <div class="etiketSatir" style="text-align: center">
                    <label class="etiketBaslik">Yetki</label>
                </div>
                <div class="etiketSatir" style="text-align: center; margin-bottom: 20px;">
                    <asp:TextBox ID="tb_yetkiAdi" runat="server" CssClass="tbStyle"></asp:TextBox>
                </div>
                <div class="etiketSatir" style="text-align: center; margin-top: 30px;">
                    <asp:LinkButton ID="lbtn_yetkiEkle" runat="server" Text="Ekle" OnClick="lbtn_yetkiEkle_Click" CssClass="ekleButon">
                    </asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="kutu sol">
            <div class="kutuBaslik">
                Yetkiler
            </div>
            <div class="kutuIcerik" style="min-height:200px; width:682px;">
                <asp:ListView ID="lv_yetki" runat="server" OnItemCommand="lv_yetki_ItemCommand">
                    <LayoutTemplate>
                        <table cellspacing="0" cellpadding="0" class="tablo">
                            <tr>
                                <th>ID</th>
                                <th>Yetki</th>
                                <th>Seçenekler</th>
                            </tr>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("YoneticiTurID") %></td>
                            <td><%# Eval("YoneticiTur") %></td>
                            <td>
                                <asp:LinkButton ID="lbtn_sil" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="sil">
                                   <img src="adminResimler/delete.png" style="width:16px;height:16px" />
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
</asp:Panel>

</asp:Content>
