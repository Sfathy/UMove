<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Admin.Master" AutoEventWireup="true" CodeBehind="TripDetails.aspx.cs" Inherits="UMoveNew.Administrator.TripDetails" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="<%$ Resources:form.css %>" rel="stylesheet" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="form-style-10">
            <div class="section"><span>1</span></div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" CssClass="asplab" ID="Label20" Text="Trip Information" meta:resourcekey="Label20Resource1"></asp:Label>
            <div class="inner-wrap">
                <label>
                    <asp:Label ID="Label1" runat="server" Text="Shipment Title: " meta:resourcekey="Label1Resource1"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" ID="lblTitle" meta:resourcekey="lblTitleResource1"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" Text="Shipment ID:" meta:resourcekey="Label2Resource1"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" ID="lblID" meta:resourcekey="lblIDResource1"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label3" runat="server" Text="Customer:" meta:resourcekey="Label3Resource1"></asp:Label>
                    <asp:Label runat="server" ID="lblCustomer" meta:resourcekey="lblCustomerResource1"></asp:Label>
                </label>
                <hr />
                <label>
                    <asp:Label ID="Label4" runat="server" Text="PicUp Date:" meta:resourcekey="Label4Resource1"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" ID="lblPicUpDate" meta:resourcekey="lblPicUpDateResource1"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label5" runat="server" Text="Delivery Date :" meta:resourcekey="Label5Resource1"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" ID="lblDeliveryDate" meta:resourcekey="lblDeliveryDateResource1"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        
                </label>
                <hr />
                <label>
                    <asp:Label ID="Label6" runat="server" Text=" Budget:" meta:resourcekey="Label6Resource1"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" ID="lblBudget" meta:resourcekey="lblBudgetResource1"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label7" runat="server" Text=" Low Bid:" meta:resourcekey="Label7Resource1"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" ID="lbllowbid" meta:resourcekey="lbllowbidResource1"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label8" runat="server" Text="  # of Bids:" meta:resourcekey="Label8Resource1"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" ID="lblnumbid" meta:resourcekey="lblnumbidResource1"></asp:Label>
                </label>
                <hr />
                <label>
                    <asp:Label ID="Label9" runat="server" Text="Origin :" meta:resourcekey="Label9Resource1"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" ID="lblOrigin" meta:resourcekey="lblOriginResource1"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label17" runat="server" Text=" Destination:" meta:resourcekey="Label17Resource1"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" ID="lblDestination" meta:resourcekey="lblDestinationResource1"></asp:Label>
                </label>
            </div>
            <div class="section"><span>2</span></div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label19" CssClass="asplab" runat="server" Text="Trip Items" meta:resourcekey="Label19Resource1"></asp:Label>
            <div class="inner-wrap">
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="PlasticBlue" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EnableTheming="True" KeyFieldName="ID" Width="100%" meta:resourcekey="ASPxGridView1Resource1">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="ID" Caption="ID" ReadOnly="True" VisibleIndex="0" Visible="false" meta:resourcekey="GridViewDataTextColumnResource1">
                            <EditFormSettings Visible="False"></EditFormSettings>
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataTextColumn FieldName="TripID" Caption="Trip  ID" VisibleIndex="1" Visible="false" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ItemDesc" Caption="Description" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>

                        <dx:GridViewDataImageColumn FieldName="ImageURL" Caption="Image" VisibleIndex="2" meta:resourcekey="GridViewDataImageColumnResource1"></dx:GridViewDataImageColumn>
                    </Columns>
                </dx:ASPxGridView>
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT * FROM [TripItems] WHERE ([TripID] = @TripID)">
                    <SelectParameters>
                        <asp:QueryStringParameter QueryStringField="id" Name="TripID" Type="Int32"></asp:QueryStringParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
              <div class="button-section">
            <asp:Button runat="server" ID="btnaccept" type="submit" Text="Accept" meta:resourcekey="btnacceptResource" OnClick="btnaccept_Click" />
        </div>
        </div>
      
    </div>

</asp:Content>
