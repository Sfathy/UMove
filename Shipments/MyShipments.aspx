<%@ Page Title="" Language="C#" MasterPageFile="~/Shipments/Site.Master" AutoEventWireup="true" CodeBehind="MyShipments.aspx.cs" Inherits="UMoveNew.Shipments.MyShipments" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="counters">
        <div class="container">
            <div class="row">
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" Theme="Aqua" Width="100%" EnableCallBacks="False" meta:resourcekey="ASPxGridView1Resource1" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" OnStartRowEditing="ASPxGridView1_StartRowEditing">

                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="TripName" Caption="Trip Name" VisibleIndex="0" meta:resourcekey="GridViewDataTextColumnResource1"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="SourceLocationText" Caption="Source Location" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="DeliveryLocationText" Caption="Delivery Location" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="PicUpDate" Caption="PicUp Date" VisibleIndex="5" meta:resourcekey="GridViewDataDateColumnResource1"></dx:GridViewDataDateColumn>
                        <dx:GridViewDataDateColumn FieldName="DeliveryDate" Caption="Delivery Date" VisibleIndex="6" meta:resourcekey="GridViewDataDateColumnResource2"></dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="Ending" Caption="Ending" ReadOnly="True" VisibleIndex="7" meta:resourcekey="GridViewDataTextColumnResource4"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ID" Caption="ID" ReadOnly="True" VisibleIndex="8" Visible="false" meta:resourcekey="GridViewDataTextColumnResource5">
                            <EditFormSettings Visible="False"></EditFormSettings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="ItemCatID" Caption="Categoty" VisibleIndex="1" meta:resourcekey="GridViewDataComboBoxColumnResource1">
                            <PropertiesComboBox DataSourceID="SqlDataSource3" TextField="Name" ValueField="ID"></PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="ItemSubCatID" Caption="Sub Categoty" VisibleIndex="2" meta:resourcekey="GridViewDataComboBoxColumnResource2">
                                <PropertiesComboBox DataSourceID="SqlDataSource4" TextField="Name" ValueField="ID"></PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                       
                        <dx:GridViewCommandColumn Width="100px" ButtonType="Image" VisibleIndex="9" meta:resourcekey="GridViewCommandColumnResource1" ShowEditButton="True">
                            <CustomButtons>
                                <dx:GridViewCommandColumnCustomButton ID="btnBid" Text="Details" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                    <Image IconID="programming_showtestreport_16x16">
                                    </Image>
                                </dx:GridViewCommandColumnCustomButton>
                            </CustomButtons>
                        </dx:GridViewCommandColumn>
                       
                    </Columns>
                      <SettingsCommandButton>
                        <EditButton ButtonType="Image">
                            <Image IconID="edit_edit_16x16">
                            </Image>
                        </EditButton>
                          <UpdateButton>
                                <Image IconID="actions_apply_16x16">
                                </Image>
                            </UpdateButton>
                            <CancelButton>
                                <Image IconID="edit_delete_16x16">
                                </Image>
                            </CancelButton>
                    </SettingsCommandButton>
                      <Styles>
                        <Header Font-Bold="True" Font-Names="Berlin Sans FB Demi" Font-Overline="False" Font-Size="Larger" HorizontalAlign="Center">
                        </Header>
                        <Cell Font-Bold="True" Font-Names="Agency FB" Font-Size="Larger" HorizontalAlign="Center">
                        </Cell>
                    </Styles>
                    <SettingsDetail ShowDetailRow="True" />
                    <Templates>
                        <DetailRow>
                            <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" Theme="Aqua" DataSourceID="SqlDataSource2" KeyFieldName="ID" OnBeforePerformDataSelect="detailGrid_BeforePerformDataSelect" Width="100%" meta:resourcekey="ASPxGridView2Resource1">
                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="0"  Visible="False" meta:resourcekey="GridViewDataTextColumnResource6" ShowInCustomizationForm="True">
                                        <EditFormSettings Visible="False"></EditFormSettings>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="TripID" Caption="Trip ID" VisibleIndex="1"  Visible="False" meta:resourcekey="GridViewDataTextColumnResource7" ShowInCustomizationForm="True"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ItemDesc" Caption="Description" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource8" ShowInCustomizationForm="True"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Width" Caption="Width" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource9" ShowInCustomizationForm="True"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Height" Caption="Height" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource10" ShowInCustomizationForm="True"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Length" Caption="Length" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource11" ShowInCustomizationForm="True"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Wight" Caption="Wight" VisibleIndex="6" meta:resourcekey="GridViewDataTextColumnResource12" ShowInCustomizationForm="True"></dx:GridViewDataTextColumn>
                                   
                                   <dx:GridViewDataImageColumn FieldName="ImageURL" Caption="Image" Width="50px"   VisibleIndex="8" meta:resourcekey="GridViewDataImageColumnResource1" ShowInCustomizationForm="True"></dx:GridViewDataImageColumn>
                                    
                                </Columns>
                                  <Styles>
                        <Header Font-Bold="True" Font-Names="Berlin Sans FB Demi" Font-Overline="False" Font-Size="Larger" HorizontalAlign="Center">
                        </Header>
                        <Cell Font-Bold="True" Font-Names="Agency FB" Font-Size="Larger" HorizontalAlign="Center">
                        </Cell>
                    </Styles>
                            </dx:ASPxGridView>
                            <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT TripItems.ID, TripItems.TripID, TripItems.ItemDesc, TripItems.Width, TripItems.Height, TripItems.Length, TripItems.Wight, TripItems.NoOfUnits, TripItems.ImageURL, SubCategory.Name AS SubCategory, Categories.Name AS Category FROM TripItems INNER JOIN SubCategory ON TripItems.ID = SubCategory.ID INNER JOIN Categories ON TripItems.ID = Categories.ID 
Where TripItems.TripID=@TripID and Puplished=1
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
    

</asp:Content>
