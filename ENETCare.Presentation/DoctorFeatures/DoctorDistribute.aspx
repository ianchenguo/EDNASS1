﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AgentDoctorFeatures/AgentDoctorFeatures.master" AutoEventWireup="true" CodeBehind="DoctorDistribute.aspx.cs" Inherits="ENETCare.Presentation.DoctorFeatures.DoctorDistribute" %>
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

                <div class="form-group col-xs-12">
                    <%--<asp:Label ID="DoctorDistributePackageDestination" runat="server" Text="Destination: "></asp:Label>

                    <asp:DropDownList ID="DoctorDistributeDropDownList" runat="server">
                        <asp:ListItem>Please Select</asp:ListItem>
                    </asp:DropDownList>--%>
                    Barcode:
                        <asp:TextBox ID="DoctorDistributePackageTypebarcode" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="DoctorDistributePackageTypebarcode"
                            CssClass="text-danger" Display="Dynamic"
                            ErrorMessage="<div>The Barcode field is required.</div>"
                            ValidationGroup="DoctorDistributePackageValiGroup" />

                        <asp:RegularExpressionValidator
                            runat="server"
                            ValidationExpression="\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d"
                            ControlToValidate="DoctorDistributePackageTypebarcode"
                            CssClass="text-danger"
                            ErrorMessage="<div>The Barcode address is invalid.</div>"
                            ValidationGroup="DoctorDistributePackageValiGroup" />
                </div>

                <%--<div class="form-group">
                    <asp:Label AssociatedControlID="DoctorDistributePackageDateTextBox" runat="server" Text="Distribute Date: " CssClass="col-xs-3"></asp:Label>

                    <div class="col-xs-9">
                        <asp:TextBox ID="DoctorDistributePackageDateTextBox" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>--%>

                <!-- the following link should be optimised -->
                <%--<a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="~/AgentDoctorFeatures/AgentDoctorHome.aspx">Cancel</a>--%>
                <asp:LinkButton ID="DoctorDistributeLinkButton" Text="Cancle" runat="server" CssClass="btn btn-danger btn-float-right btn-margin-left" OnClick="DoctorDistributeLinkButton_Click" />
                <asp:Button ID="DoctorDistributePackageTypeButton" runat="server" OnClick="DoctorDistributePackageTypeButton_Click"
                    Text="Doctor Distribute" CssClass="btn btn-success btn-float-right" ValidationGroup="DoctorDistributePackageValiGroup" />
            </div>
        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->
</asp:Content>
