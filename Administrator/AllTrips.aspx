<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Admin.Master" AutoEventWireup="true" CodeBehind="AllTrips.aspx.cs" Inherits="UMoveNew.Administrator.AllTrips" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

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
                        <dx:GridViewDataTextColumn FieldName="TripName" Caption="Trip Name" VisibleIndex="0" meta:resourcekey="GridViewDataTextColumnResource1" ></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="SourceLocationText" Caption="Source Location" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="DeliveryLocationText" Caption="Delivery Location" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="PicUpDate" Caption="PicUp Date" VisibleIndex="6" meta:resourcekey="GridViewDataDateColumnResource1"></dx:GridViewDataDateColumn>
                        <dx:GridViewDataDateColumn FieldName="DeliveryDate" Caption="Delivery Date" VisibleIndex="7" meta:resourcekey="GridViewDataDateColumnResource2"></dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="Ending" Caption="Duration" ReadOnly="True" VisibleIndex="8" meta:resourcekey="GridViewDataTextColumnResource4" ></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="9" Visible="false" meta:resourcekey="GridViewDataTextColumnResource5">
                            <EditFormSettings Visible="False"></EditFormSettings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="ItemCatID" Caption="Catrgory" VisibleIndex="1" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                            <PropertiesComboBox DataSourceID="SqlDataSource3" TextField="Name" ValueField="ID"></PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="ItemSubCatID" Caption=" Sub Catrgory" VisibleIndex="2" meta:resourcekey="GridViewDataComboBoxColumnResource2">
                            <PropertiesComboBox DataSourceID="SqlDataSource4" TextField="Name" ValueField="ID"></PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="UserID" Caption="User" VisibleIndex="3" meta:resourcekey="GridViewDataComboBoxColumnResource3">
                            <PropertiesComboBox DataSourceID="SqlDataSource5" TextField="Name" ValueField="ID"></PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                          <dx:GridViewDataComboBoxColumn FieldName="Puplished" SortIndex="0" SortOrder="Ascending" UnboundType="String" VisibleIndex="6" Caption="Status"  meta:resourcekey="GridViewDataComboBoxColumnResource7">
                       <PropertiesComboBox DataSourceID="SqlDataSource10" DropDownStyle="DropDown" TextField="Name" ValueField="ID">
                       </PropertiesComboBox>
                       </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewCommandColumn ButtonType="Image" Caption="View / Accept" VisibleIndex="11" meta:resourcekey="GridViewCommandColumnResource1">
                            <CustomButtons>
                                <dx:GridViewCommandColumnCustomButton ID="BtnView" Text="View" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                    <Image IconID="actions_show_16x16">
                                    </Image>
                                </dx:GridViewCommandColumnCustomButton>
                                <dx:GridViewCommandColumnCustomButton ID="btnAccept" Text="Accept" meta:resourcekey="GridViewCommandColumnCustomButtonResource2">
                                    <Image IconID="actions_apply_16x16">
                                    </Image>
                                </dx:GridViewCommandColumnCustomButton>
                                  <dx:GridViewCommandColumnCustomButton ID="btnIgnore">
                            <Image IconID="actions_close_16x16">
                            </Image>
                        </dx:GridViewCommandColumnCustomButton>
                            </CustomButtons>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn Caption="Distance" FieldName="Dis" Name="Distance" UnboundType="Decimal" VisibleIndex="10" meta:resourcekey="GridViewDataTextColumnResource6" >
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsDetail ShowDetailRow="True" />
                    <Templates>
                        <DetailRow>
                            <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" Theme="Glass" DataSourceID="SqlDataSource2" KeyFieldName="ID" OnBeforePerformDataSelect="detailGrid_BeforePerformDataSelect" Width="100%" meta:resourcekey="ASPxGridView2Resource1" >
                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="0" Visible="False"  ShowInCustomizationForm="True" meta:resourcekey="GridViewDataTextColumnResource7">
                                        <EditFormSettings Visible="False"></EditFormSettings>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="TripID" VisibleIndex="1" Visible="False" ShowInCustomizationForm="True" meta:resourcekey="GridViewDataTextColumnResource8"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ItemDesc" Caption="Description" VisibleIndex="3"  ShowInCustomizationForm="True" meta:resourcekey="GridViewDataTextColumnResource9"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Width" Caption="Width" VisibleIndex="4"  ShowInCustomizationForm="True" meta:resourcekey="GridViewDataTextColumnResource10"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Height" Caption="Height" VisibleIndex="5"  ShowInCustomizationForm="True" meta:resourcekey="GridViewDataTextColumnResource11"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Length" Caption="Length" VisibleIndex="6"  ShowInCustomizationForm="True" meta:resourcekey="GridViewDataTextColumnResource12"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Wight" Caption="Wight" VisibleIndex="7"  ShowInCustomizationForm="True" meta:resourcekey="GridViewDataTextColumnResource13"></dx:GridViewDataTextColumn>

                                    <dx:GridViewDataImageColumn FieldName="ImageURL" Caption="Image" Width="50px" VisibleIndex="2"  ShowInCustomizationForm="True" meta:resourcekey="GridViewDataImageColumnResource1"></dx:GridViewDataImageColumn>

                                </Columns>
                            </dx:ASPxGridView>
                            <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT dbo.TripItems.ID, dbo.TripItems.TripID, dbo.TripItems.ItemDesc, dbo.TripItems.Width, dbo.TripItems.Height, dbo.TripItems.Length, dbo.TripItems.Wight, dbo.TripItems.NoOfUnits, dbo.TripItems.ImageURL, dbo.SubCategory.Name AS SubCategory, dbo.Categories.Name AS Category FROM dbo.TripItems INNER JOIN dbo.SubCategory ON dbo.TripItems.ItemSubCatID = dbo.SubCategory.ID INNER JOIN dbo.Categories ON dbo.TripItems.ItemCatID = dbo.Categories.ID WHERE (dbo.TripItems.TripID = @TripID)">
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
       <asp:SqlDataSource runat="server" ID="SqlDataSource10" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [ID], [Name] FROM [ItemStatus]"></asp:SqlDataSource>         
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [ID], [Name] FROM [Categories]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [ID], [Name] FROM [SubCategory]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [ID], [Name] FROM [Users]"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT   dbo.Trip.Name AS TripName, dbo.Trip.SourceLocationText, dbo.Trip.DeliveryLocationText, dbo.Trip.PicUpDate, dbo.Trip.DeliveryDate, DATEDIFF(hh, dbo.Trip.PicUpDate,dbo.Trip.DeliveryDate) AS Ending, dbo.Trip.ID, dbo.TripItems.ItemCatID, dbo.TripItems.ItemSubCatID, dbo.Trip.UserID, ACOS(SIN(dbo.Trip.SourceLat) * SIN(dbo.Trip.DestLat) + COS(dbo.Trip.SourceLat) * COS(dbo.Trip.DestLat) * COS(dbo.Trip.DestLag - dbo.Trip.DestLag)) AS Dis, dbo.Trip.Puplished FROM dbo.Trip INNER JOIN dbo.TripItems ON dbo.Trip.ID = dbo.TripItems.ID WHERE (dbo.Trip.Puplished <> 1) ORDER BY dbo.Trip.PicUpDate DESC, dbo.Trip.Puplished"></asp:SqlDataSource>
</asp:Content>
