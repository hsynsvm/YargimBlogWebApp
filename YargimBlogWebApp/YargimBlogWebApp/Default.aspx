<%@ Page Title="" Language="C#" MasterPageFile="~/Arayuz.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YargimBlogWebApp.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/Arayuz.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="lv_makaleler" runat="server" AllowPaging="true" OnPagePropertiesChanging="lv_makaleler_PagePropertiesChanging">
        <ItemTemplate>
            <div class="makale">
                <div class="resim">
                    <img src='Resimler/MakaleResimleri/<%# Eval("KapakResim") %>' />
                </div>
                <div class="baslik">
                    <a href='MakaleIcerik.aspx?MakaleID=<%# Eval("ID") %>'>
                        <h2>
                            <%# Eval("Baslik") %>
                    </h2>
                    </a>
                </div>
                <div class="bilgi">
                    <label>Kategori:</label>
                    <%# Eval("Kategori") %> <span style="font-weight: bold; font-size: 25pt; color: dimgray; padding-left: 5px; padding-right: 5px;">.</span>

                    <label>Yazar:</label>
                    <%# Eval("Yazar") %> <span style="font-weight: bold; font-size: 25pt; color: dimgray; padding-left: 5px; padding-right: 5px;">.</span>

                    <label>Tarih:</label>
                    <%# Eval("EklemeTarihi") %> <span style="font-weight: bold; font-size: 25pt; color: dimgray; padding-left: 5px; padding-right: 5px;">.</span>

                    <label>Görüntülenme Sayısı:</label>
                    <%# Eval("GoruntulemeSayisi") %> <span style="font-weight: bold; font-size: 25pt; color: dimgray; padding-left: 5px; padding-right: 5px;">.</span>
                </div>
                <div class="ozet">
                    <%# Eval("Ozet") %>
                </div>
                <div class="devami">
                    <a href='MakaleIcerik.aspx?MakaleID=<%# Eval("ID") %>'>
                        <label>Devamını Oku</label></a>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
    <asp:Panel ID="pnlDataPager" runat="server" CssClass="ozelsayfalayici">
        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lv_makaleler" PageSize="4">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="True" ShowNextPageButton="False"
                    ShowPreviousPageButton="False" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="True" ShowNextPageButton="False"
                    ShowPreviousPageButton="False" />
            </Fields>
        </asp:DataPager>
    </asp:Panel>
</asp:Content>
