<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/MagFeatures.master" AutoEventWireup="true" 
    CodeBehind="MagHORep.aspx.cs" Inherits="ENETCare.GUI.Manager.MagHORep" %>

<asp:Content ID="MagRepRho" ContentPlaceHolderID="SpecificMagFeatureMainContent" runat="server">
    <!--panel-start-->
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Head Office Report</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th>Package</th>
                        <th>Quantity</th>
                        <th>Unit</th>
                        <th>Value (AUD)</th>
                        <th>Location</th>
                        <th>State</th>
                        <th>Expiration Date</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>vaccinations</td>
                        <td>
                            <input type="text" name="quantityV" size="5" />
                        </td>
                        <td>polio</td>
                        <td>100</td>
                        <td>Headquarter</td>
                        <td>In stock</td>
                        <td>2020/01/01</td>
                        <td>
                            <button class="btn btn-warning">Discard</button>
                        </td>
                    </tr>
                    <tr class="warning">
                        <td>water purification kit</td>
                        <td>
                            <input type="text" name="quantityW" size="5" />
                        </td>
                        <td>kit</td>
                        <td>59.6</td>
                        <td>Headquarter</td>
                        <td>In stock</td>
                        <td>2015/03/15</td>
                        <td>
                            <button class="btn btn-danger">Remove</button>
                        </td>

                    </tr>
                    <tr class="danger">
                        <td>chloroquine pills</td>
                        <td>
                            <input type="text" name="quantityCP" size="5" />
                        </td>
                        <td>28 / pack</td>
                        <td>201</td>
                        <td>Headquarter</td>
                        <td>In stock</td>
                        <td>2001/01/01</td>
                        <td></td>
                    </tr>
                    <tr class="danger">
                        <td>Polyheme</td>
                        <td>
                            <input type="text" name="quantityP" size="5" />
                        </td>
                        <td>Liter</td>
                        <td>28.5</td>
                        <td>Headquarter</td>
                        <td>Lost</td>
                        <td>2020/01/01</td>
                        <td></td>
                    </tr>
                </tbody>
            </table>

            <!-- the following link should be optimised -->
            <a class="btn btn-success btn-float-right btn-margin-left" type="a" href="MagHOgenerated.aspx">Generate</a>
            <a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="MagHome.aspx">Cancel</a>

        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->

</asp:Content>