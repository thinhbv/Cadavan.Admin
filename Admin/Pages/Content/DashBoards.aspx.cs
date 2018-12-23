using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;

public partial class Pages_Content_DashBoards : System.Web.UI.Page
{
	List<OrderMonth> lstOrder = null;
	List<string> lstName = new List<string>();
    protected void Page_Load(object sender, EventArgs e)
    {
		string cate = "";
		List<string> lstMonth = new List<string>();
		for (int i = 5; i > -1; i--)
		{
			DateTime tmpDate = DateTime.Now.AddMonths(-i);
			cate += "'" + tmpDate.Month.ToString() + "/" + tmpDate.Year.ToString() + "',";
			lstMonth.Add(tmpDate.Month.ToString() + "/" + tmpDate.Year.ToString());
		}
		cate = cate.Substring(0, cate.Length - 1);
		OrderMonth objOrder = new OrderMonth();
		lstOrder = objOrder.Get();
		if (lstOrder == null)
		{
			return;
		}
		for (int i = 0; i < lstOrder.Count; i++)
		{
			if (!lstName.Contains(lstOrder[i].CompanyName))
			{
				lstName.Add(lstOrder[i].CompanyName);
			}
		}
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < lstName.Count; i++)
		{
			List<OrderMonth> lstTmp = new List<OrderMonth>();
			lstTmp = lstOrder.Where(o => o.CompanyName == lstName[i]).ToList();
			if (lstTmp != null)
			{
				sb.AppendLine("				{");
				sb.AppendLine("				name: '" + lstName[i] + "',");
				sb.Append("				data: [");
				List<int> lstTemp = new List<int>() { 0, 0, 0, 0, 0, 0 };
				for (int j = 0; j < lstTmp.Count; j++)
				{
					int index = lstMonth.IndexOf(lstTmp[j].Month.ToString() + "/" + lstTmp[j].Year.ToString());
					if (index > -1)
					{
						lstTemp[index] = lstTmp[j].TotalCnt;
					}		
				}
				sb.Append(string.Join(",", lstTemp));
				if (i == lstName.Count - 1)
				{
					sb.AppendLine("]}");
				}
				else
				{
					sb.AppendLine("]},");
				}
			}
		}
		string myScript = @"var cate = new Array(" + cate + @");
		Highcharts.chart('container', {
			chart: {
				type: 'column',
				width: 1100
			},
			title: {
				text: 'Biểu đồ vé các hãng hàng không theo tháng'
			},
			xAxis: {
				categories: cate
			},
			yAxis: {
				min:0,
				title: {
					text: 'Tổng số vé bán được'
				}
			},
			tooltip: {
				pointFormat: '<span style=""color:{series.color}"">{series.name}</span>: <b>{point.y}</b> ({point.percentage:.0f}%)<br/>',
				shared: true
			},
			plotOptions: {
				column: {
					stacking: 'percent'
				}
			},
			series: [" + sb.ToString() + @"			]
		});";
		Page.ClientScript.RegisterStartupScript(this.GetType(), "RegisterStartupScript", myScript, true);
		GrantChartPie(DateTime.Now.Year);
		GrantChartPie(DateTime.Now.AddYears(-1).Year);
    }

	private void GrantChartPie(int year)
	{
		StringBuilder sbData = new StringBuilder();
		List<OrderMonth> lstOrd = lstOrder.Where(o => o.Year == year).ToList();
		int total = 0;
		if (lstOrd != null)
		{
			lstName = new List<string>();
			for (int i = 0; i < lstOrd.Count; i++)
			{
				if (!lstName.Contains(lstOrd[i].CompanyName))
				{
					lstName.Add(lstOrd[i].CompanyName);
				}
				
				total += lstOrd[i].TotalCnt;
			}

			for (int i = 0; i < lstName.Count; i++)
			{
				List<OrderMonth> lstTmp = lstOrder.Where(o => o.CompanyName == lstName[i] && o.Year == year).ToList();
				if (lstTmp != null)
				{
					int count = 0;
					for (int j = 0; j < lstTmp.Count; j++)
					{
						count += lstTmp[j].TotalCnt;
					}
					if (i == lstName.Count - 1)
					{
						sbData.AppendLine("['" + lstName[i] + "', " + Math.Round(((double)count * (double)100 / (double)total), 1).ToString() + "]");
					}
					else
					{
						sbData.AppendLine("['" + lstName[i] + "', " + Math.Round(((double)count * (double)100 / (double)total), 1).ToString() + "],");
					}
				}
			}
			string myScript = @"Highcharts.chart('container" + year.ToString() + @"', {
			chart: {
				type: 'pie',
				options3d: {
					enabled: true,
					alpha: 45,
					beta: 0
				}
			},
			title: {
				text: 'Tỉ lệ vé bán của các hãng hàng không, " + year.ToString() + @"'
			},
			tooltip: {
				pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
			},
			plotOptions: {
				pie: {
					allowPointSelect: true,
					cursor: 'pointer',
					depth: 35,
					dataLabels: {
						enabled: true,
						format: '{point.name} ({point.percentage:.1f}%)'
					}
				}
			},
			series: [{
				type: 'pie',
				name: 'Tỉ lệ bán vé',
				data: [
					" + sbData.ToString() + @"
				]
			}]
		 });";
			Page.ClientScript.RegisterStartupScript(this.GetType(), "RegisterStartupScript" + year.ToString(), myScript, true);
		}
	}
}