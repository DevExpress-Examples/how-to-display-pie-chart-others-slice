<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/166049157/18.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830478)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# Dashboard for WinForms - How to Display the Others Slice in the Pie Chart

This example demonstrates the Pie Chart that displays slices for data rows selected in the Grid, while unselected data comprises the Others slice.

![screenshot](./images/screenshot.png)

The dashboard is designed as follows:

* The [Pie Chart](https://docs.devexpress.com/Dashboard/15262) does not take part in master filtering. It has the **Ignore Master Filter** option enabled. The Pie Chart gets data from the [calculated fields](https://docs.devexpress.com/Dashboard/16134) whose expressions include [dashboard parameters](https://docs.devexpress.com/Dashboard/16135) to filter data.

* The dashboard's hidden **ParamSalesPerson** parameter is a list of Sales Person names. The hidden **ParamRangeStart** and **ParamRangeEnd** parameters contains the start and end values selected in the [Range Filter](https://docs.devexpress.com/Dashboard/15265). 

* The calculated field **OthersChartSalesPerson** provides data for the chart's Argument and contains the following expression:
`Iif(?ParamSalesPerson Is Null, [Sales Person], Iif([Sales Person] In (?ParamSalesPerson), [Sales Person], 'Others'))`

* The calculated field **ChartRangeExtPrice** provides data for the chart's Value and contains the following expression:
`Iif(?ParamRangeStart Is Null, [Extended Price], Iif([OrderDate] Between(?ParamRangeStart, ?ParamRangeEnd), [Extended Price], 0))`

When a user selects a row in the Grid, the [MasterFilterSet](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.MasterFilterSet) event occurs. The code in the event handler obtains filter values and assigns them to the dashboard parameters.
When the user executes the Clear Master Filter command, the [MasterFilterCleared](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.MasterFilterCleared) event occurs. The event is handled to clear parameters by assigning _null_ to the parameter's [SelectedValues](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardParameterDescriptor.SelectedValues).

> Another approach to perform the same task involves a custom visual interactivity instead of Master Filtering. Review the [Custom Visual Interactivity to Display the Others Slice in the Pie Chart](https://github.com/DevExpress-Examples/custom-visual-interactivity-to-display-pie-chart-others-slice) example for more information.

## Files to Review

[Form1.cs](./CS/PieChartOtherSliceExample/Form1.cs) / [Form1.vb](./VB/PieChartOtherSliceExample/Form1.vb)  

## Documentation

- [WinForms Dashboard Viewer](https://docs.devexpress.com/Dashboard/117122)
- [Interactivity](https://docs.devexpress.com/Dashboard/116692)
- [Pies](https://docs.devexpress.com/Dashboard/15262)
- [Dashboard Parameters](https://docs.devexpress.com/Dashboard/116918)
- [WinForms Viewer - Manage Dashboard Parameters](https://docs.devexpress.com/Dashboard/17632/winforms-dashboard/winforms-viewer/manage-dashboard-parameters)

## More Examples

* [How to: Pass a Dashboard Parameter to a Calculated Field's Expression in Code](https://github.com/DevExpress-Examples/how-to-pass-a-dashboard-parameter-to-a-calculated-fields-expression-in-code-e5135)
* [How to: Pass a Dashboard Parameter to a Custom SQL Query in Code](https://github.com/DevExpress-Examples/how-to-pass-a-dashboard-parameter-to-a-custom-sql-query-in-code-e5120)
* [How to: Pass a Hidden Dashboard Parameter to a Custom SQL Query in the WinForms Viewer](https://github.com/DevExpress-Examples/how-to-pass-a-hidden-dashboard-parameter-to-a-custom-sql-query-in-the-winforms-viewer-t338459)
* [How to: Specify Default Parameter Values in the WinForms Viewer](https://github.com/DevExpress-Examples/how-to-specify-default-parameter-values-in-the-winforms-viewer-t475858)
* [How to: Use Dashboard Parameters with the Expression Format Condition](https://github.com/DevExpress-Examples/how-to-usedashboard-parameters-with-the-expressionformat-condition-t260065)
* [How to: Manage Parameters in the WinForms Viewer](https://github.com/DevExpress-Examples/winforms-dashboard-how-to-manage-dashboard-parameters-in-code-t635871)

<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=how-to-display-pie-chart-others-slice&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=how-to-display-pie-chart-others-slice&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
