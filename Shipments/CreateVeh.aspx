<%@ Page Title="" Language="C#" MasterPageFile="~/Shipments/site.Master" AutoEventWireup="true" CodeBehind="CreateVeh.aspx.cs" Inherits="UMoveNew.Shipments.CreateVeh" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="<%$ Resources:form.css %>" rel="stylesheet" type="text/css"  runat="server" />
    <link href='http://fonts.googleapis.com/css?family=Bitter' rel='stylesheet' type='text/css' />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script type="text/javascript">

        function showpreview(input) {

            if (input.files && input.files[0]) {

                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imgpreview').css('visibility', 'visible');
                    $('#imgpreview').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="form-style-10">
              <div class="section"><span>1</span></div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1"  CssClass="asplab" runat="server" Text="Add Item" meta:resourcekey="Label1Resource1"  ></asp:Label>
            <div class="inner-wrap">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-6">
                            <div class="col-md-4">

                                <asp:Label ID="lblDescription" runat="server" Text="Description" meta:resourcekey="lblDescriptionResource1"></asp:Label>
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" placeholder="Description" meta:resourcekey="txtDescriptionResource1"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="col-md-3">
                                <asp:Label ID="lblImage" runat="server" Text="Image" meta:resourcekey="lblImageResource1"></asp:Label>
                            </div>
                            <div class="col-md-9">
                                <div class="col-md-3">
                                    <img id="imgpreview" height="100" width="100" src="" style="border-width: 0px; visibility: hidden;" />
                                </div>
                                <div class="col-md-6">
                                    <asp:FileUpload ID="FileUpload1" runat="server" OnLoad="FileUpload1_Load" onchange="showpreview(this);" meta:resourcekey="FileUpload1Resource1" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="lbldimensions" runat="server" Text="Dimensions" Visible="False" meta:resourcekey="lbldimensionsResource1"></asp:Label>
                    </div>
                    <hr />
                </div>
                <div class="row">
                    <div class="col-md-12">

                        <div class="col-md-2">
                            <asp:Label ID="lblLength" runat="server" Text="Length" Visible="False" meta:resourcekey="lblLengthResource1"></asp:Label>

                        </div>
                        <div class="col-md-8">
                            <div class="col-md-3">
                                <asp:TextBox ID="txtLength" runat="server" placeholder="m" Visible="False" meta:resourcekey="txtLengthResource1"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtLength2" runat="server" placeholder="cm" Visible="False" meta:resourcekey="txtLength2Resource1"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">

                        <div class="col-md-2">
                            <asp:Label ID="lblWidth" runat="server" Text="Width" Visible="False" meta:resourcekey="lblWidthResource1"></asp:Label>

                        </div>
                        <div class="col-md-8">
                            <div class="col-md-3">
                                <asp:TextBox ID="txtWidth" runat="server" placeholder="m" Visible="False" meta:resourcekey="txtWidthResource1"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtWidth2" runat="server" placeholder="cm" Visible="False" meta:resourcekey="txtWidth2Resource1"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">

                        <div class="col-md-2">
                            <asp:Label ID="lblHeight" runat="server" Text="Height" Visible="False" meta:resourcekey="lblHeightResource1"></asp:Label>

                        </div>
                        <div class="col-md-8">
                            <div class="col-md-3">
                                <asp:TextBox ID="txtHeight" runat="server" placeholder="m" Visible="False" meta:resourcekey="txtHeightResource1"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtHeight2" runat="server" placeholder="cm" Visible="False" meta:resourcekey="txtHeight2Resource1"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">

                        <div class="col-md-2">
                            <asp:Label ID="lblWeight" runat="server" Text="Weight" Visible="False" meta:resourcekey="lblWeightResource1"></asp:Label>

                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtWeight" runat="server" placeholder="kg" Visible="False" meta:resourcekey="txtWeightResource1"></asp:TextBox>

                        </div>

                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-lg-4"></div>
                        <div class="col-lg-4">
                            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Add" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />

                        </div>
                    </div>
                </div>
                <hr />
                </div>
                              <div class="section"><span>2</span></div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3"  CssClass="asplab" runat="server" Text="Items" meta:resourcekey="Label3Resource1" ></asp:Label>
                <div class="inner-wrap">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Width="100%" OnRowDeleting="RowDeleting" DataMember="ID" meta:resourcekey="GridView1Resource1">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Delete" ShowHeader="False" meta:resourcekey="TemplateFieldResource1">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CssClass="btn btn-danger" CommandName="Delete" Text="Delete" meta:resourcekey="LinkButton1Resource1"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID" Visible="false" meta:resourcekey="TemplateFieldResource2">

                                <ItemTemplate>

                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' meta:resourcekey="lblIDResource1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Item Description" SortExpression="ItemDesc" meta:resourcekey="TemplateFieldResource3">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ItemDesc") %>' meta:resourcekey="TextBox1Resource1"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Image ID="Image1" Width="100px" Height="100px" runat="server" ImageUrl='<%# Eval("ImageURL") %>' meta:resourcekey="Image1Resource1" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("ItemDesc") %>' Font-Size="X-Large" meta:resourcekey="Label2Resource1"></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>


                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>

                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [ID], [ItemDesc], [ImageURL] FROM [TripItems]"></asp:SqlDataSource>
                </div>

                <div class="button-section">
                    <asp:Button runat="server" ID="btnNext" CssClass="btn btn-primary" Text="Continue" OnClick="btnNext_Click" meta:resourcekey="btnNextResource1" />
                </div>
            </div>


        </div>
    
    
</asp:Content>
