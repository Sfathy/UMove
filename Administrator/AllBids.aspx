<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Admin.Master" AutoEventWireup="true" CodeBehind="AllBids.aspx.cs" Inherits="UMoveNew.Administrator.AllBids" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="counters">
        <div class="container">
            <div class="row">
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" Theme="PlasticBlue" KeyFieldName="ID" Width="100%" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" meta:resourcekey="ASPxGridView1Resource1">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="ID" Caption="ID" Width="100%" VisibleIndex="0" Visible="false" meta:resourcekey="GridViewDataTextColumnResource1"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="TripName" Caption="Trip Name" Width="100%" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Price" Caption="Price" Width="100%" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="SourceLocationText" Width="100%" Caption="Source Location" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource6"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="DeliveryLocationText" Width="100%" Caption="Delivery Location" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource7"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="username" Caption="User" Width="100%" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource4"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="BidExpiration" Width="100%" Caption="Bid Expiration" VisibleIndex="6" meta:resourcekey="GridViewDataDateColumnResource1"></dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="Note" Caption="Note" Width="100%" VisibleIndex="7" meta:resourcekey="GridViewDataTextColumnResource5"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="Puplished" Width="100%" SortIndex="0" SortOrder="Ascending" UnboundType="String" VisibleIndex="8" Caption="Status" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                            <PropertiesComboBox DataSourceID="SqlDataSource1" DropDownStyle="DropDown" TextField="Name" ValueField="ID">
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewCommandColumn ButtonType="Image" Caption="Accept" Width="100%" VisibleIndex="9" meta:resourcekey="GridViewCommandColumnResource1" ShowClearFilterButton="True">
                            <CustomButtons>
                                <dx:GridViewCommandColumnCustomButton ID="btnAccept" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                    <Image IconID="actions_apply_16x16"></Image>
                                </dx:GridViewCommandColumnCustomButton>
                                <dx:GridViewCommandColumnCustomButton ID="btnIgnore">
                                    <Image IconID="actions_close_16x16">
                                    </Image>
                                </dx:GridViewCommandColumnCustomButton>
                            </CustomButtons>
                        </dx:GridViewCommandColumn>
                    </Columns>
                     <Settings HorizontalScrollBarMode="Auto"/>
                    <Settings ShowFilterRow="True" />
                </dx:ASPxGridView>
                <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT dbo.Bid.Price, dbo.Users.Name AS username, dbo.Bid.BidExpiration, dbo.Bid.Note, dbo.Trip.Name AS TripName, dbo.Bid.Puplished, dbo.Bid.ID,dbo.Trip.SourceLocationText,dbo.Trip.DeliveryLocationText FROM dbo.Bid INNER JOIN dbo.Users ON dbo.Bid.UserID = dbo.Users.ID INNER JOIN dbo.Trip ON dbo.Bid.TripID = dbo.Trip.ID WHERE (dbo.Bid.Puplished <> 1) order by Puplished"></asp:SqlDataSource>
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [ID], [Name] FROM [ItemStatus]"></asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>
