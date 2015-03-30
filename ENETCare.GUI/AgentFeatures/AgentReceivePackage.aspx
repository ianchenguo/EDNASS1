<%@ Page Title="" Language="C#" MasterPageFile="~/AgentFeatures/AgentFeatures.master" AutoEventWireup="true" CodeBehind="AgentReceivePackage.aspx.cs" Inherits="ENETCare.GUI.AgentFeatures.AgentReceivePackage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SpecificAgentFeatureMainContent" runat="server">
    <!--panel-start-->
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Receive Medication Package</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">

            <form class="form-horizontal col-sm-10 col-sm-offset-1" action="">

                <div class="form-group">
                    <label for="ned-package-receive-form-from" class="col-xs-3">From</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-receive-form-from" type="text"
                            placeholder="From" disabled />
                    </div>
                </div>

                <div class="form-group">
                    <label for="ned-package-receive-form-type" class="col-xs-3">Package Type</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-receive-form-type" type="text"
                            placeholder="Package Type" disabled />
                    </div>
                </div>

                <div class="form-group">
                    <label for="ned-package-receive-form-expire-date" class="col-xs-3">Expiration Date</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-receive-form-expire-date" type="date" disabled />
                    </div>
                </div>

                <div class="form-group">
                    <label for="ned-package-receive-form-value" class="col-xs-3">Value (AUD)</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-receive-form-value" type="text"
                            placeholder="Value in AUD" disabled />
                    </div>
                </div>

                <div class="form-group">
                    <label for="ned-package-receive-form-barcode" class="col-xs-3">Package Barcode</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-receive-form-barcode" type="text"
                            placeholder="Package Barcode" />
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
