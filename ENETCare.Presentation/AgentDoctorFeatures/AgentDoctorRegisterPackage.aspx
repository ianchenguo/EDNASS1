<%@ Page Title="" Language="C#" MasterPageFile="~/AgentDoctorFeatures/AgentDoctorFeatures.master" AutoEventWireup="true" 
    CodeBehind="AgentDoctorRegisterPackage.aspx.cs" Inherits="ENETCare.Presentation.AgentDoctorFeatures.AgentDoctorRegisterPackage" %>

<asp:Content ID="PackageRegistration" ContentPlaceHolderID="SpecificAgentDoctorFeatureMainContent" runat="server">
    <!--panel-start-->
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">AgentDoctor Register Medication Package</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">
            <div class="form-horizontal col-sm-10 col-sm-offset-1">



                <div class="form-group" runat="server">

                    <asp:Label runat="server" AssociatedControlID="AgentDoctorPackageRegisterPackageTypeDropDwonList" CssClass="col-xs-3">Medication Type: </asp:Label>

                    <div class="col-xs-9">
                        <asp:DropDownList ID="AgentDoctorPackageRegisterPackageTypeDropDwonList" runat="server">
                            <asp:ListItem>Please select</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <br />

                <div class="form-group">

                    <asp:Label runat="server" AssociatedControlID="NedPackageRegisterFormExpireDate" CssClass="col-xs-3">Expiration Date: </asp:Label>

                    <div class="col-xs-9">
                        <asp:TextBox ID="NedPackageRegisterFormExpireDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="NedPackageRegisterFormExpireDate"
                            CssClass="text-danger" ErrorMessage="The Expiration Date field is required." />
                    </div>
                </div>
                <p>
                    &nbsp;</p>
                <p>
                    <asp:Label ID="AgentDoctorRegisterMessage" runat="server" />
                    <asp:Image ID="AgentDoctorRegisterBarcodeImage" runat="server" />
                </p>
                <a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="AgentDoctorHome.aspx">Cancel</a>
                <%--<asp:Button ID="NedPackageRegisterSubmit" runat="server" OnClick="Submit" Text="Submit" CssClass="btn btn-success btn-float-right" />--%>
                <asp:Button ID="AgentDoctorRegisterButton" runat="server" OnClick="AgentDoctorRegisterButton_Click"
                    Text="Register" CssClass="btn btn-success btn-float-right" />
            </div>
        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->
</asp:Content>
