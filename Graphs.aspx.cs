using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using Demo.Database_handler;
using Demo.Entity_Objects;
namespace Demo
{
    public partial class Grapphs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (IsPostBack)
            {
               
            }

        }
        DataTable dt = new DataTable();
        databaseHandler dh = new databaseHandler();
        public void show_gx(DateTime startDate, DateTime enddate)
        {

            object[] graph_Data = { startDate, enddate };
            dt = dh.retrieveData(FindProcedure.ViewSelling_trends, graph_Data);
            if (dt.Rows.Count>=1) 
            {
                string[] x = new string[dt.Rows.Count];
                int[] y = new int[dt.Rows.Count];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    x[i] = dt.Rows[i][0].ToString();
                    y[i] = Convert.ToInt32(dt.Rows[i][1]);
                }
                Chart1.Series[0].Points.DataBindXY(x, y);
                Chart1.Series[0].ChartType = SeriesChartType.StackedColumn;
                multiviewSales.Visible = true;
                multiviewSales.SetActiveView(View1);

            }
            else
            {
                multiviewSales.Visible = false;
                multiviewSales.ActiveViewIndex = -1;
                
            }


        }

        protected void search_Txt_Click(object sender, EventArgs e)
        {
           
            DateTime startDate = Convert.ToDateTime(StartDateTxt.Text.ToString());
                DateTime enddate = Convert.ToDateTime(EndDateTxt.Text.ToString());
                show_gx(startDate, enddate);
                
        }
    }
}
