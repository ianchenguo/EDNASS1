<%@ Page Title="" Language="C#" MasterPageFile="~/AgentDoctorFeatures/AgentDoctorFeatures.master" AutoEventWireup="true" 
    CodeBehind="AgentDoctorSendPackage.aspx.cs" Inherits="ENETCare.Presentation.AgentDoctorFeatures.AgentDoctorSendPackage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SpecificAgentDoctorFeatureMainContent" runat="server">
    <!--panel-start-->
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Send Medication Package</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">
            <div class="form-horizontal col-sm-10 col-sm-offset-1" runat="server">

                <div class="form-group col-xs-12">
                    <asp:Label ID="AgentDoctorSendPackageDestination" runat="server" Text="Destination: "></asp:Label>

                    <asp:DropDownList ID="AgentDoctorSendingDropDownList" runat="server">
                        <asp:ListItem>Please Select</asp:ListItem>
                    </asp:DropDownList>
                    Barcode:
                        <asp:TextBox ID="AgentDoctorSendPackageTypebarcode" runat="server" TextMode="SingleLine"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="AgentDoctorSendPackageTypebarcode"
                            CssClass="text-danger" Display="Dynamic"
                            ErrorMessage="<div>The Barcode field is required.</div>"
                            ValidationGroup="AgentDoctorSendPackageValidatePack" />

                        <asp:RegularExpressionValidator
                            runat="server"
                            ValidationExpression="\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d"
                            ControlToValidate="AgentDoctorSendPackageTypebarcode"
                            CssClass="text-danger"
                            ErrorMessage="<div>The Barcode address is invalid.</div>"
                            ValidationGroup="AgentDoctorSendPackageValidatePack" />
                </div>

                <%--<div class="form-group">
                    <asp:Label AssociatedControlID="AgentDoctorSendPackageDateTextBox" runat="server" Text="Send Date: " CssClass="col-xs-3"></asp:Label>

                    <div class="col-xs-9">
                        <asp:TextBox ID="AgentDoctorSendPackageDateTextBox" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>--%>

                <!-- the following link should be optimised -->
                <a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="AgentDoctorHome.aspx">Cancel</a>
                <asp:Button ID="AgentDoctorSendPackageTypeButton" runat="server" OnClick="AgentDoctorSendPackageTypeButton_Click"
                    Text="Send" CssClass="btn btn-success btn-float-right" ValidationGroup="AgentDoctorSendPackageValidatePack" />
            </div>
            <%--<div>
                <asp:GridView ID="SmpGV" runat="server"></asp:GridView>
            </div>--%>
        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->

</asp:Content>
