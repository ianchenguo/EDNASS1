<%@ Page Title="" Language="C#" MasterPageFile="~/DoctorFeatures/DoctorFeatures.master" AutoEventWireup="true" 
    CodeBehind="DoctorRegisterPackage.aspx.cs" Inherits="ENETCare.Presentation.DoctorFeatures.DoctorRegisterPackage" %>

<asp:Content ID="DoctorRigsContent" ContentPlaceHolderID="SpecificDoctorFeatureMainContent" runat="server">
    <!--panel-start-->
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Register Medication Package</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">
            <div class="form-horizontal col-sm-10 col-sm-offset-1">
                <div class="form-group" runat="server">
                    <asp:Label runat="server" Text="Medication Type: " AssociatedControlID="DoctorRegisterPackageTypeDropDownList" CssClass="col-xs-3"></asp:Label>

                    <div class="col-xs-9">
                        <%--<input class="form-control" id="ned-package-register-form-type" type="text"
                            placeholder="Package Type" />--%>
                        <asp:DropDownList ID="DoctorRegisterPackageTypeDropDownList" runat="server">
                            <asp:ListItem>Please select</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" Text="Expiration Date: " AssociatedControlID="DoctorRegisterPackageFormExpireDateTextBox" CssClass="col-xs-3"></asp:Label>

                    <div class="col-xs-9">
                        <asp:TextBox ID="DoctorRegisterPackageFormExpireDateTextBox" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="DoctorRegisterPackageFormExpireDateTextBox"
                            CssClass="text-danger" ErrorMessage="The Expiration Date field is required." />
                    </div>
                </div>

                <%--<div class="form-group">
                    <label for="ned-package-register-form-value" class="col-xs-3">Value (AUD)</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-register-form-value" type="text"
                            placeholder="Value in AUD" />
                    </div>
                </div>--%>
                <!-- the following link should be optimised -->
                <p>
                    <asp:Label ID="DoctorRegisterMessage" runat="server" />
                </p>
                <a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="DoctorHome.aspx">Cancel</a>
                <asp:Button ID="DoctorRegisterButton" runat="server" OnClick="DoctorRegisterButton_Click"
                    Text="Doctor Register" CssClass="btn btn-success btn-float-right" />

            </div>
        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->
</asp:Content>