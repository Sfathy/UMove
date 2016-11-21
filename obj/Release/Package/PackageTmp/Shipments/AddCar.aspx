<%@ Page Title="" Language="C#" MasterPageFile="~/Shipments/Site.Master" AutoEventWireup="true" CodeBehind="AddCar.aspx.cs" Inherits="UMoveNew.Shipments.AddCar" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<%$ Resources:form.css %>" rel="stylesheet" type="text/css"  runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="counters">
        <div class="container">
            <div class="row">
                <div class="form-style-10">
                    <div class="section"><span>1</span></div>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" CssClass="asplab" runat="server" Text="Car Type & Model" meta:resourcekey="Label1Resource1" ></asp:Label>
                    <div class="inner-wrap">
                        <label>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-6">
                            <asp:TextBox ID="txtCarType" runat="server" placeholder="Car Type" required meta:resourcekey="txtCarTypeResource1" ></asp:TextBox>
                                        </div>
                                    <div class="col-md-6">
                            <asp:TextBox ID="txtCarModel" runat="server" placeholder="Car Model" required meta:resourcekey="txtCarModelResource1" ></asp:TextBox>
                                        </div>
                                    </div>
                                </div></label>
                    
                    </div>
                             <div class="section"><span>2</span></div>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label2" CssClass="asplab" runat="server" Text="Year & Status" meta:resourcekey="Label2Resource1" ></asp:Label>
                    <div class="inner-wrap">
                        <label>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-6">
                            <asp:TextBox ID="txtYear" runat="server" placeholder="Year" TextMode="Number" required meta:resourcekey="txtYearResource1" ></asp:TextBox>
                                        </div>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlStatus" runat="server" required meta:resourcekey="ddlStatusResource1">
                                            <asp:ListItem Value="0" meta:resourcekey="ListItemResource1">Choose Status</asp:ListItem>
                                            <asp:ListItem meta:resourcekey="ListItemResource2">Excellent</asp:ListItem>
                                            <asp:ListItem meta:resourcekey="ListItemResource3">Very Good</asp:ListItem>
                                            <asp:ListItem meta:resourcekey="ListItemResource4">Good</asp:ListItem>
                                            <asp:ListItem meta:resourcekey="ListItemResource5">Bad</asp:ListItem>
                                            <asp:ListItem meta:resourcekey="ListItemResource6">Very Bad</asp:ListItem>
                                        </asp:DropDownList>
                                        </div>
                                    </div>
                                </div></label>
                    
                    </div>
                        <div class="section"><span>3</span></div>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label3" CssClass="asplab" runat="server" Text="Number OF Seats & Max Width" meta:resourcekey="Label3Resource1" ></asp:Label>
                    <div class="inner-wrap">
                        <label>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-6">
                            <asp:TextBox ID="txtNumOFSeats" runat="server" placeholder="Number OF Seats" TextMode="Number" required meta:resourcekey="txtNumOFSeatsResource1" ></asp:TextBox>
                                        </div>
                                    <div class="col-md-6">
                                         <asp:TextBox ID="txtMaxWidth" runat="server" placeholder="Max Width" TextMode="Number" required meta:resourcekey="txtMaxWidthResource1" ></asp:TextBox>
                                        </div>
                                    </div>
                                </div></label>
                    
                    </div>
                    <div class="section"><span>4</span></div>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label4" CssClass="asplab" runat="server" Text="hight & Active" meta:resourcekey="Label4Resource1" ></asp:Label>
                    <div class="inner-wrap">
                        <label>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-6">
                            <asp:TextBox ID="txthight" runat="server" placeholder="hight" TextMode="Number" required meta:resourcekey="txthightResource1" ></asp:TextBox>
                                        </div>
                                    <div class="col-md-6">
                                        <asp:RadioButtonList ID="rblActive" runat="server" meta:resourcekey="rblActiveResource1">
                                            <asp:ListItem Value="1" Selected="True" meta:resourcekey="ListItemResource7">Active</asp:ListItem>
                                            <asp:ListItem Value="0" meta:resourcekey="ListItemResource8">Inactive</asp:ListItem>
                                        </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div></label>
                    
                    </div>
                      <div class="button-section">
                        <asp:Button runat="server" ID="btnsave" type="submit" Text="Save" OnClick="btnsave_Click" meta:resourcekey="btnsaveResource1" />
                    </div>
                    </div>
                </div>
            </div>
         </div>
</asp:Content>
