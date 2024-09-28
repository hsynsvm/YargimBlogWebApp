<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="YoneticiIslemleri.aspx.cs" Inherits="YargimBlogWebApp.YoneticiPanel.YoneticiIslemleri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/FormSayfasi.css" rel="stylesheet" />
    <link href="Css/ListeSayfasi.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik ">
            <h3>Admin/Moderatör Ekle</h3>
        </div>
        <div class="formIcerik">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizPanel" Visible="false">
                <asp:Label ID="lbl_hatamesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliPanel" Visible="false">
                <label>Ekleme Başarılı</label>
            </asp:Panel>
            <div class="satir">
                <label class="Formetiket">Yönetici Türü</label>
                <asp:RadioButtonList ID="rb_YoneticiTur_ID" runat="server" CssClass="metinKutu">
                    <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Moderatör" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="satir">
                <label class="Formetiket">İsim</label>
                <asp:TextBox ID="tb_isim" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>
            <div class="satir">
                <label class="Formetiket">Soyisim</label>
                <asp:TextBox ID="tb_soyisim" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>
            <div class="satir">
                <label class="Formetiket">Kullanıcı Adı</label>
                <asp:TextBox ID="tb_kullaniciadi" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>
            <div class="satir">
                <label class="Formetiket">E-mail</label>
                <asp:TextBox ID="tb_mail" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>
            <div class="satir">
                <label class="Formetiket">Şifre</label>
                <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinKutu" TextMode="Password"></asp:TextBox>
            </div>
            <div class="satir">
                <label class="Formetiket"></label>
                <br />
                <asp:CheckBox ID="cb_durum" runat="server" Text=" Yayınla" />
                <small style="color: dimgray">(Eğer işaretlenirse admin/moderatör aktif olur)</small>
            </div>
            <div class="satir">
                <asp:Button ID="lbtn_ekle" runat="server" CssClass="islemButton" Text="Admin/Moderatör Ekle" OnClick="lbtn_ekle_Click" />
            </div>
        </div>
    </div>
    <br />
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Kullanıcılar</h3>
        </div>
        <asp:ListView ID="lv_kullanicilar" runat="server" OnItemCommand="lv_kullanicilar_ItemCommand">
            <LayoutTemplate>
                <table cellpadding="0" cellspacing="0" class="tablo">
                    <tr>
                        <th style="text-align: center">ID</th>
                        <th>Yönetici Tür ID</th>
                        <th>Isim</th>
                        <th>Soyisim</th>
                        <th>Kullanıcı Adı</th>
                        <th>Mail</th>
                        <th>Durum</th>
                        <th>Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center"><%# Eval("ID") %></td>
                    <td><%# Eval("YoneticiTurID") %></td>
                    <td><%# Eval("Isim") %></td>
                    <td><%# Eval("Soyisim") %></td>
                    <td><%# Eval("KullaniciAdi") %></td>
                    <td><%# Eval("Mail") %></td>
                    <td><%# Eval("Durum") %></td>
                    <td>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="sil"><img src="adminResimler/delete.png" class="delete"/></asp:LinkButton>
                        <asp:LinkButton ID="lbtn_durum" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="durum"><img src="adminResimler/edit.png" class="edit" /></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <br />
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Profil Ayarları</h3>
        </div>
        <div class="FormIcerik">
            <asp:Panel ID="Panel1" runat="server" CssClass="basarisizpanel" Visible="false">
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" CssClass="basarilipanel" Visible="false">
                <label>Profil başarıyla güncellenmiştir</label>
            </asp:Panel>
            <div class="satir">
                <label class="Formetiket">Kullanıcı Adı</label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>
            <div class="satir">
                <label class="Formetiket">İsim</label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>
            <div class="satir">
                <label class="Formetiket">Soyisim</label>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>
            <div class="satir">
                <label class="Formetiket">Mail</label>
                <asp:TextBox ID="tb_email" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>
            <div class="satir">
                <label class="Formetiket">Şifre</label>
                <asp:TextBox ID="TextBox4" runat="server" CssClass="metinKutu" TextMode="Password"></asp:TextBox>
            </div>
            <div class="satir">
                <label class="Formetiket">Durum</label><br />
                <asp:CheckBox ID="CheckBox1" runat="server" />
                <small style="color: dimgray">(Eğer işaretli ise profil güncelleme aktif olur)</small>
            </div>
            <div class="satir">
                <asp:Button ID="lbtn_profil" runat="server" CssClass="islemButton" Text="Profil Güncelle" OnClick="lbtn_profil_Click" />
            </div>
        </div>
    </div>

</asp:Content>
