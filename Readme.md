# How to Display the Others Slice in the Pie Chart

This example demonstrates the Pie Chart that displays slices for data rows selected in the Grid, while unselected data comprises the Others slice.

![screenshot](https://github.com/DevExpress-Examples/how-to-display-pie-chart-others-slice/blob/18.2.4%2B/images/screenshot.png)

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

## Documentation

- [WinForms Dashboard Viewer](https://docs.devexpress.com/Dashboard/117122)
- [Interactivity](https://docs.devexpress.com/Dashboard/116692)
- [Pies](https://docs.devexpress.com/Dashboard/15262)
