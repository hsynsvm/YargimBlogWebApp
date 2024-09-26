<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="YoneticiIslemleri.aspx.cs" Inherits="YargimBlogWebApp.YoneticiPanel.YoneticiIslemleri" %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/FormSayfasi.css" rel="stylesheet" />
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
             <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinKutu" textmode="Password"  ></asp:TextBox>
         </div>
         <div class="satir">
             <label class="Formetiket"></label>
             <br />
             <asp:CheckBox ID="cb_durum" runat="server" Text=" Yayınla" />
             <small style="color: dimgray">(Eğer işaretlenirse admin/moderatör aktif olur)</small>
         </div>
         <div class="satir">
             <asp:Button ID="lbtn_ekle" runat="server" CssClass="islemButton" Text="Admin/Moderatör Ekle" Onclick="lbtn_ekle_Click" />
         </div>
     </div>
 </div>

</asp:Content>
