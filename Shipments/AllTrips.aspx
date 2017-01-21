<%@ Page Title="" Language="C#" MasterPageFile="~/Shipments/Site.Master" AutoEventWireup="true" CodeBehind="AllTrips.aspx.cs" Inherits="UMoveNew.Shipments.AllTrips" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="counters">
        <div class="container">
            <div class="row">
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" KeyFieldName="ID" Theme="Glass" DataSourceID="SqlDataSource1" Width="100%" EnableTheming="True" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" meta:resourcekey="ASPxGridView1Resource1">

                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="TripName" Caption="Trip Name" VisibleIndex="0" meta:resourcekey="GridViewDataTextColumnResource1"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="SourceLocationText" Caption="Source Location" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="DeliveryLocationText" Caption="Delivery Location" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="PicUpDate" Caption="PicUp Date" VisibleIndex="6" meta:resourcekey="GridViewDataDateColumnResource1"></dx:GridViewDataDateColumn>
                        <dx:GridViewDataDateColumn FieldName="DeliveryDate" Caption="Delivery Date" VisibleIndex="7" meta:resourcekey="GridViewDataDateColumnResource2"></dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="Ending" Caption="Duration" ReadOnly="True" VisibleIndex="8" meta:resourcekey="GridViewDataTextColumnResource4"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="9" Visible="false" meta:resourcekey="GridViewDataTextColumnResource5">
                            <EditFormSettings Visible="False"></EditFormSettings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="ItemCatID"  Caption="Catrgory" VisibleIndex="1" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                            <PropertiesComboBox DataSourceID="SqlDataSource3" TextField="Name" ValueField="ID"></PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="ItemSubCatID" Caption=" Sub Catrgory" VisibleIndex="2" meta:resourcekey="GridViewDataComboBoxColumnResource2">
                                <PropertiesComboBox DataSourceID="SqlDataSource4"  TextField="Name" ValueField="ID"></PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="UserID" Caption="User" VisibleIndex="3" meta:resourcekey="GridViewDataComboBoxColumnResource3">
                              <PropertiesComboBox DataSourceID="SqlDataSource5" TextField="Name" ValueField="ID"></PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewCommandColumn ButtonType="Image" Caption="Bid" VisibleIndex="11" meta:resourcekey="GridViewCommandColumnResource1">
                            <CustomButtons>
                                <dx:GridViewCommandColumnCustomButton ID="BtnBid" Text="Bid" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                    <Image IconID="tasks_edittask_16x16">
                                    </Image>
                                </dx:GridViewCommandColumnCustomButton>
                            </CustomButtons>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn Caption="Distance" FieldName="Dis" Name="Distance" UnboundType="Decimal" VisibleIndex="10" meta:resourcekey="GridViewDataTextColumnResource6">
                          
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsDetail ShowDetailRow="True" />
                    <Templates>
                        <DetailRow>
                            <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" Theme="Glass" DataSourceID="SqlDataSource2" KeyFieldName="ID" OnBeforePerformDataSelect="detailGrid_BeforePerformDataSelect" Width="100%" meta:resourcekey="ASPxGridView2Resource1">
                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="0"  Visible="False" meta:resourcekey="GridViewDataTextColumnResource7" ShowInCustomizationForm="True">
                                        <EditFormSettings Visible="False"></EditFormSettings>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="TripID" VisibleIndex="1"  Visible="False" meta:resourcekey="GridViewDataTextColumnResource8" ShowInCustomizationForm="True"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ItemDesc" Caption="Description" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource9" ShowInCustomizationForm="True"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Width" Caption="Width" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource10" ShowInCustomizationForm="True"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Height" Caption="Height" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource11" ShowInCustomizationForm="True"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Length" Caption="Length" VisibleIndex="6" meta:resourcekey="GridViewDataTextColumnResource12" ShowInCustomizationForm="True"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Wight" Caption="Wight" VisibleIndex="7" meta:resourcekey="GridViewDataTextColumnResource13" ShowInCustomizationForm="True"></dx:GridViewDataTextColumn>

                                    <dx:GridViewDataImageColumn FieldName="ImageURL" Caption="Image" Width="50px" VisibleIndex="2" meta:resourcekey="GridViewDataImageColumnResource1" ShowInCustomizationForm="True"></dx:GridViewDataImageColumn>
                                    
                                </Columns>
                            </dx:ASPxGridView>
                            <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT TripItems.ID, TripItems.TripID, TripItems.ItemDesc, TripItems.Width, TripItems.Height, TripItems.Length, TripItems.Wight, TripItems.NoOfUnits, TripItems.ImageURL, SubCategory.Name AS SubCategory, Categories.Name AS Category FROM TripItems INNER JOIN SubCategory ON TripItems.ID = SubCategory.ID INNER JOIN Categories ON TripItems.ID = Categories.ID 
Where TripItems.TripID=@TripID
">
                                <SelectParameters>
                                    <asp:SessionParameter SessionField="TripID" Name="TripID"></asp:SessionParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </DetailRow>
                    </Templates>
                    <Settings ShowFilterRow="True"></Settings>
                </dx:ASPxGridView>

            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [ID], [Name] FROM [Categories]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [ID], [Name] FROM [SubCategory]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [ID], [Name] FROM [Users]"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT Trip.Name AS TripName, Trip.SourceLocationText, Trip.DeliveryLocationText, Trip.PicUpDate, Trip.DeliveryDate, DATEDIFF(hh, Trip.PicUpDate, Trip.DeliveryDate) AS Ending, Trip.ID, TripItems.ItemCatID, TripItems.ItemSubCatID, Trip.UserID, ACOS(SIN(Trip.SourceLat) * SIN(Trip.DestLat) + COS(Trip.SourceLat) * COS(Trip.DestLat) * COS(Trip.DestLag - Trip.DestLag)) AS Dis FROM Trip INNER JOIN TripItems ON Trip.ID = TripItems.ID where Puplished=1"></asp:SqlDataSource>
</asp:Content>
