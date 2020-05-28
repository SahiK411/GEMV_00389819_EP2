using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Definitions.Charts;
using LiveCharts.Wpf;

namespace SourceCode.Admin_Classes
{
    public partial class CheckDemand : UserControl
    {
        public CheckDemand()
        {
            InitializeComponent();
            updateTab();
        }

        private void updateTab()
        {
            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();

            DataTable dt = DBConnect.ExecuteQuery("SELECT b.name AS \"Negocio\", sum(cp.cant) AS \"Total pedidos\" " +
                "FROM BUSINESS b, " +
                "(SELECT p.idBusiness, p.name, count(ap.idProduct) AS \"cant\" " +
                "FROM PRODUCT p, APPORDER ap " +
                "WHERE p.idProduct = ap.idProduct " +
                "GROUP BY p.idProduct " +
                "ORDER BY p.name ASC) AS cp " +
                "WHERE b.idBusiness = cp.idBusiness " +
                "GROUP BY b.idBusiness; ");

            ChartValues<int> temp = new ChartValues<int>();
            List<string> list = new List<string>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var dr = dt.Rows[i];
                temp.Add(Convert.ToInt32(dr[1].ToString()));
                list.Add(dr[0].ToString());
            }

            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Ordenes",
                    Values = temp
                }
            };

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Productos",
                Labels = list
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Ordenes Recibidas",
                LabelFormatter = value => value.ToString("N")
            });
        }
    }
}
