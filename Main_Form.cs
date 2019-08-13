/*
 * Created by SharpDevelop.
 * User: ZJUCAOBIN
 * Date: 2019/3/18
 * Time: 11:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft .Json ;
using System.Data ;
using System .Linq ;
using System .Net .Sockets  ;
using System .Net ;
using System .Web;
using Steema.TeeChart;
using System .Text ;
using Microsoft .Win32 ;
using System .IO ;
using System .Resources ;
using System .Xml ;
using System .Net .Sockets;
using System .Net .NetworkInformation ;
using LidarSeverData ;
using LidarInterface ;
using System.Threading;
using System .Collections .Generic;
namespace P_F_Interface
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class Main_Form : Form
	{
		static System.Timers.Timer timer = new System.Timers.Timer();  
	   static CreateMark  getmark=new CreateMark ();
		static bool  LidarScanState=true ;
		static LidarSever lidarclient=new LidarSever ();
		 DataTable Dt =new DataTable ();
		 static OBJ jij=new OBJ ();
		 ceshi ce=new ceshi ( jij );
		 public static double jce=0;
        static Int64 mmm = 0;
        /// </summary>
      
        List <string >listre=new List<string>();
		public static string  handle;
		public static string ss;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 查看ToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ListBox msgreceived;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox URLstr;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.DataGridView markdgv;
		private System.Windows.Forms.DataGridViewTextBoxColumn NumberNo;
		private System.Windows.Forms.DataGridViewTextBoxColumn X;
		private System.Windows.Forms.DataGridViewTextBoxColumn Y;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.TextBox agv_angle;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox agv_y;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox agv_x;
        public Steema.TeeChart.TChart get_location;
        private Steema.TeeChart.Styles.Points points1;
        private Button button7;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox cloudgraph;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Angle;
        private System.Windows.Forms.Timer timer1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ToolStripMenuItem 激光雷达参数设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 串口发送定位数据ToolStripMenuItem;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox lidarmode;
        private System.Windows.Forms.Label CurrentLidarMode;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ToolStripMenuItem 点云图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aGV定位测试ToolStripMenuItem;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
		public Main_Form()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			iNiDt();
		     
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void iNiDt()
		{
			Dt .Columns .Add ("NumberNo",typeof (string ));
			Dt .Columns .Add ("X",typeof (string ));
			Dt .Columns .Add ("Y",typeof (string ));
		}
		/// <summary>
		/// 序列化练习
		/// </summary>
		/// <returns></returns>
		string JSONstr()
		{
			ExampleClass itr=new ExampleClass (1);
			itr .Name ="caobin";
			itr .CardID ="201725183";
			itr .msgclass =new InforClass ();
			itr .msgclass .ID =2;
			itr .msgclass .Name ="wangyufei";
			string chaer=JsonConvert .SerializeObject (itr );
			ss =chaer ;
			return chaer ;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ss"></param>
		/// <returns></returns>
		string JSONfna(string sss)
		{  string  msg="";
			if (sss!="")
			{
			ExampleClass obj  = JsonConvert .DeserializeObject <ExampleClass >(sss );
			msg = obj .Name .ToString ();
			}
			return msg ;
		}
		void tEMPLOA()
		{
//			string[] read = File.ReadAllLines(Application .StartupPath+@"\TheLightInformation.ini");
//			lidarclient .agv .Polar =new int[read .Length +1] ;
//			lidarclient .agv .Angle =new float[read .Length+1] ;
//			lidarclient .Polar_Value =new int[read .Length+1] ;
//			lidarclient .Angle_Value =new float[read .Length+1] ;
//			for (int I=0;I<3 ;I++)
//			{
//				TheLightNode NODE=JsonConvert .DeserializeObject <TheLightNode >(read [I]);
//				if (I==0)
//				{
//				 lidarclient .agv .Polar[I] =(int )(NODE .Polar) ;
//				 lidarclient .agv .Angle [I]=(float )(NODE .Angle );
//				 lidarclient .Polar_Value [I]=(int )(NODE .Polar);
//				 lidarclient .Angle_Value [I]=(float )(NODE .Angle );
//				 
//				}
//				else 
//				{
//				 lidarclient .agv .Polar[I+1] =(int )(NODE .Polar) ;
//				 lidarclient .agv .Angle [I+1]=(float )(NODE .Angle );
//				 lidarclient .Polar_Value [I+1]=(int )(NODE .Polar);
//				 lidarclient .Angle_Value [I+1]=(float )(NODE .Angle );
//				}
//				 lidarclient .agv .Polar[1] =(int )(1231) ;
//				 lidarclient .agv .Angle [1]=(float )(122 );
//				 lidarclient .Polar_Value [1]=(int )(1231);
//				 lidarclient .Angle_Value [1]=(float )(122 );
//			}
		}
		/// <summary>
		/// 
		/// </summary>
		void DisplayRawData()
		{
			foreach (string item in  listre )
			{
				AddMsg ( msgreceived ,item );
			}
			listre .Clear ();
		}
	
		void DeleHandleListItem(string ip)
		{
	
			for (int i=0; i<lidarclient.HandleList.Count ;i++)
			{
				if (lidarclient.HandleList [i].IP ==ip )
				{
					lidarclient.HandleList .RemoveAt (i );
				}
			}
		}
		string  FindHandle(string ip)
		{
			string haldle="";
			foreach (HttpHandle  item in lidarclient.HandleList)
			{
				if (item .IP ==ip )
				{
					haldle =item .Handle;
					break ;
				}
			}
			return haldle ;
		}
		void Button1Click(object sender, EventArgs e)
		{
            if (lidarclient.judgeNetConnent (URLstr.Text))
            {
                if (lidarclient.LidarConnState)
                {

                    lidarclient.ConnentOrDisconnent();
                    HttpQuary qual = new HttpQuary(string.Format("http://{0}/cmd/stop_scanoutput?handle={1}", URLstr.Text, FindHandle(URLstr.Text)));
                    listre.Add(qual.JsonStr);
                    HttpQuary qio = new HttpQuary(string.Format("http://{0}/cmd/release_handle?handle={1}", URLstr.Text, FindHandle(URLstr.Text)));
                    listre.Add(qio.JsonStr);
                    timer .Stop ();
                    button7 .Enabled =false ;
                    button5.Enabled =false ;
                    button4.Enabled =false ;
                    button1.Text = "连接";
                    button10 .Enabled =false  ;
                }
                else
                {
                	string URLconnStr = "http://" + URLstr.Text + "/cmd/request_handle_tcp?packet_type="+Para .PackType +"&watchdogtimeout="+Para .WathchDogTimeOut .ToString ()+"&start_angle=0";
                    HttpQuary quary = new HttpQuary(URLconnStr);
                    HttpHandle item = new HttpHandle(quary.JsonStr, URLstr.Text);
                    if (item.State)
                    {

                        listre.Add(item.JsonData);
                        listre.Add(item.Handle);
                        listre.Add(item.Port.ToString());
                        lidarclient.Port = (int)item.Port;
                        if (lidarclient.ConnentOrDisconnent())
                        {
                        	 string sset1 = string.Format("http://" + URLstr.Text + "/cmd/set_scanoutput_config?handle={0}&max_num_points_scan={1}", item.Handle,lidarclient.TheorySize );
                             HttpQuary setnum1 = new HttpQuary(sset1);
                             listre .Add (setnum1 .JsonStr );
                             string sset2 = string.Format("http://" + URLstr.Text + "/cmd/set_parameter?filter_type={0}", Para .FilterType  );
                             HttpQuary setnum2 = new HttpQuary(sset2);
                             listre .Add (setnum2 .JsonStr );
                             string sset3 = string.Format("http://" + URLstr.Text + "/cmd/set_parameter?filter_width={0}", Para .FilterWidth  );
                             HttpQuary setnum3 = new HttpQuary(sset2);
                             listre .Add (setnum3 .JsonStr );
                        	 string ss = string.Format("http://" + URLstr.Text + "/cmd/start_scanoutput?handle={0}", item.Handle);
                             HttpQuary qu = new HttpQuary(ss);
                             Serialize ii = new Serialize(qu.JsonStr);
                        if (ii.State)
                        {
                        	MessageBox.Show("已连接"); 
							button7 .Text ="扫描轮廓数据";  
							button5.Text ="开始靶标探测";
                        	button7 .Enabled =true ;
                        	button5 .Enabled =true ;
                        	button4 .Enabled =true ;
                            button1.Text = "断开";
                            button10 .Enabled =true   ;
                            lidarclient.HandleList.Add(item);
                            listre.Add(ii.JsonData);
                            listre.Add(ii.Error_Text);
                        }
                        else
                        {
                            MessageBox.Show(ii.Error_Code.ToString() + "--" + ii.Error_Text);
                            DeleHandleListItem(item.Handle);
                        }
                           
                        }
                        else
                        {
                            MessageBox.Show("连接失败");
                        }
                       

                    }
                    else
                    {
                        MessageBox.Show(item.Error_Code.ToString() + "--" + item.Error_Text);
                    }
                    DisplayRawData();
                }
            }
            else
            {
                MessageBox.Show("网络已经中断，请检查网络!");
            }
			
			
		}
		/// <summary>
		/// GET发送请求方式
		/// </summary>
		
		
		void Button2Click(object sender, EventArgs e)
		{
			 if (MessageBox.Show("是否要保存反光柱信息！", "注意！！！" , MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
			 	List <TheLightNode >thelist=new List<TheLightNode> ();
			byte  inde =1;
			for (int i=0;i<markdgv .Rows .Count -1;i++)
			{
				if(markdgv .Rows [i].Cells [1].Value .ToString ()!="-"&&markdgv .Rows [i].Cells [2].Value .ToString ()!="-")
				{
					TheLightNode baocun =new TheLightNode ();
					//baocun .NumberNo =(byte )markdgv .Rows [i].Cells [0].Value;
					baocun .NumberNo =inde ;
					baocun .X =(double  )markdgv .Rows [i].Cells [1].Value;
					baocun .Y  =(double )markdgv .Rows [i].Cells [2].Value;
					baocun .Polar =Math .Sqrt (Math .Pow (baocun .X ,2)+Math .Pow (baocun .Y ,2));
					if ((baocun .X <0  && baocun .Y >0)||(baocun .X <0 && baocun . Y <0))
					{
						baocun .Angle  =180-(double )Math .Asin (baocun .Y /baocun .Polar ) * 180 /Math .PI ;
					}
					else if (baocun .X >0 && baocun .Y <0)
					{
						baocun .Angle  =360+(double )Math .Asin (baocun .Y /baocun .Polar ) * 180 /Math .PI;
					}
					else 
					{
						baocun .Angle  =(double )Math .Asin (baocun .Y /baocun .Polar ) * 180 /Math .PI;
					}
					thelist .Add (baocun );
					inde ++;
				}
			}
			
			
			if (getmark  .WriteTxt (thelist))
			{
				MessageBox .Show ("靶标信息保存成功！");
			}
			 }
			
		}
		void 点云ToolStripMenuItemClick(object sender, EventArgs e)
		{
			PointGraph   en =new PointGraph ();
			en .Show ();
		}
		void Main_FormFormClosing(object sender, FormClosingEventArgs e)
		{
		
			if (lidarclient.LidarConnState )
			{
				
				lidarclient .ConnentOrDisconnent();
				HttpQuary qual=new HttpQuary (string .Format ("http://{0}/cmd/stop_scanoutput?handle={1}",URLstr .Text,FindHandle(URLstr .Text)));
			   	listre .Add (qual .JsonStr );
			   	HttpQuary qio=new HttpQuary (string .Format ("http://{0}/cmd/release_handle?handle={1}",URLstr .Text,FindHandle(URLstr .Text)));
			   	listre .Add (qio .JsonStr );
				
			}
			if (serialPort1 .IsOpen)
			{
				serialPort1 .Close ();
			}
				
		
			
		}
		/// <summary>
		/// 加载激光雷达参数
		/// </summary>
		public void LoadParameter()
		{
			string path= Application .StartupPath +@"\ParameterSet.ini";
			ParameterClass item =new ParameterClass ();
			item .GetParaJson (path );
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		bool  GetLidarWorkPara()
		{
			try 
			{
			   timer1 .Stop ();
			   timer2 .Stop ();
	           lidarclient .IP =URLstr .Text;
	           LoadParameter();
	           lidarclient .SendMsgTimeStep =100;
	           lidarclient .TheorySize =Para .TheoryPointNum ;//15260/980
	           lidarclient .InialPara ();
	           URLstr .Text =Para .LidarIP ;
	        

	           cloudgraph .Width =700;
			   cloudgraph .Height =700;
			   cloudgraph .BackColor =Color .LightGray  ;
			   
			   
			    
                button7 .Enabled =false ;
               button6.Enabled =false ;
               button5.Enabled =false ;
                button4 .Enabled =false  ;
               //  lidarmode .Enabled =false ;
                 button10 .Enabled =false ;
                 timer.Elapsed += GraphDraw;
                
                if (LidarMode .IsNavicationMode )
                {
                	lidarmode.Text ="导航模式";
                	timer.Interval = 400;
                }
                else 
                {
                	lidarmode.Text ="轮廓数据";
                	timer.Interval = 200;
                }
                lidarmode .ForeColor =Color .Red ;
			}
			catch (Exception ex)
			{
				return false ;
			}
			return true ;
		}
		void Main_FormLoad(object sender, EventArgs e)
		{
			    GetLidarWorkPara();
                Inidgv();
			   CreateCoordinate  obj=new CreateCoordinate ();
			    obj .DrawXY (cloudgraph );
			    
			    tEMPLOA();
		}
		void MsgreceivedMouseDoubleClick(object sender, MouseEventArgs e)
		{
			msgreceived .Items .Clear ();
		}
		void 模拟机器人定位ToolStripMenuItemClick(object sender, EventArgs e)
		{
	       
		}
		void Button3Click(object sender, EventArgs e)
		{
			
			GraphAevironment g=RWTheLight .LoadTheLightMsg ();
			for (int i=0;i<markdgv .Rows .Count ;i++)
			{
				markdgv .Rows[i].Cells [0].Value ="-";
				markdgv .Rows[i].Cells [1].Value ="-";
				markdgv .Rows[i].Cells [2].Value ="-";
				markdgv .Rows[i].Cells [3].Value ="-";
				markdgv .Rows [i].DefaultCellStyle .BackColor =Color .White ;
			}
			for (int i=0;i<g .NODE .Length ;i++)
			{
				markdgv .Rows [i].Cells [0].Value =g .NODE[i].NumberNo ;
				markdgv .Rows [i].Cells [1].Value =g .NODE [i].X ;
				markdgv .Rows [i].Cells [2].Value =g .NODE [i].Y ;
				markdgv .Rows [i].Cells [3].Value =g .NODE [i].Angle ;
				markdgv .Rows [i].DefaultCellStyle .BackColor =Color .Red ;
			}
		
			
		}
		void Button4Click(object sender, EventArgs e)
		{
			if(button4 .Text =="开启导航模式")
			{
				LidarMode .GraphCreateState =false ;
	       	    LidarMode .TargetDetectionState=false ;
	       	    LidarMode .IsNavicationMode =true ;
	       	    lidarmode .Text ="导航模式";
				timer .Start ();
				lidarclient .World .QuartTimer .Start ();
			    button6.Enabled =true  ;
			    button4 .Text ="停止导航模式";
			    return ;
			}
			if (button4 .Text =="停止导航模式")
			{
				LidarMode .IsNavicationMode =false ;
				timer .Stop ();
				lidarclient .World .QuartTimer .Stop ();
			    button6.Enabled =false   ;
			    button4 .Text ="开启导航模式";
			    return ;
			}
			
			
			
		}

        private void InitializeComponent()
        {
        	this.components = new System.ComponentModel.Container();
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
        	this.menuStrip1 = new System.Windows.Forms.MenuStrip();
        	this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.激光雷达参数设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.串口发送定位数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.点云图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.aGV定位测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.splitContainer1 = new System.Windows.Forms.SplitContainer();
        	this.groupBox4 = new System.Windows.Forms.GroupBox();
        	this.button6 = new System.Windows.Forms.Button();
        	this.agv_angle = new System.Windows.Forms.TextBox();
        	this.label4 = new System.Windows.Forms.Label();
        	this.agv_y = new System.Windows.Forms.TextBox();
        	this.label5 = new System.Windows.Forms.Label();
        	this.agv_x = new System.Windows.Forms.TextBox();
        	this.label2 = new System.Windows.Forms.Label();
        	this.markdgv = new System.Windows.Forms.DataGridView();
        	this.NumberNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.Angle = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
        	this.groupBox3 = new System.Windows.Forms.GroupBox();
        	this.button10 = new System.Windows.Forms.Button();
        	this.button7 = new System.Windows.Forms.Button();
        	this.button4 = new System.Windows.Forms.Button();
        	this.button5 = new System.Windows.Forms.Button();
        	this.groupBox2 = new System.Windows.Forms.GroupBox();
        	this.button9 = new System.Windows.Forms.Button();
        	this.button3 = new System.Windows.Forms.Button();
        	this.button2 = new System.Windows.Forms.Button();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.lidarmode = new System.Windows.Forms.TextBox();
        	this.CurrentLidarMode = new System.Windows.Forms.Label();
        	this.button1 = new System.Windows.Forms.Button();
        	this.URLstr = new System.Windows.Forms.TextBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.tabControl1 = new System.Windows.Forms.TabControl();
        	this.tabPage3 = new System.Windows.Forms.TabPage();
        	this.button8 = new System.Windows.Forms.Button();
        	this.cloudgraph = new System.Windows.Forms.PictureBox();
        	this.tabPage1 = new System.Windows.Forms.TabPage();
        	this.get_location = new Steema.TeeChart.TChart();
        	this.points1 = new Steema.TeeChart.Styles.Points();
        	this.tabPage2 = new System.Windows.Forms.TabPage();
        	this.msgreceived = new System.Windows.Forms.ListBox();
        	this.timer1 = new System.Windows.Forms.Timer(this.components);
        	this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
        	this.timer2 = new System.Windows.Forms.Timer(this.components);
        	this.menuStrip1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
        	this.splitContainer1.Panel1.SuspendLayout();
        	this.splitContainer1.Panel2.SuspendLayout();
        	this.splitContainer1.SuspendLayout();
        	this.groupBox4.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.markdgv)).BeginInit();
        	this.groupBox3.SuspendLayout();
        	this.groupBox2.SuspendLayout();
        	this.groupBox1.SuspendLayout();
        	this.tabControl1.SuspendLayout();
        	this.tabPage3.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.cloudgraph)).BeginInit();
        	this.tabPage1.SuspendLayout();
        	this.tabPage2.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// menuStrip1
        	// 
        	this.menuStrip1.BackColor = System.Drawing.Color.White;
        	this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
        	this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.设置ToolStripMenuItem,
			this.编辑ToolStripMenuItem,
			this.查看ToolStripMenuItem});
        	this.menuStrip1.Location = new System.Drawing.Point(0, 0);
        	this.menuStrip1.Name = "menuStrip1";
        	this.menuStrip1.Size = new System.Drawing.Size(1513, 28);
        	this.menuStrip1.TabIndex = 0;
        	this.menuStrip1.Text = "menuStrip1";
        	this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip1ItemClicked);
        	// 
        	// 设置ToolStripMenuItem
        	// 
        	this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.激光雷达参数设置ToolStripMenuItem,
			this.串口发送定位数据ToolStripMenuItem});
        	this.设置ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("设置ToolStripMenuItem.Image")));
        	this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
        	this.设置ToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
        	this.设置ToolStripMenuItem.Text = "设置";
        	// 
        	// 激光雷达参数设置ToolStripMenuItem
        	// 
        	this.激光雷达参数设置ToolStripMenuItem.Name = "激光雷达参数设置ToolStripMenuItem";
        	this.激光雷达参数设置ToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
        	this.激光雷达参数设置ToolStripMenuItem.Text = "激光雷达参数设置";
        	this.激光雷达参数设置ToolStripMenuItem.Click += new System.EventHandler(this.激光雷达参数设置ToolStripMenuItemClick);
        	// 
        	// 串口发送定位数据ToolStripMenuItem
        	// 
        	this.串口发送定位数据ToolStripMenuItem.Name = "串口发送定位数据ToolStripMenuItem";
        	this.串口发送定位数据ToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
        	this.串口发送定位数据ToolStripMenuItem.Text = "串口发送定位数据";
        	this.串口发送定位数据ToolStripMenuItem.Click += new System.EventHandler(this.串口发送定位数据ToolStripMenuItemClick);
        	// 
        	// 编辑ToolStripMenuItem
        	// 
        	this.编辑ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("编辑ToolStripMenuItem.Image")));
        	this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
        	this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
        	this.编辑ToolStripMenuItem.Text = "编辑";
        	// 
        	// 查看ToolStripMenuItem
        	// 
        	this.查看ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.点云图ToolStripMenuItem,
			this.aGV定位测试ToolStripMenuItem});
        	this.查看ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("查看ToolStripMenuItem.Image")));
        	this.查看ToolStripMenuItem.Name = "查看ToolStripMenuItem";
        	this.查看ToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
        	this.查看ToolStripMenuItem.Text = "查看";
        	// 
        	// 点云图ToolStripMenuItem
        	// 
        	this.点云图ToolStripMenuItem.Name = "点云图ToolStripMenuItem";
        	this.点云图ToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
        	this.点云图ToolStripMenuItem.Text = "点云图";
        	this.点云图ToolStripMenuItem.Click += new System.EventHandler(this.点云图ToolStripMenuItemClick);
        	// 
        	// aGV定位测试ToolStripMenuItem
        	// 
        	this.aGV定位测试ToolStripMenuItem.Name = "aGV定位测试ToolStripMenuItem";
        	this.aGV定位测试ToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
        	this.aGV定位测试ToolStripMenuItem.Text = "AGV定位测试";
        	this.aGV定位测试ToolStripMenuItem.Click += new System.EventHandler(this.AGV定位测试ToolStripMenuItemClick);
        	// 
        	// splitContainer1
        	// 
        	this.splitContainer1.BackColor = System.Drawing.Color.White;
        	this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.splitContainer1.Location = new System.Drawing.Point(0, 28);
        	this.splitContainer1.Name = "splitContainer1";
        	// 
        	// splitContainer1.Panel1
        	// 
        	this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
        	this.splitContainer1.Panel1.Controls.Add(this.markdgv);
        	this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
        	this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
        	this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
        	// 
        	// splitContainer1.Panel2
        	// 
        	this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
        	this.splitContainer1.Size = new System.Drawing.Size(1513, 772);
        	this.splitContainer1.SplitterDistance = 371;
        	this.splitContainer1.TabIndex = 1;
        	// 
        	// groupBox4
        	// 
        	this.groupBox4.Controls.Add(this.button6);
        	this.groupBox4.Controls.Add(this.agv_angle);
        	this.groupBox4.Controls.Add(this.label4);
        	this.groupBox4.Controls.Add(this.agv_y);
        	this.groupBox4.Controls.Add(this.label5);
        	this.groupBox4.Controls.Add(this.agv_x);
        	this.groupBox4.Controls.Add(this.label2);
        	this.groupBox4.Location = new System.Drawing.Point(3, 331);
        	this.groupBox4.Name = "groupBox4";
        	this.groupBox4.Size = new System.Drawing.Size(352, 114);
        	this.groupBox4.TabIndex = 5;
        	this.groupBox4.TabStop = false;
        	this.groupBox4.Text = "CurrentRobotLocation";
        	// 
        	// button6
        	// 
        	this.button6.Location = new System.Drawing.Point(235, 46);
        	this.button6.Name = "button6";
        	this.button6.Size = new System.Drawing.Size(91, 35);
        	this.button6.TabIndex = 4;
        	this.button6.Text = "连续定位";
        	this.button6.UseVisualStyleBackColor = true;
        	this.button6.Click += new System.EventHandler(this.Button6Click);
        	// 
        	// agv_angle
        	// 
        	this.agv_angle.Location = new System.Drawing.Point(101, 82);
        	this.agv_angle.Name = "agv_angle";
        	this.agv_angle.Size = new System.Drawing.Size(118, 25);
        	this.agv_angle.TabIndex = 7;
        	// 
        	// label4
        	// 
        	this.label4.Location = new System.Drawing.Point(44, 85);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(100, 23);
        	this.label4.TabIndex = 6;
        	this.label4.Text = "Angle:";
        	// 
        	// agv_y
        	// 
        	this.agv_y.Location = new System.Drawing.Point(101, 51);
        	this.agv_y.Name = "agv_y";
        	this.agv_y.Size = new System.Drawing.Size(118, 25);
        	this.agv_y.TabIndex = 5;
        	// 
        	// label5
        	// 
        	this.label5.Location = new System.Drawing.Point(76, 54);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(100, 23);
        	this.label5.TabIndex = 4;
        	this.label5.Text = "Y:";
        	// 
        	// agv_x
        	// 
        	this.agv_x.Location = new System.Drawing.Point(101, 20);
        	this.agv_x.Name = "agv_x";
        	this.agv_x.Size = new System.Drawing.Size(118, 25);
        	this.agv_x.TabIndex = 3;
        	// 
        	// label2
        	// 
        	this.label2.Location = new System.Drawing.Point(76, 22);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(100, 23);
        	this.label2.TabIndex = 2;
        	this.label2.Text = "X:";
        	// 
        	// markdgv
        	// 
        	this.markdgv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
        	this.markdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.markdgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.NumberNo,
			this.X,
			this.Y,
			this.Angle,
			this.Column1});
        	this.markdgv.Location = new System.Drawing.Point(6, 451);
        	this.markdgv.Name = "markdgv";
        	this.markdgv.RowHeadersVisible = false;
        	this.markdgv.RowTemplate.Height = 27;
        	this.markdgv.Size = new System.Drawing.Size(352, 329);
        	this.markdgv.TabIndex = 5;
        	this.markdgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MarkdgvCellContentClick);
        	// 
        	// NumberNo
        	// 
        	this.NumberNo.DataPropertyName = "NumberNo";
        	this.NumberNo.HeaderText = "序号";
        	this.NumberNo.Name = "NumberNo";
        	this.NumberNo.Width = 50;
        	// 
        	// X
        	// 
        	this.X.DataPropertyName = "X";
        	this.X.HeaderText = "X";
        	this.X.Name = "X";
        	this.X.Width = 70;
        	// 
        	// Y
        	// 
        	this.Y.DataPropertyName = "Y";
        	this.Y.HeaderText = "Y";
        	this.Y.Name = "Y";
        	this.Y.Width = 70;
        	// 
        	// Angle
        	// 
        	this.Angle.HeaderText = "Angle";
        	this.Angle.Name = "Angle";
        	this.Angle.Width = 70;
        	// 
        	// Column1
        	// 
        	this.Column1.HeaderText = "操作";
        	this.Column1.Name = "Column1";
        	this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        	this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
        	this.Column1.Text = "删除";
        	this.Column1.Width = 70;
        	// 
        	// groupBox3
        	// 
        	this.groupBox3.Controls.Add(this.button10);
        	this.groupBox3.Controls.Add(this.button7);
        	this.groupBox3.Controls.Add(this.button4);
        	this.groupBox3.Controls.Add(this.button5);
        	this.groupBox3.Location = new System.Drawing.Point(6, 225);
        	this.groupBox3.Name = "groupBox3";
        	this.groupBox3.Size = new System.Drawing.Size(352, 103);
        	this.groupBox3.TabIndex = 4;
        	this.groupBox3.TabStop = false;
        	this.groupBox3.Text = "工作模式";
        	// 
        	// button10
        	// 
        	this.button10.Location = new System.Drawing.Point(189, 65);
        	this.button10.Name = "button10";
        	this.button10.Size = new System.Drawing.Size(137, 29);
        	this.button10.TabIndex = 5;
        	this.button10.Text = "开启建图模式";
        	this.button10.UseVisualStyleBackColor = true;
        	this.button10.Click += new System.EventHandler(this.Button10Click);
        	// 
        	// button7
        	// 
        	this.button7.Location = new System.Drawing.Point(189, 24);
        	this.button7.Name = "button7";
        	this.button7.Size = new System.Drawing.Size(137, 29);
        	this.button7.TabIndex = 4;
        	this.button7.Text = "扫描轮廓数据";
        	this.button7.UseVisualStyleBackColor = true;
        	this.button7.Click += new System.EventHandler(this.button7_Click);
        	// 
        	// button4
        	// 
        	this.button4.Location = new System.Drawing.Point(15, 24);
        	this.button4.Name = "button4";
        	this.button4.Size = new System.Drawing.Size(137, 29);
        	this.button4.TabIndex = 3;
        	this.button4.Text = "开启导航模式";
        	this.button4.UseVisualStyleBackColor = true;
        	this.button4.Click += new System.EventHandler(this.Button4Click);
        	// 
        	// button5
        	// 
        	this.button5.Location = new System.Drawing.Point(15, 65);
        	this.button5.Name = "button5";
        	this.button5.Size = new System.Drawing.Size(137, 29);
        	this.button5.TabIndex = 2;
        	this.button5.Text = "开始靶标探测";
        	this.button5.UseVisualStyleBackColor = true;
        	this.button5.Click += new System.EventHandler(this.Button5Click);
        	// 
        	// groupBox2
        	// 
        	this.groupBox2.Controls.Add(this.button9);
        	this.groupBox2.Controls.Add(this.button3);
        	this.groupBox2.Controls.Add(this.button2);
        	this.groupBox2.Location = new System.Drawing.Point(6, 114);
        	this.groupBox2.Name = "groupBox2";
        	this.groupBox2.Size = new System.Drawing.Size(352, 111);
        	this.groupBox2.TabIndex = 1;
        	this.groupBox2.TabStop = false;
        	this.groupBox2.Text = "靶标信息设置";
        	// 
        	// button9
        	// 
        	this.button9.Location = new System.Drawing.Point(15, 65);
        	this.button9.Name = "button9";
        	this.button9.Size = new System.Drawing.Size(137, 29);
        	this.button9.TabIndex = 5;
        	this.button9.Text = "读取雷达工作模式";
        	this.button9.UseVisualStyleBackColor = true;
        	this.button9.Click += new System.EventHandler(this.Button9Click);
        	// 
        	// button3
        	// 
        	this.button3.Location = new System.Drawing.Point(188, 20);
        	this.button3.Name = "button3";
        	this.button3.Size = new System.Drawing.Size(137, 29);
        	this.button3.TabIndex = 3;
        	this.button3.Text = "靶标信息读取";
        	this.button3.UseVisualStyleBackColor = true;
        	this.button3.Click += new System.EventHandler(this.Button3Click);
        	// 
        	// button2
        	// 
        	this.button2.Location = new System.Drawing.Point(14, 21);
        	this.button2.Name = "button2";
        	this.button2.Size = new System.Drawing.Size(137, 29);
        	this.button2.TabIndex = 2;
        	this.button2.Text = "靶标信息保存";
        	this.button2.UseVisualStyleBackColor = true;
        	this.button2.Click += new System.EventHandler(this.Button2Click);
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Controls.Add(this.lidarmode);
        	this.groupBox1.Controls.Add(this.CurrentLidarMode);
        	this.groupBox1.Controls.Add(this.button1);
        	this.groupBox1.Controls.Add(this.URLstr);
        	this.groupBox1.Controls.Add(this.label1);
        	this.groupBox1.Location = new System.Drawing.Point(7, 3);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Size = new System.Drawing.Size(352, 110);
        	this.groupBox1.TabIndex = 0;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "连接雷达服务器";
        	// 
        	// lidarmode
        	// 
        	this.lidarmode.BackColor = System.Drawing.Color.White;
        	this.lidarmode.BorderStyle = System.Windows.Forms.BorderStyle.None;
        	this.lidarmode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.lidarmode.ForeColor = System.Drawing.Color.Red;
        	this.lidarmode.Location = new System.Drawing.Point(162, 65);
        	this.lidarmode.Name = "lidarmode";
        	this.lidarmode.Size = new System.Drawing.Size(165, 27);
        	this.lidarmode.TabIndex = 4;
        	// 
        	// CurrentLidarMode
        	// 
        	this.CurrentLidarMode.Location = new System.Drawing.Point(13, 71);
        	this.CurrentLidarMode.Name = "CurrentLidarMode";
        	this.CurrentLidarMode.Size = new System.Drawing.Size(169, 23);
        	this.CurrentLidarMode.TabIndex = 3;
        	this.CurrentLidarMode.Text = "CurrentLidarMode:";
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(214, 19);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(111, 29);
        	this.button1.TabIndex = 2;
        	this.button1.Text = "连接";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.Button1Click);
        	// 
        	// URLstr
        	// 
        	this.URLstr.Location = new System.Drawing.Point(38, 21);
        	this.URLstr.Name = "URLstr";
        	this.URLstr.Size = new System.Drawing.Size(165, 25);
        	this.URLstr.TabIndex = 1;
        	this.URLstr.Text = "192.168.0.3";
        	// 
        	// label1
        	// 
        	this.label1.Location = new System.Drawing.Point(9, 24);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(100, 23);
        	this.label1.TabIndex = 0;
        	this.label1.Text = "IP:";
        	// 
        	// tabControl1
        	// 
        	this.tabControl1.Controls.Add(this.tabPage3);
        	this.tabControl1.Controls.Add(this.tabPage1);
        	this.tabControl1.Controls.Add(this.tabPage2);
        	this.tabControl1.Location = new System.Drawing.Point(3, 3);
        	this.tabControl1.Name = "tabControl1";
        	this.tabControl1.SelectedIndex = 0;
        	this.tabControl1.Size = new System.Drawing.Size(1121, 762);
        	this.tabControl1.TabIndex = 0;
        	// 
        	// tabPage3
        	// 
        	this.tabPage3.Controls.Add(this.button8);
        	this.tabPage3.Controls.Add(this.cloudgraph);
        	this.tabPage3.Location = new System.Drawing.Point(4, 25);
        	this.tabPage3.Name = "tabPage3";
        	this.tabPage3.Size = new System.Drawing.Size(1113, 733);
        	this.tabPage3.TabIndex = 2;
        	this.tabPage3.Text = "反光柱定位";
        	this.tabPage3.UseVisualStyleBackColor = true;
        	this.tabPage3.Click += new System.EventHandler(this.TabPage3Click);
        	this.tabPage3.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TabPage3MouseDoubleClick);
        	// 
        	// button8
        	// 
        	this.button8.Location = new System.Drawing.Point(706, 3);
        	this.button8.Name = "button8";
        	this.button8.Size = new System.Drawing.Size(111, 35);
        	this.button8.TabIndex = 13;
        	this.button8.Text = "清除";
        	this.button8.UseVisualStyleBackColor = true;
        	this.button8.Click += new System.EventHandler(this.Button8Click);
        	// 
        	// cloudgraph
        	// 
        	this.cloudgraph.BackColor = System.Drawing.Color.White;
        	this.cloudgraph.Location = new System.Drawing.Point(0, 0);
        	this.cloudgraph.Name = "cloudgraph";
        	this.cloudgraph.Size = new System.Drawing.Size(700, 700);
        	this.cloudgraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
        	this.cloudgraph.TabIndex = 12;
        	this.cloudgraph.TabStop = false;
        	this.cloudgraph.Click += new System.EventHandler(this.CloudgraphClick);
        	this.cloudgraph.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CloudgraphMouseDoubleClick);
        	// 
        	// tabPage1
        	// 
        	this.tabPage1.Controls.Add(this.get_location);
        	this.tabPage1.Location = new System.Drawing.Point(4, 25);
        	this.tabPage1.Name = "tabPage1";
        	this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage1.Size = new System.Drawing.Size(1113, 733);
        	this.tabPage1.TabIndex = 0;
        	this.tabPage1.Text = "轮廓数据";
        	this.tabPage1.UseVisualStyleBackColor = true;
        	this.tabPage1.Click += new System.EventHandler(this.TabPage1Click);
        	// 
        	// get_location
        	// 
        	this.get_location.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	// 
        	// 
        	// 
        	this.get_location.Aspect.View3D = false;
        	this.get_location.Aspect.ZOffset = 0D;
        	// 
        	// 
        	// 
        	// 
        	// 
        	// 
        	this.get_location.Axes.Right.Visible = false;
        	this.get_location.BackColor = System.Drawing.Color.Transparent;
        	// 
        	// 
        	// 
        	// 
        	// 
        	// 
        	this.get_location.Header.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        	// 
        	// 
        	// 
        	this.get_location.Header.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        	// 
        	// 
        	// 
        	this.get_location.Header.Font.Bold = true;
        	// 
        	// 
        	// 
        	this.get_location.Header.Font.Brush.Color = System.Drawing.Color.Black;
        	this.get_location.Header.Font.Size = 10;
        	this.get_location.Header.Font.SizeFloat = 10F;
        	this.get_location.Header.Lines = new string[] {
		"轮廓数据"};
        	// 
        	// 
        	// 
        	this.get_location.Legend.Visible = false;
        	this.get_location.Location = new System.Drawing.Point(3, 4);
        	this.get_location.Margin = new System.Windows.Forms.Padding(4);
        	this.get_location.Name = "get_location";
        	// 
        	// 
        	// 
        	// 
        	// 
        	// 
        	this.get_location.Panel.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        	// 
        	// 
        	// 
        	this.get_location.Printer.Landscape = true;
        	this.get_location.Series.Add(this.points1);
        	this.get_location.Size = new System.Drawing.Size(1106, 722);
        	// 
        	// 
        	// 
        	// 
        	// 
        	// 
        	this.get_location.SubFooter.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        	// 
        	// 
        	// 
        	this.get_location.SubFooter.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
        	// 
        	// 
        	// 
        	this.get_location.SubFooter.Brush.Gradient.Transparency = 100;
        	// 
        	// 
        	// 
        	// 
        	// 
        	// 
        	this.get_location.SubFooter.Font.Brush.Color = System.Drawing.Color.Green;
        	this.get_location.SubFooter.Font.Size = 7;
        	this.get_location.SubFooter.Font.SizeFloat = 7F;
        	// 
        	// 
        	// 
        	// 
        	// 
        	// 
        	this.get_location.SubFooter.Shadow.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        	// 
        	// 
        	// 
        	this.get_location.SubFooter.Shadow.Brush.Gradient.Transparency = 100;
        	this.get_location.TabIndex = 39;
        	// 
        	// 
        	// 
        	// 
        	// 
        	// 
        	this.get_location.Walls.Left.Visible = false;
        	// 
        	// points1
        	// 
        	this.points1.Color = System.Drawing.Color.Red;
        	this.points1.ColorEach = false;
        	this.points1.HorizAxis = Steema.TeeChart.Styles.HorizontalAxis.Both;
        	// 
        	// 
        	// 
        	this.points1.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(61)))), ((int)(((byte)(98)))));
        	// 
        	// 
        	// 
        	// 
        	// 
        	// 
        	this.points1.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
        	this.points1.Marks.Callout.ArrowHeadSize = 8;
        	// 
        	// 
        	// 
        	this.points1.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
        	this.points1.Marks.Callout.Distance = 0;
        	this.points1.Marks.Callout.Draw3D = false;
        	this.points1.Marks.Callout.Length = 0;
        	this.points1.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
        	// 
        	// 
        	// 
        	// 
        	// 
        	// 
        	this.points1.Pointer.Brush.Color = System.Drawing.Color.Red;
        	// 
        	// 
        	// 
        	this.points1.Pointer.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        	this.points1.Pointer.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        	this.points1.Pointer.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        	this.points1.Pointer.Brush.Gradient.UseMiddle = true;
        	this.points1.Pointer.Dark3D = false;
        	this.points1.Pointer.Draw3D = false;
        	this.points1.Pointer.HorizSize = 1;
        	this.points1.Pointer.InflateMargins = false;
        	// 
        	// 
        	// 
        	this.points1.Pointer.Pen.Color = System.Drawing.Color.Red;
        	this.points1.Pointer.Pen.Style = System.Drawing.Drawing2D.DashStyle.Dash;
        	this.points1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Circle;
        	this.points1.Pointer.VertSize = 1;
        	this.points1.SeriesData = resources.GetString("points1.SeriesData");
        	this.points1.ShowInLegend = false;
        	this.points1.Title = "points1";
        	// 
        	// 
        	// 
        	this.points1.XValues.DataMember = "X";
        	this.points1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
        	// 
        	// 
        	// 
        	this.points1.YValues.DataMember = "Y";
        	// 
        	// tabPage2
        	// 
        	this.tabPage2.Controls.Add(this.msgreceived);
        	this.tabPage2.Location = new System.Drawing.Point(4, 25);
        	this.tabPage2.Name = "tabPage2";
        	this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage2.Size = new System.Drawing.Size(1113, 733);
        	this.tabPage2.TabIndex = 1;
        	this.tabPage2.Text = "监听后台";
        	this.tabPage2.UseVisualStyleBackColor = true;
        	// 
        	// msgreceived
        	// 
        	this.msgreceived.FormattingEnabled = true;
        	this.msgreceived.ItemHeight = 15;
        	this.msgreceived.Location = new System.Drawing.Point(0, 0);
        	this.msgreceived.Name = "msgreceived";
        	this.msgreceived.Size = new System.Drawing.Size(1107, 724);
        	this.msgreceived.TabIndex = 1;
        	this.msgreceived.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MsgreceivedMouseDoubleClick);
        	// 
        	// timer1
        	// 
        	this.timer1.Enabled = true;
        	this.timer1.Interval = 50;
        	this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
        	// 
        	// serialPort1
        	// 
        	this.serialPort1.PortName = "COM4";
        	this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1DataReceived);
        	// 
        	// timer2
        	// 
        	this.timer2.Enabled = true;
        	this.timer2.Tick += new System.EventHandler(this.Timer2Tick);
        	// 
        	// Main_Form
        	// 
        	this.BackColor = System.Drawing.Color.White;
        	this.ClientSize = new System.Drawing.Size(1513, 800);
        	this.Controls.Add(this.splitContainer1);
        	this.Controls.Add(this.menuStrip1);
        	this.Name = "Main_Form";
        	this.Text = "P+F     R2000 2D Laser Scanner";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormFormClosing);
        	this.Load += new System.EventHandler(this.Main_FormLoad);
        	this.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_FormPaint);
        	this.menuStrip1.ResumeLayout(false);
        	this.menuStrip1.PerformLayout();
        	this.splitContainer1.Panel1.ResumeLayout(false);
        	this.splitContainer1.Panel2.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
        	this.splitContainer1.ResumeLayout(false);
        	this.groupBox4.ResumeLayout(false);
        	this.groupBox4.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.markdgv)).EndInit();
        	this.groupBox3.ResumeLayout(false);
        	this.groupBox2.ResumeLayout(false);
        	this.groupBox1.ResumeLayout(false);
        	this.groupBox1.PerformLayout();
        	this.tabControl1.ResumeLayout(false);
        	this.tabPage3.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.cloudgraph)).EndInit();
        	this.tabPage1.ResumeLayout(false);
        	this.tabPage2.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }
		void TabPage1Click(object sender, EventArgs e)
		{
	
		}
		void AGV定位ToolStripMenuItemClick(object sender, EventArgs e)
		{
	       
           
		}
		void 点云图ToolStripMenuItemClick(object sender, EventArgs e)
		{
			PointGraph en =new PointGraph ();
			en .Show ();
		}
		void Button6Click(object sender, EventArgs e)
		{
			if (button6 .Text =="连续定位")
			{
				timer1 .Start ();
				button6.Text ="停止定位";
				return ;
				
			}
			if (button6.Text =="停止定位")
			{
				timer1 .Stop  ();
				button6.Text ="连续定位";
				return ;
			}
			
		}
		public class OBJ
		{
			public double Mark{get ;set ;}
		}
		public class ceshi
		{
			private OBJ  obj;
			private double mark
			{
				get  {return obj.Mark ;}
			}
			public ceshi (  OBJ nn)
			{
				this .obj =nn  ;
			}
			public void display()
			{
				MessageBox .Show (mark. ToString ());
			}
		}
        public delegate void DiaplayXYAngle(TextBox box,string ss);
        public static void DisplayValue(TextBox box ,string ss)
        {
            try
            {
                if (box .InvokeRequired )
                {
                    box.BeginInvoke(new DiaplayXYAngle (DisplayValue ),new object[] { box ,ss });
                }
                else
                {
                    box.Text = ss;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public delegate void AddLISTBOX(ListBox BOX, String SS);
        public static void AddReceiveMsg(ListBox BOX, String SS)
        {
            try
            {
                if (BOX .InvokeRequired )
                {
                    BOX.BeginInvoke(new AddLISTBOX (AddReceiveMsg ),new object[] { BOX ,SS });
                }
                else
                {
                    BOX.Items.Add(SS );
                }
            }
            catch (Exception ex)
            {

            }
        }
        void Inidgv()
        {
        	for (int i=0;i<100;i++)
        	{
        		markdgv .Rows .Add ();
        		markdgv .Rows [i].Cells[0].Value ="-";
        		markdgv .Rows [i].Cells[1].Value ="-";
        		markdgv .Rows [i].Cells[2].Value ="-";
        		markdgv .Rows [i].Cells[3].Value ="-";
        		markdgv .Rows [i].Cells[4].Value ="删除";
        	}
        }
        public delegate void AddBAb(DataGridView dgv,List <TheLightNode > nodelist,List <TheLightNode >notlist);
        public static void AddDtValue(DataGridView dgv,List <TheLightNode > nodelist,List <TheLightNode >notlist)
        {
        	try 
        	{
        		if (dgv .InvokeRequired )
        		{
        			dgv .BeginInvoke (new AddBAb (AddDtValue),dgv ,nodelist );
        		}
        		  else{
        			if (LidarMode .GraphCreateState)
        			  {
        				for(int i=0;i<nodelist .Count ;i++)
                        {
						if (nodelist [i].X==0&&nodelist [i].Y ==0)
						{
						dgv .Rows [i].Cells [0].Value ="-" ;
						dgv .Rows [i].Cells [1].Value ="-";
						dgv .Rows [i].Cells [2].Value ="-" ;
						dgv .Rows [i].Cells [3].Value ="-" ;
						}
						else 
						{
						dgv .Rows [i].Cells [0].Value =nodelist [i].NumberNo ;
						dgv .Rows [i].Cells [1].Value =nodelist [i].X ;
						dgv .Rows [i].Cells [2].Value =nodelist [i].Y ;
						dgv .Rows [i].Cells [3].Value =nodelist [i].Angle  ;
						dgv .Rows [i].DefaultCellStyle .BackColor =Color .Green ;
						}
						for (int j=nodelist .Count ;j<dgv .Rows .Count ;j++)
						{
							dgv .Rows [j].Cells [0].Value ="-" ;
						    dgv .Rows [j].Cells [1].Value ="-";
						    dgv .Rows [j].Cells [2].Value ="-" ;
						    dgv .Rows [j].Cells [3].Value ="-" ;
						    dgv .Rows [j].DefaultCellStyle .BackColor =Color.White ;
						}
						
                     }
                    getmark .nodelist.Clear ();
        			}
        			else{
        				
        				if (LidarMode .IsNavicationMode )
        				{
        					for (int i=0;i<nodelist .Count ;i++)
        					{
        						if (nodelist [i].X!=0&&nodelist [i].Y !=0)
        						dgv .Rows [i].Cells [0].Value =nodelist [i].NumberNo ;
						        dgv .Rows [i].Cells [1].Value =nodelist [i].X ;
						        dgv .Rows [i].Cells [2].Value =nodelist [i].Y ;
						        dgv .Rows [i].Cells [3].Value =nodelist [i].Angle  ;
						        dgv .Rows [i].DefaultCellStyle .BackColor =Color .Red ;
        					}
        					for (int j=nodelist .Count ;j<dgv .Rows .Count ;j++)
						    {
							dgv .Rows [j].Cells [0].Value ="-" ;
						    dgv .Rows [j].Cells [1].Value ="-";
						    dgv .Rows [j].Cells [2].Value ="-" ;
						    dgv .Rows [j].Cells [3].Value ="-" ;
						    dgv .Rows [j].DefaultCellStyle .BackColor =Color.White ;
						    }
        					getmark .isnodelist.Clear ();
        				}
        				if (LidarMode .TargetDetectionState )
        				{
        					for (int i=0;i<nodelist .Count ;i++)
        					{
        						dgv .Rows [i].Cells [0].Value =nodelist [i].NumberNo ;
						        dgv .Rows [i].Cells [1].Value =nodelist [i].X ;
						        dgv .Rows [i].Cells [2].Value =nodelist [i].Y ;
						        dgv .Rows [i].Cells [3].Value =nodelist [i].Angle  ;
						        dgv .Rows [i].DefaultCellStyle .BackColor =Color .Red ;
        					}
        					
        					for (int k=nodelist .Count ,p=0;p<notlist .Count  ;k++,p++)
        					{  
								dgv .Rows [k].Cells [0].Value =notlist [p].NumberNo ;
						        dgv .Rows [k].Cells [1].Value =notlist [p].X ;
						        dgv .Rows [k].Cells [2].Value =notlist [p].Y ;
						        dgv .Rows [k].Cells [3].Value =notlist [p].Angle  ;
        						dgv .Rows [k].DefaultCellStyle .BackColor =Color .Green ;
						        
        					}
        					for (int j=nodelist .Count +notlist .Count;j<dgv .Rows .Count ;j++)
						    {
							dgv .Rows [j].Cells [0].Value ="-" ;
						    dgv .Rows [j].Cells [1].Value ="-";
						    dgv .Rows [j].Cells [2].Value ="-" ;
						    dgv .Rows [j].Cells [3].Value ="-" ;
						    dgv .Rows [j].DefaultCellStyle .BackColor =Color.White ;
						    }
        					getmark .isnodelist .Clear ();
        					getmark .nodelist .Clear ();
        				}
        			}
        		}
        	}
        	catch (Exception ex)
        	{
        		MessageBox .Show (ex .ToString ());
        	}
        }
        /// <summary>
        /// 靶标探测
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="dt"></param>
        /// <param name="nodelist"></param>
        public delegate void AddDtBaBiao(ref DataGridView dgv,ref DataTable dt,List <TheLightNode>nodelist);
        public static void AddDtValue(ref DataGridView dgv,ref DataTable dt,List <TheLightNode > nodelist)
        {
        	try 
        	{
        	
        		if (dgv .InvokeRequired )
        		{
        			dgv .BeginInvoke (new AddDtBaBiao(AddDtValue ),new object [] {dgv ,dt ,nodelist });
        		}
        		else 
        		{
					for(int i=0;i<nodelist .Count ;i++)
                   {
						if (nodelist [i].X==0&&nodelist [i].Y ==0)
						{
						dgv .Rows [i].Cells [0].Value ="-" ;
						dgv .Rows [i].Cells [1].Value ="-";
						dgv .Rows [i].Cells [2].Value ="-" ;
						dgv .Rows [i].Cells [3].Value ="-" ;
						}
						else 
						{
						dgv .Rows [i].Cells [0].Value =nodelist [i].NumberNo ;
						dgv .Rows [i].Cells [1].Value =nodelist [i].X ;
						dgv .Rows [i].Cells [2].Value =nodelist [i].Y ;
						dgv .Rows [i].Cells [3].Value =nodelist [i].Angle  ;
						}
						for (int j=nodelist .Count ;j<dgv .Rows .Count ;j++)
						{
							dgv .Rows [j].Cells [0].Value ="-" ;
						    dgv .Rows [j].Cells [1].Value ="-";
						    dgv .Rows [j].Cells [2].Value ="-" ;
						    dgv .Rows [j].Cells [3].Value ="-" ;
						}
						
                   }
                    getmark .nodelist.Clear ();
        		}
        	}
        	catch (Exception ex)
        	{
        		MessageBox .Show (ex .ToString ());
        	}
        }
        private int[] X_VALUE{get ;set ;}
        private int []Y_VALUE{get ;set ;}
        private float [] ANGLE_VALUE{get ;set ;}
        void DealGraph()
        {
               try 
               {
                  if (lidarclient .X_Value != null && lidarclient .Y_Value!=null )
                    {
                  	
                  	
                  	if (LidarMode .IsNavicationMode ||LidarMode .GraphCreateState ||LidarMode .TargetDetectionState )
                  	{
                  		AGV agv=new AGV ();
                        CreateCoordinate obj =new CreateCoordinate ();
			           agv .AgvLocation_X =350;
			           agv .AgvLocation_Y =350;
		               agv .AgvNo =1;
		               agv.Polar=new int[lidarclient .Polar_Value.Length ];
					   agv.Angle=new float[lidarclient .Angle_Value .Length ] ;						   
					   Array .Copy (lidarclient .Angle_Value ,0,agv.Angle ,0,lidarclient .Angle_Value .Length );
					   for (int i=0;i<lidarclient .Polar_Value .Length ;i++)
					   {
					   	agv .Polar [i]=lidarclient .Polar_Value [i]/27;					   	
					   }
					 // getmark.GetBaBiao (lidarclient .Polar_Value,lidarclient .Angle_Value,lidarclient .agv );				 
					 // AddDtValue (ref markdgv ,ref Dt ,getmark .nodelist );    
					   ThreadDraw(agv);
			          Graphics G =cloudgraph.CreateGraphics ();
			    	  G .Clear (Color .LightGray );
					  obj .DrawXY (cloudgraph );
                  	}
                  	else
                  	{
                  		//非导航模式，获取显示轮廓数据
                  		LidarSever.DrawScanPoint(get_location ,lidarclient .X_Value,lidarclient .Y_Value);
                  	}
                        
					  
			          GC .Collect ();
                      Application .DoEvents ();
                    }
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex .ToString ());
                }
         }
        public delegate void AddLooking(ListBox boxlist,string str);
        public void AddMsg(ListBox boxlist,string str)
        {
        	try{
        		if (boxlist .InvokeRequired )
        		{
        			boxlist .BeginInvoke (new AddLooking (AddMsg),new object []{boxlist ,str });
        			
        		}
        		else 
        		{
        			boxlist .Items .Add (str );
        		}
        	}
        	catch (Exception ex)
        	{
        		MessageBox .Show (ex .ToString ());
        	}
        }
       
        public void ThreadDraw(object obj)
        {
        	Thread th=new Thread (new ParameterizedThreadStart (DrawPIC));
        	th .IsBackground =true ;
        	th .Start (obj);
        }
        public void DrawPIC(object obj)
        {
        	AGV agv=obj as AGV ;
        	CreateCoordinate .CreatePoint (cloudgraph,agv ,5,Color .Red   ,1);
        }
        private void button7_Click(object sender, EventArgs e)
        {
        	if (button7 .Text =="扫描轮廓数据")
        	{
        		timer .Start ();
        		button7 .Text ="停止扫描";
        		return;
        	}
        	if (button7 .Text =="停止扫描")
        	{   
        		timer .Stop ();
        		button7 .Text ="扫描轮廓数据";
        		return ;
        	}
        }
        public void GraphDraw(object SENDER ,EventArgs E )
        {
        	Thread th=new Thread (DealGraph);
        	th.IsBackground =true ;
        	th .Start ();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            agv_x.Text = lidarclient.Robot_X.ToString();
            agv_y.Text = lidarclient.Robot_Y.ToString();
            agv_angle.Text = lidarclient.Robot_Angle.ToString();
        }
		void Main_FormPaint(object sender, PaintEventArgs e)
		{
	     CreateCoordinate  obj=new CreateCoordinate ();
			obj .DrawXY (cloudgraph );
		}
		void CloudgraphMouseDoubleClick(object sender, MouseEventArgs e)
		{
	      CreateCoordinate  obj=new CreateCoordinate ();
			obj .DrawXY (cloudgraph );
		}
		void CloudgraphClick(object sender, EventArgs e)
		{
	
		}
		void TabPage3Click(object sender, EventArgs e)
		{
	     	
			
		}
		void Button8Click(object sender, EventArgs e)
		{
			Graphics G =cloudgraph.CreateGraphics ();
			G .Clear (Color .LightGray );
			CreateCoordinate  obj=new CreateCoordinate ();
			obj .DrawXY (cloudgraph );
		}
		void TabPage3MouseDoubleClick(object sender, MouseEventArgs e)
		{
	        AGV agv=new AGV ();
			agv .AgvLocation_X =350;
			agv .AgvLocation_Y =350;
			agv .AgvNo =1;
			agv.Polar=new int[350];
			agv.Angle=new float[350] ;
			 int  j =0,k =360;
			int index =0;
			for (int i=0;i<350;i+=1)
			{
				
                agv .Polar [index]=i ;
				agv .Angle [index]=j ;
				j+=2;
				index ++;
			}
              CreateCoordinate obj =new CreateCoordinate ();
			 CreateCoordinate .CreatePoint (cloudgraph,agv ,2,Color .Red   ,1);
		}
		void Button5Click(object sender, EventArgs e)
		{
	       if (button5 .Text =="开始靶标探测")
	        {
	       	    LidarMode .GraphCreateState =false ;
	       	    LidarMode .IsNavicationMode =false ;
	       	    LidarMode .TargetDetectionState=true ;
	       	    lidarmode .Text ="靶标探测模式";
	      	    timer.Start ();
	      	    timer1 .Start ();
            	button5 .Text ="停止靶标探测";
            	lidarclient .World .QuartTimer .Start ();
            	return ;
            }
            if (button5.Text =="停止靶标探测")
            {
            	LidarMode .TargetDetectionState=false  ;
            	timer .Stop (); 
				timer1 .Stop  ();            	
            	button5 .Text ="开始靶标探测";
            	lidarclient .World .QuartTimer .Stop();
            	return ;
            }
		}
		void MarkdgvCellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			 if (MessageBox.Show("是否要删除此反光柱信息！", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
               if (markdgv .Columns [e.ColumnIndex ]is DataGridViewButtonColumn )
			  {
				if (e.RowIndex >-1)
				{
					int index =e .RowIndex ;
					markdgv .Rows [index ].Cells [0].Value ="-";
					markdgv .Rows [index ].Cells [1].Value ="-";
					markdgv .Rows [index ].Cells [2].Value ="-";
					markdgv .Rows [index ].Cells [3].Value ="-";
					markdgv .Rows [index ].DefaultCellStyle .BackColor =Color .White ;
				}
			}
         
            }
			
		}
		void MenuStrip1ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
	
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			if (lidarclient .Polar_Value!=null && lidarclient .Angle_Value !=null )
			{
				if (LidarMode .IsNavicationMode ||LidarMode .TargetDetectionState )
				{
				  DisplayValue(agv_x ,lidarclient .Robot_X .ToString ());
                  DisplayValue(agv_y ,lidarclient .Robot_Y .ToString ());
                 DisplayValue(agv_angle ,(lidarclient .Robot_Angle/1000) .ToString ());	
				}
//				Thread  th =new Thread (Displaydgv);
//				th .IsBackground =true ;
//				th .Start ();
				Displaydgv();
                            
			}	 
		}
	
		void Displaydgv()
		{
			getmark .GetBaBiao (lidarclient.agv ); 
            if (LidarMode .GraphCreateState )
            {
            AddDtValue(markdgv ,getmark .nodelist ,null );
            }
            else if (LidarMode .IsNavicationMode )
            {
            AddDtValue(markdgv ,getmark .isnodelist ,null );
            }
            else if (LidarMode .TargetDetectionState )
            {
             AddDtValue(markdgv ,getmark .isnodelist ,getmark .notnodelist  );
              }  
		}
		void SendLocationData(double x   ,double y ,double angle )
		{
			if (serialPort1 .IsOpen )
			{
			string send_x =Convert .ToString ((int )(x ),16).PadLeft (8,'0');
			string send_y =Convert.ToString ((int )(y),16).PadLeft (8,'0');
			string send_angle=Convert .ToString ((int )(angle ),16).PadLeft (8,'0');
			byte []senddata = { 0xdd,0xff,0x01,0x00,0x00,0x00,0x00,0x00,
                                           0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
                                           0x00,0x00,0x00};
			for (int i=0,j=0;i<send_x .Length ;i +=2,j++)
			{
				senddata[3+j]=Convert .ToByte (send_x.Substring (i,2),16);
				senddata[7+j]=Convert .ToByte (send_y.Substring (i,2),16);
				senddata[11+j]=Convert .ToByte (send_angle.Substring (i,2),16);
				
			}
			int  sum=0;
			for (int i=0;i<senddata .Length -1;i++)
			{
				sum +=senddata [i];
			}
			string ssd=(sum %256).ToString ();
			senddata [18]=Convert .ToByte (ssd) ;
			
				serialPort1 .Write  (senddata ,0,senddata .Length );
				BytetoStringAdd(senddata );
			}
			
		}
		void BytetoStringAdd(byte[] data)
		{
			string ss="";
			foreach(byte item in data )
			{
				ss +=Convert .ToString (item,16) +" ";
			}
			msgreceived .Items .Add (ss +"["+System .DateTime.Now .ToString ()+"]");
		}
		void GetSerialPort()
		{
			string name =serialPort1.PortName;
			if (name ==null )
			{
				MessageBox.Show ("本计算机无此端口！");
				return ;
			}
			else
			{
				serialPort1 .Open ();
				msgreceived .Items .Add ("串口"+name +"已经打开！");
				timer2 .Enabled=true ;
				timer2 .Start ();
			}
				
		}
		void SerialPort1DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
		{
	     
		}
		void 串口发送定位数据ToolStripMenuItemClick(object sender, EventArgs e)
		{
			GetSerialPort ();
			
		}
		void 激光雷达参数设置ToolStripMenuItemClick(object sender, EventArgs e)
		{
			ParameterSet_Form en =new ParameterSet_Form ();
			en .Show ();
		}
		void Timer2Tick(object sender, EventArgs e)
		{
			SendLocationData(lidarclient .agv .AgvLocation_X  ,lidarclient .agv .AgvLocation_X  ,lidarclient .agv .rotationangle);
		}
		void Button9Click(object sender, EventArgs e)
		{
			 if (MessageBox.Show("是否要读取雷达工作模式！", "注意！！！" , MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
			 	if(GetLidarWorkPara())
			{
				MessageBox .Show ("读取成功！");
			}
		    else 
		    {
		    	MessageBox .Show ("读取失败！");
		    }
			 }
			
		}
		void AGV定位测试ToolStripMenuItemClick(object sender, EventArgs e)
		{
	       double[] a = new double[5];
            double[] b = new double[5];
            double[] c = new double[5];
            double[] d = new double[5];
            double[] f= new double[5]; 
            a[0] = 0;
            a[1] = 12;
            a[2] = 32;
            a[3] = 24;
            a[4] = 23;
            a[0] = 1;
            b[1] = 17;
            b[2] = 22;
            b[3] = 23;
            b[4] = 40;
            c[0] = 2;
            c[1] = 16;
            c[2] = 39;
            c[3] = 23;
            c[4] = 20;
            d[0] = 3;
            d[1] = 45;
            d[2] = 76;
            d[3] = 23;
            d[4] = 67;
            c[0] = 4;
            c[1] = 19;
            c[2] = 35;
            c[3] = 30;
            c[4] = 32;
            AGV agv=new AGV ();
            List<double[]> iet = new List<double[]>();
            agv .IsBatter .Clear ();
            iet.Add(a);
            iet.Add(b);
            iet.Add(c);
            iet.Add(d);
            
            agv .IsBatter .AddRange (iet );
           AgvAbsoluteLocation jj = new AgvAbsoluteLocation(ref agv );
           MessageBox.Show(agv.AgvLocation_X .ToString ()+";"+agv .AgvLocation_Y .ToString ()+";"+agv .rotationangle .ToString ());
		}
		void Button10Click(object sender, EventArgs e)
		{
		  if (button10 .Text =="开启建图模式")
	      {
		  	LidarMode .GraphCreateState =true ;
		  	LidarMode .IsNavicationMode =false ;
		  	LidarMode .TargetDetectionState =false ;
		  	lidarmode .Text ="建图模式";
		  	timer.Start ();
		  	timer1 .Start ();
		   	button10.Text ="停止建图模式";
		   	MessageBox .Show ("已开启！");
		   	return ;
	      }
		  else
		  {
		  	LidarMode .GraphCreateState =false  ;
		  	timer .Stop ();
		  	timer1 .Stop  ();
		   	button10.Text ="开启建图模式";
		   	MessageBox .Show ("已停止！");
		   	return ;
		  }
		}
    }
}
