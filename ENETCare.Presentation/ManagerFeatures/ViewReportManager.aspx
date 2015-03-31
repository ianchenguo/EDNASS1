<%@ Page Title="" Language="C#" MasterPageFile="~/ManagerFeatures/ManagerFeatures.master" AutoEventWireup="true" 
    CodeBehind="ViewReportManager.aspx.cs" Inherits="ENETCare.Presentation.ManagerFeatures.ViewReportManager" %>

<asp:Content ID="MagViewRep" ContentPlaceHolderID="SpecificMagFeatureMainContent" runat="server">
    <!--panel-start-->
    <div class="panel panel-success">
    	<!--panel-body-start-->
    	<div class="panel-body">
    		<span class="report-title">
    			Report_Title
    		</span>
    		<div class="report-content">
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
    						<th>Total Value</th>
    						<th>Total Lost</th>
    					</tr>
    				</thead>
    				<tbody>
    					<tr>
    						<td>vaccinations</td>
    						<td>100</td>
    						<td>polio</td>
    						<td>100</td>
    						<td>Headquarter</td>
    						<td>In stock</td>
    						<td>2020/01/01</td>
    						<td>10000</td>
    						<td>2000</td>
    					</tr>
    					<tr class="warning">
    						<td>water purification kit</td>
    						<td>1</td>
    						<td>kit</td>
    						<td>59.6</td>
    						<td>Headquarter</td>
    						<td>In stock</td>
    						<td>2015/03/15</td>
    						<td>59.6</td>
    						<td>0</td>
    					</tr>
    				</tbody>
    			</table>

    			<a href="ManagerHome.aspx" type="a">
                	<button class="btn btn-success btn-float-right" type="button">Done</button>
            	</a>
    		</div>
    		<!--panel-body-end-->
    	</div>
    	<!--panel-end-->
</asp:Content>
