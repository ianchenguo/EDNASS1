<%@ Page Title="" Language="C#" MasterPageFile="~/AgentDoctorFeatures/AgentDoctorFeatures.master" AutoEventWireup="true" 
    CodeBehind="AgentDoctorReceivePackage.aspx.cs" Inherits="ENETCare.Presentation.AgentDoctorFeatures.AgentDoctorReceivePackage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SpecificAgentDoctorFeatureMainContent" runat="server">
    <!--panel-start-->
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Receive Medication Package</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">

            <div class="form-horizontal col-sm-10 col-sm-offset-1" runat="server">

                <div class="form-group col-xs-12">
                    <asp:Label AssociatedControlID="AgentDoctorReceivePackagesBarcode" runat="server" Text="Barcode:&nbsp"></asp:Label>
                    <asp:TextBox ID="AgentDoctorReceivePackagesBarcode" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="AgentDoctorReceivePackagesBarcode"
                            CssClass="text-danger" Display="Dynamic"
                            ErrorMessage="<div>The Barcode field is required.</div>"
                            ValidationGroup="AgentDoctorReceivePackageValidateGroup" />

                        <asp:RegularExpressionValidator
                            runat="server"
                            ValidationExpression="\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d"
                            ControlToValidate="AgentDoctorReceivePackagesBarcode"
                            CssClass="text-danger"
                            ErrorMessage="<div>The Barcode address is invalid.</div>"
                            ValidationGroup="AgentDoctorReceivePackageValidateGroup" />
                </div>
                <!-- the following link should be optimised -->
                <a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="AgentDoctorHome.aspx">Cancel</a>
                <%--<asp:Button ID="" runat="server" OnClick="AgentDoctorReceiveButton_Click" Text="Receive" class="btn btn-success btn-float-right" />--%>
                <asp:Button ID="AgentDoctorReceivePackageButton" runat="server" Text="Receive" 
                    CssClass="btn btn-success btn-float-right" OnClick="AgentDoctorReceivePackageButton_Click" ValidationGroup="AgentDoctorReceivePackageValidateGroup"/>

            </div>
        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->

</asp:Content>
