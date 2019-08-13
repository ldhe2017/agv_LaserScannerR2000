/*
 * Created by SharpDevelop.
 * User: ZJUCAOBIN
 * Date: 2019/3/20
 * Time: 13:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System .Data ;
using System .Linq ;
using LidarInterface ;
using LidarSeverData ;
namespace P_F_Interface
{
	/// <summary>
	/// Description of PointGraph.
	/// </summary>
	public partial class PointGraph : Form
	{
		DataTable dtlist =new DataTable ();
		public static Point OriginPoint;
		public PointGraph()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
        
		void CloudgraphClick(object sender, EventArgs e)
		{
	
		}
		void InialPointGraph()
		{
			this .Height = 800;
			this .Width =1450;
			cloudgraph .Width =900;
			cloudgraph .Height =900;
			lidardatadgv .Height =900;
			cloudgraph .BackColor =Color .LightGray  ;
			
		}
		void MenuStrip1ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
	
		}
		void PointGraphLoad(object sender, EventArgs e)
		{
			InialPointGraph();
			
		} 
		void MenuStrip1Paint(object sender, PaintEventArgs e)
		{
	
		}
		void PointGraphPaint(object sender, PaintEventArgs e)
		{
			CreateCoordinate  obj=new CreateCoordinate ();
			obj .DrawXY (cloudgraph );
			OriginPoint =obj .Origin ;
			orginpoint .Text ="("+OriginPoint .X .ToString ()+","+OriginPoint .Y .ToString ()+")";
		}
		void 绘图ToolStripMenuItemClick(object sender, EventArgs e)
		{
			
			//MessageBox .Show (OriginPoint .X .ToString ()+","+OriginPoint .Y .ToString ());
			
			if (palartem .Text =="")
			{
				MessageBox .Show ("请输入极轴长度！");
				return ;
			}
			if (angletem .Text =="")
			{
				MessageBox .Show ("请输入角度！");
				return ;
			}
			CreateCoordinate obj =new CreateCoordinate ();
			obj .OutPutNewXoY (Convert .ToDouble (palartem .Text ),Convert .ToDouble (angletem .Text ));
			obj .CreatePoint (cloudgraph,3);
				
            
		}
		void 清除ToolStripMenuItemClick(object sender, EventArgs e)
		{
	       Graphics g = this.cloudgraph.CreateGraphics();
	       CreateCoordinate obj =new CreateCoordinate ();
            g.Clear(Color.White);
            lidardatadgv.DataSource =obj .Dt ;
            
		}
		void Label1Click(object sender, EventArgs e)
		{
	
		}
		void 重绘坐标系ToolStripMenuItemClick(object sender, EventArgs e)
		{
	        CreateCoordinate  obj=new CreateCoordinate ();
			obj .DrawXY (cloudgraph );
		}
		void LidardatadgvCellContentClick(object sender, DataGridViewCellEventArgs e)
		{
	
		}
		void 绘制障碍物ToolStripMenuItemClick(object sender, EventArgs e)
		{
			AGV agv=new AGV ();
			agv .AgvLocation_X =450;
			agv .AgvLocation_Y =450;
			agv .AgvNo =1;
			agv.Polar=new int[450];
			agv.Angle=new float[450] ;
			 int  j =0,k =360;
			int index =0;
			for (int i=0;i<450;i+=3)
			{
				
                agv .Polar [index]=i ;
				agv .Angle [index]=j ;
				j+=3;
				index ++;
			}

			for (int i=0;i<=450;i+=30)
			{
				double [] item=new double[2] ;
//				k-=10;
//				agv .Polar [index ]=i ;
//				agv .Angle [index ]=k ;
//				index ++;
			}
	        CreateCoordinate obj =new CreateCoordinate ();
			CreateCoordinate .CreatePoint (cloudgraph,agv ,3,Color .Blue  ,1);
			lidardatadgv .DataSource =obj .Dt ;
			
				
		}
	}
}
