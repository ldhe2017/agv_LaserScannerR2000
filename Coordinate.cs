/*
 * Created by SharpDevelop.
 * User: ZJUCAOBIN
 * Date: 2019/3/20
 * Time: 16:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System .Data ;
using System .Drawing ;
using System .Windows .Forms ;
using System .Collections .Generic ;
using System .IO ;
using System .Text ;
using System .Threading ;
namespace LidarInterface
{
	/// <summary>
	/// Description of Coordinate.
	/// </summary>
	
	public class Coordinate
	{
		private double distance;
		public double Distance
		{
			get{return distance ;}			
		}
		private double angle;
		public double  Angle
		{
			get {return angle ;}
		}
		private double x;
		public double X
		{
			get {return x ;}
		}
		private double y;
		public double Y
		{
			get {return y ;}
		}
		public Coordinate(double dist,double angl)
		{
			this .distance =dist ;
			this .angle=angl ;
			SwitchCoordinate();
		}
		void SwitchCoordinate()
		{
			x=distance*Math .Cos (Math .PI * angle  /180) ;
			y =distance * Math .Sin (Math .PI *angle /180);
		}
	}
	public class CreateCoordinate
	{
		public  CreateCoordinate()
		{
			InialDt();
		}
		private DataTable dt;
		public DataTable Dt
		{
			get {return dt ;}
            set { dt = value; }
		}
		private Coordinate xoy;
		public Coordinate XoY
		{
			get {return xoy ;}
		}
		private double x;
		public double X
		{
			get {return x ;}
		}
		private double y;
		public double Y
		{
			get {return y ;}
		}
		private Point origin;
		private static Point  ORIGIN;
		public Point Origin
		{
			get {return origin ;}
		}
		
		/// <summary>
		/// 绘制坐标系
		/// </summary>
		/// <param name="pan"></param>
		public void DrawXY(PictureBox pan)
		{
			origin.X=pan .Location .X +pan .Size .Width /2;
			origin .Y =pan .Location .Y +pan .Size .Height /2;
			ORIGIN =origin ;
			Graphics g = pan.CreateGraphics();
	       //绘制局部坐标系
			g.DrawLine(Pens.Black , new Point(origin .X-pan .Width /2,origin .Y ),new Point(origin .X +pan .Width /2,origin .Y ));
			g.DrawLine(Pens.Black, new Point(origin .X,origin .Y-pan .Height /2 ),new Point(origin .X,origin .Y+pan .Height /2 ));
			g.DrawLine(Pens.Black, new Point(origin .X,origin .Y -pan .Height/2 ),new Point(origin .X-20,origin .Y-pan .Height /2 +20));
			g.DrawLine(Pens.Black, new Point(origin .X,origin .Y -pan .Height/2 ),new Point(origin .X+20,origin .Y-pan .Height /2 +20));
			g.DrawLine(Pens.Black, new Point(origin .X+pan .Width /2,origin .Y ),new Point(origin .X+pan .Width /2-20,origin .Y -20));
			g.DrawLine(Pens.Black, new Point(origin .X+pan .Width /2,origin .Y ),new Point(origin .X+pan .Width /2-20,origin .Y +20));
		    
		   //绘制世界坐标系
			g.DrawLine(Pens.Black, new Point(15,15),new Point(100,15 ));
			g.DrawLine(Pens.Black, new Point(15,15 ),new Point(15,100 ));
			g.DrawLine(Pens.Black, new Point(100,15 ),new Point(85,0));
			g.DrawLine(Pens.Black, new Point(100,15),new Point(85,30));
			g.DrawLine(Pens.Black, new Point(15,100  ),new Point(0,85));
			g.DrawLine(Pens.Black, new Point(15,100  ),new Point(30,85 ));
			
            
			g.FillEllipse(new SolidBrush(Color.Red  ), (float )origin .X-3 , (float )origin .Y -3, 6, 6);
			g.FillEllipse(new SolidBrush(Color.Red  ), (float )15-3 , (float )15 -3, 6, 6);
			g.Dispose();
			DrawCircle (pan ,pan .Size .Width /2,50,50);		
		

		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pan"></param>
		/// <param name="startpoint"></param>
		/// <param name="endpoint"></param>
		public void DrawingLine(PictureBox pan,Point startpoint,Point endpoint)
		{
			Graphics g = pan.CreateGraphics();
			  g.DrawLine(Pens.Lime , startpoint,endpoint);
			g.Dispose();
		}
		/// <summary>
		/// 画同心圆
		/// </summary>
		/// <param name="pan"></param>
		/// <param name="max"></param>
		/// <param name="min"></param>
		/// <param name="step"></param>
		void DrawCircle(PictureBox pan,int max,int min,int step)
		{
			Graphics g = pan.CreateGraphics();
			for (int r =min  ;r <=max  ;r +=step )
			{
				Pen pen=new Pen (Color .LightYellow  );
			    pen .DashStyle =System.Drawing.Drawing2D.DashStyle.DashDot;
			    g .DrawEllipse (pen ,origin .X-r  ,origin .Y-r  ,2*r ,2*r );
			    
			}
			g.Dispose();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="distance"></param>
		/// <param name="angle"></param>
		public void OutPutNewXoY(double distance,double angle)
		{
			xoy =new Coordinate (distance/20 ,angle );
			x=ORIGIN  .X +xoy .X ;
			y =ORIGIN .Y -xoy .Y ;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pic"></param>
		public void CreatePoint(PictureBox pic,int raddix)
		{
			Graphics g=pic .CreateGraphics ();
			g.FillEllipse(new SolidBrush(Color.Green), (float )x-raddix, (float )y-raddix, raddix*2, raddix*2);
			g.FillEllipse(new SolidBrush(Color.Black ), (float )ORIGIN .X-3 , (float )ORIGIN .Y -3, 6, 6);
			g.Dispose();
		}
		public delegate void AddCreatPoint(PictureBox pic, AGV agv, int raddix, Color corlo, int sw);
	    public static void CreatePoint(PictureBox pic, AGV agv, int raddix, Color corlo, int sw)
        {
        	try 
        	{
        	     if (pic .InvokeRequired )
        		{
        			pic .BeginInvoke (new AddCreatPoint (CreatePoint),new object []{pic ,agv ,raddix ,corlo ,sw });
        		}
        		else 
        		{
        			SingleAgv itemagv = new SingleAgv(agv, sw);
           			 Graphics g = pic.CreateGraphics();
            		g.FillEllipse(new SolidBrush(Color.Black), (float)ORIGIN.X - 3, (float)ORIGIN.Y - 3, 6, 6);
            		foreach (double[] barr in itemagv.BarrierLocator)
           			 {
               		 g.FillEllipse(new SolidBrush(corlo), (float)barr[1] - raddix, (float)barr[2] - raddix, raddix * 2, raddix * 2);
                	if ((int)barr[4]!=0)
               		 {
                	g.DrawLine(Pens.Blue , new Point((int)agv .AgvLocation_X ,(int)agv .AgvLocation_Y   ),new Point((int)barr [1],(int)barr [2] ));
                	}
            }
            g.Dispose();
        		}
        	}
        	catch (Exception ex)
        	{
        		MessageBox .Show (ex .ToString ());
        	}
        	GC .Collect ();
        	Application .DoEvents ();
            
        }
        /// <summary>
        /// 初始化俩表
        /// </summary>
        void InialDt()
		{
			dt=new DataTable ();
			dt .Columns .Add ("Index",typeof (string ));
			dt .Columns .Add ("X",typeof (string ));
			dt .Columns .Add ("Y",typeof (string ));
			dt .Columns .Add ("Angle",typeof (string ));
			dt .Columns .Add ("Distance",typeof (string ));
			
		}
		
		
	}
}
