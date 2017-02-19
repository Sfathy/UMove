<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Admin.Master" AutoEventWireup="true" CodeBehind="AllSharedTrips.aspx.cs" Inherits="UMoveNew.Administrator.AllSharedTrips" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="counters">
        <div class="container">
            <div class="row">
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" Theme="Glass" DataSourceID="SqlDataSource1" Width="100%" EnableTheming="True" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" meta:resourcekey="ASPxGridView1Resource1">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="TripName" Width="100%" Caption="Trip Name" VisibleIndex="0" meta:resourcekey="GridViewDataTextColumnResource1"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="SourceLocationText" Width="100%" Caption="Source Location" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="DeliveryLocationText" Width="100%" Caption="Delivery Location" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="PicUpDate" Caption="PicUp Date" Width="100%" VisibleIndex="6" meta:resourcekey="GridViewDataDateColumnResource1"></dx:GridViewDataDateColumn>
                        <dx:GridViewDataDateColumn FieldName="DeliveryDate" Caption="Delivery Date" Width="100%" VisibleIndex="7" meta:resourcekey="GridViewDataDateColumnResource2"></dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="Ending" Caption="Duration" Width="100%" ReadOnly="True" VisibleIndex="8" meta:resourcekey="GridViewDataTextColumnResource4"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="9" Width="100%" Visible="false" meta:resourcekey="GridViewDataTextColumnResource5">
                            <EditFormSettings Visible="False"></EditFormSettings>
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataComboBoxColumn FieldName="UserID" Caption="User" Width="100%" VisibleIndex="3" meta:resourcekey="GridViewDataComboBoxColumnResource3">
                            <PropertiesComboBox DataSourceID="SqlDataSource5" TextField="Name" ValueField="ID"></PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                          <dx:GridViewDataComboBoxColumn FieldName="Puplished" Width="100%" SortIndex="0" SortOrder="Ascending" UnboundType="String" VisibleIndex="8" Caption="Status"  meta:resourcekey="GridViewDataComboBoxColumnResource1">
                       <PropertiesComboBox DataSourceID="SqlDataSource2" DropDownStyle="DropDown" TextField="Name" ValueField="ID">
                       </PropertiesComboBox>
                       </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewCommandColumn ButtonType="Image" Caption="Accept" Width="100%" VisibleIndex="10" meta:resourcekey="GridViewCommandColumnResource1" ShowClearFilterButton="True">
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
                    <Settings ShowFilterRow="True" />
                         <Settings HorizontalScrollBarMode="Auto"/>
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
       <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [ID], [Name] FROM [ItemStatus]"></asp:SqlDataSource>         
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [ID], [Name] FROM [Users]"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT     Name AS TripName, SourceLocationText, DeliveryLocationText, PicUpDate, DeliveryDate, DATEDIFF(hh, PicUpDate, DeliveryDate) AS Ending, ID, UserID, ACOS(SIN(SourceLat) * SIN(DestLat) + COS(SourceLat) * COS(DestLat) * COS(DestLag - DestLag)) AS Dis,Puplished FROM dbo.SharedTrip WHERE (Puplished <> 1)"></asp:SqlDataSource>
</asp:Content>
