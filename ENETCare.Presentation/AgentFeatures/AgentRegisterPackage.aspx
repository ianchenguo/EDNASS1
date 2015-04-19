﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AgentFeatures/AgentFeatures.master" AutoEventWireup="true" 
    CodeBehind="AgentRegisterPackage.aspx.cs" Inherits="ENETCare.Presentation.AgentFeatures.AgentRegisterPackage" %>

<asp:Content ID="PackageRegistration" ContentPlaceHolderID="SpecificAgentFeatureMainContent" runat="server">
    <!--panel-start-->
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Agent Register Medication Package</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">
            <div class="form-horizontal col-sm-10 col-sm-offset-1">



                <div class="form-group" runat="server">
                    <%--                    <label for="ned-package-register-form-type" class="col-xs-3">Package Type</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-register-form-type" type="text"
                            placeholder="Package Type" />
                    </div>--%>

                    <asp:Label runat="server" AssociatedControlID="AgentPackageRegisterPackageTypeDropDwonList" CssClass="col-xs-3">Medication Type: </asp:Label>

                    <div class="col-xs-9">
                        <%--<asp:TextBox runat="server" ID="NedPackageRegisterFormPackageType" CssClass="form-control" TextMode="SingleLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="NedPackageRegisterFormPackageType"
                            CssClass="text-danger" ErrorMessage="The Package Type field is required." />--%>
                        <asp:DropDownList ID="AgentPackageRegisterPackageTypeDropDwonList" runat="server">
                            <asp:ListItem>Please select</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <br />

                <div class="form-group">
                    <%--                    <label for="ned-package-register-form-expire-date" class="col-xs-3">Expiration Date</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-register-form-expire-date" type="date" />
                    </div>--%>
                    <asp:Label runat="server" AssociatedControlID="NedPackageRegisterFormExpireDate" CssClass="col-xs-3">Expiration Date: </asp:Label>

                    <div class="col-xs-9">
                        <asp:TextBox ID="NedPackageRegisterFormExpireDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="NedPackageRegisterFormExpireDate"
                            CssClass="text-danger" ErrorMessage="The Expiration Date field is required." />
                    </div>
                </div>

                <%--<div class="form-group">
                                        <label for="ned-package-register-form-value" class="col-xs-3">Value (AUD)</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-register-form-value" type="text"
                            placeholder="Value in AUD" />
                    </div>

                    <asp:Label runat="server" AssociatedControlID="NedPackageRegisterFormValue" CssClass="col-xs-3">Value</asp:Label>

                    <div class="col-xs-9">
                        <asp:TextBox runat="server" ID="NedPackageRegisterFormValue" CssClass="form-control" TextMode="Number" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="NedPackageRegisterFormValue"
                            CssClass="text-danger" ErrorMessage="The Value field is required." />
                    </div>
                </div>--%>
                <!-- the following link should be optimised -->
                <p>
                    &nbsp;</p>
                <p>
                    <asp:Label ID="AgentRegisterMessage" runat="server" />
                    <asp:Image ID="AgentRegisterBarcodeImage" runat="server" />
                </p>
                <a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="AgentHome.aspx">Cancel</a>
                <%--<asp:Button ID="NedPackageRegisterSubmit" runat="server" OnClick="Submit" Text="Submit" CssClass="btn btn-success btn-float-right" />--%>
                <asp:Button ID="AgentRegisterButton" runat="server" OnClick="AgentRegisterButton_Click"
                    Text="Agent Register" CssClass="btn btn-success btn-float-right" />
            </div>
        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->
</asp:Content>
