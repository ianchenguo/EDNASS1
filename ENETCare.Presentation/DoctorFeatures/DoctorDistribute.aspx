<%@ Page Title="" Language="C#" MasterPageFile="~/AgentDoctorFeatures/AgentDoctorFeatures.master" AutoEventWireup="true" CodeBehind="DoctorDistribute.aspx.cs" Inherits="ENETCare.Presentation.DoctorFeatures.DoctorDistribute" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SpecificAgentDoctorFeatureMainContent" runat="server">
    <!--panel-start-->
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Distribute Medication Package</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">
            <div class="form-horizontal col-sm-10 col-sm-offset-1" runat="server">

                <div runat="server" id="DoctorDistributeAlertWindowDiv" visible="false" class="alert alert-success" data-dismiss="alert">
                    <asp:Label ID="DoctorDistributeAlertWindowContentLabel" runat="server" />
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="DoctorDistributePackageTypebarcode" CssClass="col-xs-3">Barcode: </asp:Label>

                    <div class="col-xs-9">
                        <asp:TextBox ID="DoctorDistributePackageTypebarcode" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="DoctorDistributePackageTypebarcode"
                            CssClass="text-danger" Display="Dynamic"
                            ErrorMessage="<div>The Barcode field is required.</div>"
                            ValidationGroup="DoctorDistributePackageValiGroup" />

                        <asp:RegularExpressionValidator
                            runat="server"
                            ValidationExpression="\d{18}$"
                            ControlToValidate="DoctorDistributePackageTypebarcode"
                            CssClass="text-danger"
                            ErrorMessage="<div>The Barcode is invalid.</div>"
                            ValidationGroup="DoctorDistributePackageValiGroup" />
                    </div>
                </div>

                <!-- the following link should be optimised -->
                <%--<a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="~/AgentDoctorFeatures/AgentDoctorHome.aspx">Cancel</a>--%>
                <asp:LinkButton ID="DoctorDistributeLinkButton" Text="Cancle" runat="server" CssClass="btn btn-danger btn-float-right btn-margin-left" OnClick="DoctorDistributeLinkButton_Click" />
                <asp:Button ID="DoctorDistributePackageTypeButton" runat="server" OnClick="DoctorDistributePackageTypeButton_Click"
                    Text="Distribute" CssClass="btn btn-success btn-float-right" ValidationGroup="DoctorDistributePackageValiGroup" />
            </div>
        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->
</asp:Content>
