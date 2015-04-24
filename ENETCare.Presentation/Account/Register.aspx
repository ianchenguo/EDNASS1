<%@ Page Title="Register" Language="C#" MasterPageFile="~/layout/Main.Master" AutoEventWireup="true" 
    CodeBehind="Register.aspx.cs" Inherits="ENETCare.Presentation.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new account for testing purpose only.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Role" CssClass="col-md-2 control-label">Role</asp:Label>
            <div class="col-md-10">
                <div class="controls radio">
                    <asp:RadioButtonList ID="Role" 
                        runat="server" 
                        RepeatDirection="Vertical" 
                        AutoPostBack="True"
                        OnPreRender="Role_PreRender">
                        <asp:ListItem>Agent</asp:ListItem>
                        <asp:ListItem>Doctor</asp:ListItem>
                        <asp:ListItem>Manager</asp:ListItem>
                    </asp:RadioButtonList>
                </div>

                <asp:RequiredFieldValidator runat="server" ControlToValidate="Role"
                    CssClass="text-danger" ErrorMessage="The Role selection is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="FullName" CssClass="col-md-2 control-label">Full Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="FullName" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FullName"
                    CssClass="text-danger" ErrorMessage="The Full Name field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="DistributionCentre" CssClass="col-md-2 control-label">Distribution Centre</asp:Label>
            <div class="col-md-10">

                <asp:DropDownList ID="DistributionCentre"
                    CssClass="form-control"
                    runat="server" DataSourceID="DistributionCentreSource" DataTextField="Name" DataValueField="ID">
                </asp:DropDownList>


                <asp:ObjectDataSource runat="server" 
                    ID="DistributionCentreSource" 
                    SelectMethod="GetDistributionCentreList" 
                    TypeName="ENETCare.Business.DistributionCentreBLL">

                </asp:ObjectDataSource>

                <asp:RequiredFieldValidator runat="server" ControlToValidate="DistributionCentre" Enabled="false"
                    CssClass="text-danger" ErrorMessage="The Distribution Centre field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
