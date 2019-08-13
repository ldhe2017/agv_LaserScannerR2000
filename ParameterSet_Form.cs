/*
 * Created by SharpDevelop.
 * User: ZJUCAOBIN
 * Date: 2019/4/16
 * Time: 14:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace P_F_Interface
{
	/// <summary>
	/// Description of ParameterSet_Form.
	/// </summary>
	public partial class ParameterSet_Form : Form
	{
		
		public ParameterSet_Form()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void ParameterSet_FormLoad(object sender, EventArgs e)
		{
			
			ip .Text =Para .LidarIP ;
			packagetype .Text =Para .PackType ;
			watchdogtimeout .Text =Para .WathchDogTimeOut .ToString ();
			maxpointnum .Text =Para .TheoryPointNum .ToString ();
			xyerror .Text =Para .XYERROR .ToString ();
			lenerror .Text =Para .LENERROR .ToString ();
			filtererror .Text =Para .ANGLEFILTER .ToString ();
			maxdistance .Text =Para .MAXDISTANCE .ToString ();
			filterwidth .Text =Para .FilterWidth .ToString ();
			filtertype .Text =Para .FilterType ;
			timetorance .Text =Para .TIMETOLERANCE .ToString ();
			ip .Enabled=false ;
			packagetype .Enabled =false; 
			watchdogtimeout .Enabled =false; 
			maxdistance .Enabled =false ;
			maxpointnum .Enabled =false ;
			xyerror .Enabled =false ;
			lenerror .Enabled =false ;
			filtererror .Enabled =false ;
			filtertype .Enabled =false ;
			filterwidth .Enabled =false ;
			timetorance .Enabled =false ;
		
		}
		void Button1Click(object sender, EventArgs e)
		{
	        ip .Enabled=true  ;
			packagetype .Enabled =true; 
			watchdogtimeout .Enabled =true; 
			maxdistance .Enabled =true ;
			maxpointnum .Enabled =true ;
			xyerror .Enabled =true ;
			lenerror .Enabled =true ;
			filtererror .Enabled =true ;
			filtertype .Enabled =true ;
			filterwidth .Enabled =true ;
			timetorance .Enabled =true ;
		}
		void Button2Click(object sender, EventArgs e)
		{
			if (ip .Text =="")
			{
				MessageBox .Show ("请输入激光雷达IP地址");
				return ;
			}
			if (packagetype .Text =="")
			{
				MessageBox .Show ("请输入激光雷达的数据输出类型!");
				return ;
			}
			if (watchdogtimeout .Text =="")
			{
				MessageBox .Show ("请输入看门狗超时时间间隔！");
				return ;
			}
			if (maxpointnum .Text =="")
			{
				MessageBox .Show ("请输入理论输出点的最大数量！");
				return ;
			}
			if (xyerror.Text =="")
			{
				MessageBox.Show("请输入识别阀值1！");
				return ;
			}
			if (lenerror .Text =="")
			{
				MessageBox .Show ("请输入识别阀值2！");
				return ;
			}
			if(filtererror .Text =="")
			{
				MessageBox .Show ("请输入滤波阀值！");
				return ;
			}
			if (maxdistance .Text =="")
			{
				MessageBox .Show ("请输入激光识别的最大距离！");
				return ;
			}
			if (filtertype .Text =="")
			{
				MessageBox .Show ("请选择滤波类型！");
				return ;
			}
			if (filterwidth .Text =="")
			{
				MessageBox .Show ("请输入滤波宽度！");
				return ;
			}
			if (timetorance .Text =="")
			{
				MessageBox .Show ("请输入反光柱识别是将容差！");
				return ;
			}
			ParameterClass  item=new ParameterClass ();
			item .LidarIP =ip .Text ;
			item .WathchDogTimeOut =Convert .ToInt32 (watchdogtimeout .Text );
			item .PackType =packagetype .Text ;
			item .MAXDISTANCE =Convert .ToInt32  (maxdistance .Text );
			item .TheoryPointNum =Convert .ToInt32 (maxpointnum .Text );
			item .XYERROR =Convert .ToInt32 (xyerror .Text );
			item .LENERROR =Convert .ToInt32 (lenerror .Text );
			item .ANGLEFILTER =Convert .ToInt32 (filtererror .Text );
			item .FilterType =filtertype .Text ;
			item .FilterWidth =Convert .ToInt32 (filterwidth .Text );
			item .TIMETOLERANCE =Convert .ToInt32 (timetorance .Text );
			if (item .WritePara (item ))
			{
				string path =Application .StartupPath +@"\ParameterSet.ini";
			//	item .GetParaJson(path );
				MessageBox .Show ("参数设置成功！");
				
				return ;
			}
			else 
			{
				MessageBox .Show ("参数设置失败！");
			}
			
			
		}
		void MaxpointnumSelectedIndexChanged(object sender, EventArgs e)
		{
			filtertype .SelectedIndex =maxpointnum .SelectedIndex ;
		}
		void FiltertypeSelectedIndexChanged(object sender, EventArgs e)
		{
	         maxpointnum .SelectedIndex= filtertype .SelectedIndex ;
		}  
		
	}
}
