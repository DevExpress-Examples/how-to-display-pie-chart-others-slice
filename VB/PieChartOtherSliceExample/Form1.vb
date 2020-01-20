Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWin
Imports DevExpress.XtraEditors
Imports System.IO
Imports System.Linq

Namespace PieChartOtherSliceExample
    Partial Public Class Form1
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()

            AddHandler dashboardViewer1.ConfigureDataConnection, AddressOf dashboardViewer1_ConfigureDataConnection
            AddHandler dashboardViewer1.MasterFilterSet, AddressOf dashboardViewer1_MasterFilterSet

            dashboardViewer1.LoadDashboard("Dashboard.xml")

        End Sub

        Private Sub dashboardViewer1_MasterFilterSet(ByVal sender As Object, ByVal e As MasterFilterSetEventArgs)
            Dim viewer As DashboardViewer = DirectCast(sender, DashboardViewer)

            If e.DashboardItemName = "gridDashboardItem1" Then
                Dim stringValues = e.SelectedValues.Select(Function(value) value(1).ToString())
                For Each selValue As String In stringValues
                    viewer.Parameters("ParamSalesPerson").SelectedValues = stringValues
                Next selValue
            End If
            If e.DashboardItemName = "rangeFilterDashboardItem1" Then
                viewer.Parameters("ParamRangeStart").SelectedValue = e.SelectedRange.Minimum
                viewer.Parameters("ParamRangeEnd").SelectedValue = e.SelectedRange.Maximum
            End If
        End Sub

        Private Sub dashboardViewer1_ConfigureDataConnection(ByVal sender As Object, ByVal e As DashboardConfigureDataConnectionEventArgs)
            Dim parameters As ExtractDataSourceConnectionParameters = TryCast(e.ConnectionParameters, ExtractDataSourceConnectionParameters)
            If parameters IsNot Nothing Then
                parameters.FileName = Path.GetFileName(parameters.FileName)
            End If
        End Sub
    End Class
End Namespace
