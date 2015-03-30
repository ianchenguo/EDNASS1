<%@ Page Title="" Language="C#" MasterPageFile="~/AgentFeatures/AgentFeatures.master" AutoEventWireup="true" CodeBehind="AccountEdit.aspx.cs" Inherits="ENETCare.GUI.AccountEdit.AccountEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SpecificAgentFeatureMainContent" runat="server">
    <!--panel-start-->
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Edit Account Info</h3>
        </div>
        <!--panel-heading-end-->

         <!--panel-body-start-->
        <div class="panel-body>
            <form class="form-horizontal col-sm-10 col-sm-offset-1" action="">
                <div class="form-group">
                    <label for="ned-package-register-form-type" class="col-xs-3">Name</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-register-form-type" type="text"
                            placeholder="Your name" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="ned-package-register-form-expire-date" class="col-xs-3">Password</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-acceditpassword-form-type" type="text" 
                            placeholder="Your password"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="ned-package-register-form-expire-date" class="col-xs-3">Email</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-acceditemail-form-type" type="text" 
                            placeholder="Your email"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="ned-package-register-form-expire-date" class="col-xs-3">Distribution Center</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-acceditdistricenter-form-type" type="text" 
                            placeholder="Distribution center location"/>
                    </div>
                </div>
                <!-- the following link should be optimised -->
                <a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="AgentHome.aspx">Cancel</a>
                <button class="btn btn-success btn-float-right" type="submit">Submit</button>
            </form>
        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->
    
</asp:Content>
