<%@ Page Title="" Language="C#" MasterPageFile="~/AgentFeatures/AgentFeatures.master" AutoEventWireup="true" 
    CodeBehind="AgentSendPackage.aspx.cs" Inherits="ENETCare.GUI.AgentFeatures.AgentSendPackage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SpecificAgentFeatureMainContent" runat="server">
    <!--panel-start-->
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Send Medication Package</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">
            <form class="form-horizontal col-sm-10 col-sm-offset-1"  runat="server">

                <div class="form-group">
                    <label for="ned-package-send-form-dest" class="col-xs-3">Destination</label>

                    <div class="col-xs-9">

                        <asp:DropDownList ID="AgentSendingDropDownList" runat="server" OnSelectedIndexChanged="AgentSendingDropDownList_SelectedIndexChanged">
                            <asp:ListItem>Please Select</asp:ListItem>
                        </asp:DropDownList>
                        Barcode: <asp:TextBox ID="ASbarcode" runat="server"></asp:TextBox>

                    </div>
                </div>

                <div class="form-group">
                    <label for="ned-package-send-form-type" class="col-xs-3">Package Type</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-send-form-type" type="text"
                            placeholder="Package Type" />
                    </div>
                </div>

                <div class="form-group">
                    <label for="ned-package-send-form-expire-date" class="col-xs-3">Expiration Date</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-send-form-expire-date" type="date" />
                    </div>
                </div>

                <div class="form-group">
                    <label for="ned-package-send-form-value" class="col-xs-3">Value (AUD)</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-send-form-value" type="text"
                                placeholder="Value in AUD" />
                    </div>
                </div>

                <!-- the following link should be optimised -->
                <a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="AgentHome.aspx">Cancel</a>
                <asp:Button ID="ASbtnSending" runat="server" Text="Send" OnClick="ASsendingBTN_Click" class="btn btn-success btn-float-right"/>

            </form>
        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->

</asp:Content>
