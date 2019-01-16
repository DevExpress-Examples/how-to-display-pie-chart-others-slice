using DevExpress.DashboardCommon;
using DevExpress.DashboardWin;
using DevExpress.XtraEditors;
using System.IO;
using System.Linq;

namespace PieChartOtherSliceExample
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();

            dashboardViewer1.ConfigureDataConnection += dashboardViewer1_ConfigureDataConnection;
            dashboardViewer1.MasterFilterSet += dashboardViewer1_MasterFilterSet;

            dashboardViewer1.LoadDashboard("Dashboard.xml");

        }

        private void dashboardViewer1_MasterFilterSet(object sender, MasterFilterSetEventArgs e)
        {
            DashboardViewer viewer = (DashboardViewer)sender;

            if (e.DashboardItemName == "gridDashboardItem1") {
                var stringValues = e.SelectedValues.Select(value => value[1].ToString());
                foreach (string selValue in stringValues)
                    viewer.Parameters["ParamSalesPerson"].SelectedValues = stringValues;
            }
            if(e.DashboardItemName == "rangeFilterDashboardItem1")
            {
                viewer.Parameters["ParamRangeStart"].SelectedValue = e.SelectedRange.Minimum;
                viewer.Parameters["ParamRangeEnd"].SelectedValue = e.SelectedRange.Maximum;
            }
        }

        private void dashboardViewer1_ConfigureDataConnection(object sender, DashboardConfigureDataConnectionEventArgs e)
        {
            ExtractDataSourceConnectionParameters parameters = e.ConnectionParameters as ExtractDataSourceConnectionParameters;
            if (parameters != null)
                parameters.FileName = Path.GetFileName(parameters.FileName);
        }
    }
}
