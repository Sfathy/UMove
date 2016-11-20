<%@ Page Title="" Language="C#" MasterPageFile="~/Shipments/Site.Master" AutoEventWireup="true" CodeBehind="BidEdit.aspx.cs" Inherits="UMoveNew.Shipments.BidEdit" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


     <link href="<%$ Resources:form.css %>" rel="stylesheet" type="text/css"  runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="form-style-10">
                <h1><asp:Label ID="Label6"  runat="server" Text="Update Bid " meta:resourcekey="Label6Resource1"></asp:Label></h1>
                <div class="section"><span>1</span></div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:Label ID="Label1" CssClass="asplab" runat="server" Text="Trip Name" meta:resourcekey="Label1Resource1"></asp:Label>
                <div class="inner-wrap">

                    <asp:Label ID="lblTripName" runat="server" meta:resourcekey="lblTripNameResource1"></asp:Label>
                </div>

                <div class="section"><span>2</span> </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:Label ID="Label2" CssClass="asplab" runat="server" Text="Price & Track Type" meta:resourcekey="Label2Resource1"></asp:Label>
                <div class="inner-wrap">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <asp:TextBox ID="txtPrice" placeholde="Price" TextMode="Number" runat="server" meta:resourcekey="txtPriceResource1"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlTrackType" runat="server" meta:resourcekey="ddlTrackTypeResource1">
                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource1">Choose Track Type</asp:ListItem>
                                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource2">Larg Track</asp:ListItem>
                                    <asp:ListItem Value="2" meta:resourcekey="ListItemResource3">Mid Track</asp:ListItem>
                                    <asp:ListItem Value="3" meta:resourcekey="ListItemResource4">Small Track</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                     <div class="section"><span>3</span> </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" CssClass="asplab" runat="server" Text="Bid Expiration" meta:resourcekey="Label4Resource1"></asp:Label>
                <div class="inner-wrap">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:TextBox ID="txtBidExpiration" placeholde="Bid Expiration" runat="server" meta:resourcekey="txtBidExpirationResource1"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" TargetControlID="txtBidExpiration" runat="server" BehaviorID="CalendarExtender3" />
                        </div>
                    </div>
                </div>
                <div class="section"><span>4</span> </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" CssClass="asplab" runat="server" Text="PicUp Date & Delivery Date" meta:resourcekey="Label3Resource1"></asp:Label>
                <div class="inner-wrap">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <asp:TextBox ID="txtPicUp" placeholde="PicUp Date" runat="server" meta:resourcekey="txtPicUpResource1"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtPicUp" runat="server" BehaviorID="CalendarExtender1" />
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtDelivery" placeholde="Delivery Date" runat="server" meta:resourcekey="txtDeliveryResource1"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtDelivery" runat="server" BehaviorID="CalendarExtender2" />
                            </div>
                        </div>
                    </div>
                </div>
           
                <div class="section"><span>5</span> </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" CssClass="asplab" runat="server" Text="Note & Term Condition" meta:resourcekey="Label5Resource1"></asp:Label>
                <div class="inner-wrap">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <asp:TextBox ID="txtNote" placeholde="Note" TextMode="MultiLine" runat="server" meta:resourcekey="txtNoteResource1"></asp:TextBox>

                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtTerm" placeholde="Term Condition" TextMode="MultiLine" runat="server" meta:resourcekey="txtTermResource1"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                    <div class="button-section">
                    <asp:Button runat="server" ID="btnNext" CssClass="btn btn-primary" Text="Update" OnClick="btnNext_Click" meta:resourcekey="btnNextResource1"  />
                </div>
            </div>



        </div>
    </div>
</asp:Content>
