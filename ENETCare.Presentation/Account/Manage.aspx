<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/layout/Main.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="ENETCare.Presentation.Account.Manage" %>

<%--<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>--%>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>

    <div class="row">
        <div class="col-md-12">
            <section id="passwordForm">

                <asp:PlaceHolder runat="server" ID="ChangeInfoHolder">
                    <p>You're logged in as <strong><%: User.Identity.GetUserName() %></strong>.</p>
                    <div class="form-horizontal">

                        <h4>Change Account Information Form</h4>
                        <hr />
                        <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="FullName" CssClass="col-md-2 control-label">Full Name</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="FullName" CssClass="form-control" TextMode="SingleLine" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="FullName"
                                    CssClass="text-danger" ErrorMessage="The Full Name field is required."
                                    ValidationGroup="ChangeInfo" />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="SingleLine" />
                                <asp:RequiredFieldValidator 
                                    runat="server" 
                                    ControlToValidate="Email"
                                    CssClass="text-danger" 
                                    Display="Dynamic"
                                    ErrorMessage="The email field is required."
                                    ValidationGroup="ChangeInfo" />

                                <asp:RegularExpressionValidator 
                                    runat="server"
                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ControlToValidate="Email"
                                    CssClass="text-danger"
                                    ErrorMessage="The email address is invalid."
                                    ValidationGroup="ChangeInfo" />

                            </div>
                        </div>

                        <div class="form-group" id="FormControlDistributionCentre" runat="server">
                            <asp:Label runat="server" AssociatedControlID="DistributionCentre" CssClass="col-md-2 control-label">Distribution Centre</asp:Label>
                            <div class="col-md-10">

                                <asp:DropDownList ID="DistributionCentre"
                                    CssClass="form-control"
                                    runat="server"
                                    DataSourceID="DistributionCentreSource"
                                    DataTextField="Name"
                                    DataValueField="ID"
                                    OnPreRender="DistributionCentre_PreRender">
                                </asp:DropDownList>

                                <asp:ObjectDataSource runat="server"
                                    ID="DistributionCentreSource"
                                    SelectMethod="GetDistributionCentreList"
                                    TypeName="ENETCare.Business.DistributionCentreBLL"></asp:ObjectDataSource>

                                <asp:RequiredFieldValidator runat="server" ControlToValidate="DistributionCentre" Enabled="false"
                                    CssClass="text-danger" ErrorMessage="The Distribution Centre field is required."
                                    ValidationGroup="ChangeInfo" />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword" CssClass="col-md-2 control-label">Current password</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="CurrentPassword" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                                    CssClass="text-danger" ErrorMessage="The current password field is required."
                                    ValidationGroup="ChangeInfo" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword" CssClass="col-md-2 control-label">New password</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword"
                                    CssClass="text-danger" ErrorMessage="The new password is required."
                                    ValidationGroup="ChangeInfo" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword" CssClass="col-md-2 control-label">Confirm new password</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="ConfirmNewPassword" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Confirm new password is required."
                                    ValidationGroup="ChangeInfo" />
                                <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                    CssClass="text-danger" ErrorMessage="The new password and confirmation password do not match."
                                    ValidationGroup="ChangeInfo" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" Text="Change Account Info" ValidationGroup="ChangeInfo" OnClick="ChangeInfo_Click" CssClass="btn btn-default" />
                            </div>
                        </div>
                    </div>
                </asp:PlaceHolder>
            </section>
        </div>
    </div>

</asp:Content>
