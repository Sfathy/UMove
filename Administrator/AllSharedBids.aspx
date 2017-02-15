<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Admin.Master" AutoEventWireup="true" CodeBehind="AllSharedBids.aspx.cs" Inherits="UMoveNew.Administrator.AllSharedBids" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="counters">
        <div class="container">
            <div class="row">
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" Theme="PlasticBlue" KeyFieldName="ID" Width="100%" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" meta:resourcekey="ASPxGridView1Resource1">
        <Columns>
             <dx:GridViewDataTextColumn FieldName="ID" Caption="ID" VisibleIndex="0" Visible="false" meta:resourcekey="GridViewDataTextColumnResource1"></dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="TripName" Caption="Trip Name" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource2" ></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Price" Caption="Price" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SourceLocationText" Caption="Source Location" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource6"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DeliveryLocationText" Caption="Delivery Location" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource7"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="username" Caption="User" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource4"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="BidExpiration" Caption="Bid Expiration" VisibleIndex="6" meta:resourcekey="GridViewDataDateColumnResource1"></dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="Note" Caption="Note" VisibleIndex="7" meta:resourcekey="GridViewDataTextColumnResource5"></dx:GridViewDataTextColumn>
           <dx:GridViewDataComboBoxColumn FieldName="Puplished" SortIndex="0" SortOrder="Ascending" UnboundType="String" VisibleIndex="8" Caption="Status"  meta:resourcekey="GridViewDataComboBoxColumnResource1">
                       <PropertiesComboBox DataSourceID="SqlDataSource1" DropDownStyle="DropDown" TextField="Name" ValueField="ID">
                       </PropertiesComboBox>
                       </dx:GridViewDataComboBoxColumn>
              <dx:GridViewCommandColumn ButtonType="Image" Caption="Accept" VisibleIndex="9" meta:resourcekey="GridViewCommandColumnResource1" ShowClearFilterButton="True">
            
                    <CustomButtons>
                    <dx:GridViewCommandColumnCustomButton ID="btnAccept" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                        <Image IconID="actions_apply_16x16"></Image>
                    </dx:GridViewCommandColumnCustomButton>
                        <dx:GridViewCommandColumnCustomButton ID="btnIgnore" meta:resourcekey="GridViewCommandColumnCustomButtonResource2">
                            <Image IconID="actions_close_16x16">
                            </Image>
                        </dx:GridViewCommandColumnCustomButton>
                </CustomButtons>
            </dx:GridViewCommandColumn>
        </Columns>
             <Settings HorizontalScrollBarMode="Auto"/>
        <Settings ShowFilterRow="True" />
    </dx:ASPxGridView>
                <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT dbo.SharedTripsBid.Price, dbo.Users.Name AS username, dbo.SharedTripsBid.BidExpiration, dbo.SharedTripsBid.Note, dbo.SharedTrip.Name AS TripName, dbo.SharedTripsBid.Puplished, dbo.SharedTripsBid.ID, dbo.SharedTrip.SourceLocationText, dbo.SharedTrip.DeliveryLocationText FROM dbo.SharedTripsBid INNER JOIN dbo.Users ON dbo.SharedTripsBid.UserID = dbo.Users.ID INNER JOIN dbo.SharedTrip ON dbo.SharedTripsBid.SharedTripID = dbo.SharedTrip.ID WHERE (dbo.SharedTripsBid.Puplished <> 1) ORDER BY dbo.SharedTripsBid.Puplished"></asp:SqlDataSource>
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [ID], [Name] FROM [ItemStatus]"></asp:SqlDataSource>         
                 </div>
            </div>
        </div>
</asp:Content>
