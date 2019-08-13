 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Data;
using Steema.TeeChart;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using  P_F_Interface;
using System.Collections;
using System.Net.NetworkInformation;
using LidarInterface ;


namespace LidarSeverData
{
    public class LidarSever
    {
     
        public LidarSever(string ip_str, int port_int)
        {
            this.port = port_int;
            this.ip = ip_str;
        }
        public LidarSever()
        {
           
        }
        public static bool NetConnState = true;
        public  bool  LidarConnState
        {
        	get ;
        	set ;
        }
        public List <HttpHandle >HandleList=new List<HttpHandle> ();/// 数据传输请求列表
        
        public Socket lidarclient = null;
        public Socket LidarClient
        {
            get { return lidarclient; }
        }
        private string ip;
        public string IP
        {
            get { return ip; }
            set {ip =value ;}
        }
        private int port;
        public int Port
        {
            get { return port; }
            set {port =value ;}

        }
        
        public  AGV agv =new AGV ();
        public double Robot_X
        {
            get { return agv .AgvLocation_X ; }
        }
        
        public double Robot_Y
        {
            get { return agv .AgvLocation_Y ; }
        }
        
        public double Robot_Angle
        {
            get { return agv .rotationangle ; }
        }
        
        
        private GraphAevironment g ;
        public GraphAevironment G
        {
        	get {return g ;}
        	set {g =value ;}
        }
        private CurrentWorld  world;
        public CurrentWorld World
        {
        	get {return world ;}
        	set {world =value ;}
        }
        
        private Thread receth;
        public Thread ReceTh
        {
            get { return receth; }

        }
        private Thread sendth;
        public Thread SendTh
        {
            get { return sendth; }
        }
        private int sendmsgtimestep;
        public int SendMsgTimeStep
        {
            get { return sendmsgtimestep; }
            set { sendmsgtimestep = value; }
        }

        private System.Timers.Timer sendtimer;
        public System.Timers.Timer SendTimer
        {
            get { return sendtimer; }
            set { sendtimer = value; }
        }
        
        
       #region 
       /// <summary>
       /// 轮廓数据的实时值 x(以机光雷达为中心)
       /// </summary>
       private int  [] x_value;
       public int [] X_Value
       {
       	get ;
       	set ;
       }
       /// <summary>
       /// 轮廓数据的实时值 y(以机光雷达为中心)
       /// </summary>
       private int [] y_value;
       public int [] Y_Value
       {
       	get ;
       	set ;
       }
       /// <summary>
       /// 轮廓数据的实时值 极角(以机光雷达为中心)
       /// </summary>
       private float  [] angle_value;
       public float  [] Angle_Value
       {
       	get;
       	set;
       }
       /// <summary>
       /// 轮廓数据的实时值 极轴(以机光雷达为中心)
       /// </summary>
       private int [] polar_value;
       public int[] Polar_Value
       {
       	get ;
       	set ;
       }
       public  int TheorySize{get ;set ;}//理论
       private int  FirstHeader;
       private int PackageLen;
       private byte[] Data;//
       private byte [] PartReceive;
       private int PartPointNum;
       private int AllPointNum;
       private int ScanSize;
       private int ScanPoint;//扫描一周的数据点数设定为3600
       
       #endregion
       #region 
       private double[] beforedata = new double[3];
       private double[] nowdata = new double[3];
       private string []recestrdata;

        private double[] pack_x;
        public double[] Pack_X
        {
            get { return pack_x; }
        }
        private double pack_x_AVE;
        public double Pack_X_AVE
        {
            get { return pack_x_AVE; }
        }
        private  double []bias_x;
        public double []Bias_X
        {
            get { return bias_x; }
        }
        private double[] pack_y;
        public double[] Pack_Y
        {
            get { return pack_y; }
        }
        private double pack_y_AVE;
        public double Pack_Y_AVE
        {
            get { return pack_y_AVE; }
        }
        private double[] bias_y;
        public double[] Bias_Y
        {
            get { return bias_y; }
        }

        private double[] pack_angle;
        public double[] Pack_Angle
        {
            get { return pack_angle; }
        }
        private double[] bias_angle;
        public double[] Bias_Angle
        {
            get { return bias_angle; }
        }
        private double pack_angle_AVE;
        public double Pack_Angle_AVE
        {
            get { return pack_angle_AVE; }
        }

        public int SampleNum
        {
            get;
            set;
        }
        public int SampleTimeStep
        {
            get;
            set;

        }
        private System.DateTime firstsample;

        private static int COUNTSUM;
        private double[] x_tem, y_tem, angle_tem;
        List <byte> bufferlist =new List<byte> ();//接受到的数据缓存
        List <byte >twobufferlist=new List<byte> ();
        private int singlepacklen = 6;
        private bool SendState=true ;
       #endregion
        void SendDataQuaryCode(object sender, EventArgs e)
        { 
          SendGetNumMessage("6665656477646704");//倍加福看门狗      
        }
        void InialSendQuary()
        {
        	Y_Value=new int[Para .PackageNum ] ;
        	X_Value=new int[Para .PackageNum ] ;
        	Angle_Value=new float[Para .PackageNum ] ;
        	Polar_Value=new int[Para .PackageNum] ;
        	
        	agv .Polar =new int[Para .PackageNum] ;
        	agv .Angle =new float[Para .PackageNum] ;
        	
            x_tem = new double[SampleNum];
            y_tem = new double[SampleNum];
            angle_tem = new double[SampleNum];
            pack_x= new double[SampleNum];
            pack_y = new double[SampleNum];
            pack_angle = new double[SampleNum];
            bias_x = new double[SampleNum];
            bias_y = new double[SampleNum];
            bias_angle = new double[SampleNum];
            sendtimer = new System.Timers.Timer();
            sendtimer.Elapsed += SendDataQuaryCode;
            sendtimer.Interval = sendmsgtimestep;
        }
        /// <summary>
        /// 计算平均值
        /// </summary>
        /// <param name="da"></param>
        /// <returns></returns>
        double ComputeAVE(double[] da)
        {
            double sum = 0;
            foreach (double item in da)
            {
                sum += item;
            }
            return sum / da.Length;
        }
        /// <summary>
        ///计算中位数
        /// </summary>
        /// <param name="da"></param>
        /// <returns></returns>
        double ComputeMidNumber(double[] da)
        {
            double middata=0;
            for (int i=0;i<da .Length;i++)
            {
                for (int j=i;j>0;j--)
                {
                    if (da [j]<da[j-1])
                    {
                        double tem = da[j];
                        da[j] = da[j - 1];
                        da[j - 1] = tem;
                    }
                }
            }
            if (da .Length% 2==0)
            {
                middata = (da[da.Length / 2] + da[da.Length / 2 + 1]) / 2;
            }
            else
            {
                middata = da[(int)(da.Length / 2 + 1)];
            }
            return middata;
        }
        /// <summary>
        /// 计算偏差
        /// </summary>
        /// <param name="dat"></param>
        /// <param name="middata"></param>
        /// <returns></returns>
        double [] ComputeBasi(double []dat ,double middata)
        {
            double[] basidata = new double[dat.Length];
            for (int i=0;i<dat .Length;i++)
            {
                basidata[i] = dat[i] - middata;
            }
            return basidata;
        }
        
       
         /// <summary>
        /// 绘制点云数据
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public delegate void DrawMainGraph(TChart chart, int [] x, int [] y);
        public static void  DrawScanPoint(TChart  chart, int [] x ,int [] y)
        {
            try
            {
                if (chart.InvokeRequired)
                {
                    chart.BeginInvoke(new DrawMainGraph(DrawScanPoint), new object[] { chart, x, y });
                }
                else
                {
                    chart.Series[0].Add(x,y );
       
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void DealReceData()
        {
        	Thread thb=new Thread (GetXYAnglePolar);
        	thb .IsBackground=true ;
        	thb .Start ();
        	
        }
        /// <summary>
        /// 数据解析
        /// </summary>
         /// <param name="data"></param>
         private void GetXYAnglePolar()
         {
         	
         	Data =twobufferlist .ToArray ();
         	twobufferlist .Clear() ;
        	int packlen=0,tenpacklen=0;
        	int packnum=0,tenpacknum=0;
        	int k=0;
            int   first_index=0;
        	double first_angle=0;
        	if (Data.Length >=Para .PackageNum)
        	{
        	while (true )
        	{          
           lock ((((ICollection)Data)).SyncRoot)
        	{
        	if (Data[packlen]==92&&Data[packlen+1]==162&&Data[packlen+2]==65&&Data [packlen+3]==0)//判断包头是否正确
        	{
        		tenpacklen =Data[packlen+4]+Data[packlen+5]*256+Data[packlen+6]*256*256+Data[packlen+7]*256*256*256;//本数据包的长度
        		tenpacknum =Data[packlen+40]+Data[packlen+41]*256;//本数据包中测量点的数量
        		
        		first_index =Data[packlen+42]+Data[packlen+43]*256; //本数据包中第一个测量点的排序
        	  //  first_angle =(data[packlen+44]+data[packlen+45]*256+data[packlen+46]*256*256+data[packlen+47]*256*256*256)/100000;//本数据包中第一个测量点的角度
        	    int tempacknn=tenpacknum;
        	    if (LidarMode .IsNavicationMode ||LidarMode .TargetDetectionState  )
        	    {
        	    	tempacknn=tenpacknum-1;
        	    }
        	   for (int i=packlen +80,j=0;j<tempacknn;i+=4,j++)//A类型数据格式，其距离值从每包下标为 80 开始
        		{
        			if (Data [i]==255&&Data [i+1]==255 &&Data [i+2]==255&&Data [i+3]==255)//数据无效判断
        			{
        				continue ;
        			}
        			/*
        			 此数据存储采用小端模式 
        			 */
        			string pola=Convert .ToString (Data [i+3],16)+Convert .ToString (Data [i+2],16)+Convert .ToString (Data [i+1],16)+Convert .ToString (Data [i],16);
        			polar_value [k] =Convert.ToInt32(pola,16);
        			if (polar_value [k]>Para .MAXDISTANCE )
        			{
        				polar_value [k] =0;
        			}
        		//	angle_value[k]=(float )(0.1 *k );//极角
        	    	angle_value [k]=(float )((first_index +j )*Para .AngleResolution );
        			x_value [k]=(int)(polar_value [k] * Math .Cos(Math .PI *angle_value [k]/180));//x 值
        			y_value [k]=(int)(polar_value [k] * Math .Sin(Math .PI *angle_value [k]/180));//y 值	
        			k ++;
        		}
        		packnum +=tenpacknum  ;//累加单圈内每个数据包中含的测量点的数量
        		packlen +=tenpacklen ;//累加单圈内每个数据包的长度
        		first_angle =0;
        		if (packnum==Para .PackageNum )
        		{
        			if (LidarMode .IsNavicationMode ||LidarMode .TargetDetectionState ||LidarMode .GraphCreateState )//在导航模式下进行简单的滤波
        			{
        			/*
        			 *简单滤波处理 
        			 */
        			for (int i=0;i<polar_value .Length ;i++)
        			{
        				for (int j=i+1 ;j<polar_value .Length ;j++)
        				{
        					if (polar_value [i] ==0&&polar_value [j]==0)
        					{
        						continue ;
        					}
        					else
        					{
        						if ((Math .Abs (angle_value [i]-angle_value [j])<=Para .ANGLEFILTER))
        						{
        							polar_value [j]=(int)0;
        							angle_value [j]=(int)0;
        							x_value [j]=(int)0;
        							y_value [j]=(int)0;
        						}
        					}
        				}
        			 }
        		   }
        			Array .Copy (x_value ,0,X_Value,0,x_value .Length  );
        			Array .Copy (y_value ,0,Y_Value ,0,y_value .Length );
        			Array .Copy (angle_value ,0,Angle_Value ,0,angle_value .Length);
        			Array .Copy (polar_value ,0,Polar_Value,0,polar_value .Length );
        			Array .Copy (Polar_Value ,0,agv .Polar ,0,Polar_Value  .Length );
		            Array .Copy (Angle_Value  ,0,agv .Angle ,0,Angle_Value .Length  );   
        			/*
        			 * 
        			 * 数据解析正确
        			 */
        			k=0;  		
        			Array .Clear (Data ,0,Data.Length );
        			break ;
        		}
        		else if (packnum>Para .TheoryPointNum  )
        		{
        			
        	    	MessageBox .Show ("数据解析错误");
        	    	Array .Clear (Data ,0,Data.Length );
        			break ;
        			
        		}
        	}
        	else
        	{
        		MessageBox .Show ("数据帧头错误");
        		Array .Clear (Data ,0,Data.Length );
        		break ;	
        	}
          } 	
         }
        	Application .DoEvents ();
           GC .Collect ();
          }
        }
        void ReceivingData()
        {
            while (lidarclient.Connected)
            {
                try
                {
              
                    int nRecvSize = lidarclient.Available;
                    byte[] acRecvDataBuf = new byte[nRecvSize];
                    string [] receivemsg=new string[nRecvSize ];
                    if (nRecvSize < 0)
                    {
                        continue;
                    }
                    else if (nRecvSize >0)
                    {
                    	string  SIZE=nRecvSize .ToString ();
                    }
                   
                    
                    lidarclient.Receive(acRecvDataBuf);
                    if (nRecvSize!=0)
                    {
                    if (acRecvDataBuf [0]==92&&acRecvDataBuf [1]==162&&acRecvDataBuf [2]==65&&acRecvDataBuf [3]==0)//第一帧
                    {
                    	if (acRecvDataBuf [12]==1)
                    	{
                    	FirstHeader=1;       	
                    	PackageLen =acRecvDataBuf [4]+acRecvDataBuf [5]*256 +acRecvDataBuf [6] *256*256  +acRecvDataBuf [7]*256*256*256;//包长
                        ScanPoint =acRecvDataBuf [38]+acRecvDataBuf [39]*256;//每个周期扫描的数据数量 设定为轮廓数据为3600，定位为225
                        x_value=new int[ScanPoint  ] ;
                        y_value=new int[ScanPoint ] ;
            			angle_value=new float[ScanPoint ] ;
            			polar_value=new int[ScanPoint ] ;
                    	}
                   
                    if (FirstHeader==1)
                    {
                    	PartPointNum =acRecvDataBuf [40]+acRecvDataBuf [41]*256;//本数据包中测量点的数量
                    	bufferlist.AddRange(acRecvDataBuf .ToList());//一级缓存
                      if (bufferlist .Count >=TheorySize )
                    	{	
                      		if (LidarMode .IsNavicationMode)
                      		{   //导航模式
                      			bufferlist .RemoveRange (PackageLen ,bufferlist .Count -PackageLen );
                      		}
                      		else 
                      		{   //获取轮廓数据
                      			bufferlist .RemoveRange(TheorySize ,bufferlist .Count -TheorySize );
                      		}
                      		
                      		byte []data =bufferlist .ToArray ();
                      		bufferlist .Clear ();
                      		FirstHeader  =0;
                     	if (CheckPackageNumber(PackageLen,data ))//校验包号
                    		{
                     		twobufferlist.AddRange (data .ToList ());//二级缓存
                     		
                    		/*
                    		 *处理数据 
                    		 */
                    			DealReceData();
                          }  
                    	 }
                       }
                     }
                   }
                    Thread .Sleep (1);
                    GC .Collect ();
                    Application .DoEvents ();
                }
             
                catch (Exception ex)
                {
         	    MessageBox .Show (ex .ToString ());    	
                }
            }
            
        }
        /// <summary>
        /// 检查包长度
        /// </summary>
        /// <param name="packagelen"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        bool  CheckPackageNumber(int packagelen,byte[] data)
        {
        	for (int i=12,j=1;i<Para .TheoryPointNum   ;i +=packagelen,j  ++)
        	{
        		if (data [i]!=(byte )j )
        		{
        			return false ;
        		}
        	}
        	return true ;
        }
        /// <summary>
        /// 出事话相关参数
        /// </summary>
        public void InialPara()
        {
        	 g = RWTheLight .LoadTheLightMsg ();
        	 world=new CurrentWorld (g ,agv );
       	     world .QuaryStep =50;
       	     world .InialQuary ();
        }
        /// <summary>
        /// 获取agv定位数据
        /// </summary>
       public  void DealingData()
       {
      

       }
      
        /// <summary>
        ///通过ping判断通讯状态(超时判断)
        /// </summary>
        /// <param name="ip"></param>需要ping的ip地址
        /// <returns></returns>
        public bool judgeNetConnent(string ip)
        {
            bool _res = false;


            Ping p = new Ping();
            PingOptions pOption = new PingOptions();
            pOption.DontFragment = true;
            string data = "Test Data!";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            //        	int timeout=150;
            int timeout = 800;//超过800MS默认为断连

            PingReply reply = p.Send(ip, timeout, buffer, pOption);
            if (reply.Status.Equals(IPStatus.Success))
            {
                _res = true;

            }
            else
            {
                _res = false;
            }

            return _res;

        }
        public bool ConnentOrDisconnent()
        {
            bool res = false;

            try
            {
                if (judgeNetConnent (ip ))
                {
                    if (NetConnState)//网络连接
                    {
                        if (lidarclient == null)
                        {
                            lidarclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建负责通信的Socket
                            IPAddress ipe = IPAddress.Parse(ip );
                            IPEndPoint point = new IPEndPoint(ipe, Port);//获得要连接的远程服务器应用程序的IP地址和端口号
                            lidarclient.BeginConnect(point, new AsyncCallback(ConnectCallback), lidarclient);
                            //  NetConnState = false;

                             Thread.Sleep(50);
                            if (lidarclient.Connected == true)
                            {
                                InialSendQuary();//初始化事件
                                receth = new Thread(ReceivingData);
                                receth.IsBackground = true;
                                receth.Start();
                                sendth = new Thread(DealingData);
                                sendth.IsBackground = true;
                                sendth.Start();
                                sendtimer .Start ();
                                res = true;
                                NetConnState = false;
                                LidarConnState =true ;
                            }
                            else
                            {
                                lidarclient.Close();
                                lidarclient.Dispose();
                                lidarclient = null;
                                LidarConnState =false ;
                                sendtimer.Stop ();
                            }

                        }
                    }
                    else
                    {
                        if (lidarclient != null)
                        {
                            if (lidarclient.Connected)
                                lidarclient.Disconnect(false);
                            lidarclient.Close();
                            lidarclient.Dispose();
                            lidarclient = null;
                            receth.Abort();
                            sendth.Abort();
                            NetConnState = true;
                            LidarConnState =false ;
                             sendtimer.Stop ();

                        }
                    }
                }
                else
                {
                    MessageBox.Show("网络中断，请检查网络");
                }
               
              //  return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex .ToString ());
            }
            return res;
        }
        /// <summary>
        /// 关闭雷达服务
        /// </summary>
        /// <param name="sender"></param>
        public void CloseLidarClient(object sender,LidarSever lidar)
        {
            Form objfrm = sender as Form;
            if (lidar.lidarclient != null)
            {
                if (lidar.lidarclient.Connected)
                    lidar.lidarclient.Disconnect(false);
                lidar.lidarclient.Close();
                lidar.lidarclient.Dispose();
                lidar.lidarclient = null;
            }
            if (lidar.sendth   != null)
            {
                lidar.sendth.Abort();
                lidar.sendth = null;
            }
            if (lidar.receth != null)
            {
                lidar.receth.Abort();
                lidar.receth = null;
            }
            objfrm.Controls.Clear();
        }
         private  void ConnectCallback(IAsyncResult ar)
        {
            Socket t = (Socket)ar.AsyncState;
            try
            {
                if (t.Connected)
                    t.EndConnect(ar);//函数运行到这里就说明连接成功
                else
                {

                }
            }
            catch (Exception ex)
            { }
        } /// <summary>
          /// 字符串转化为字节数组
          /// </summary>
          /// <param name="command">要转为为字节数组的字符串</param>
          /// <returns>转换后的字节数组</returns>
        public  byte[] StringToBytes(string command)
        {

            byte[] comuni = new byte[command.Length / 2];
            for (int i = 0, j = 0; i < command.Length && j < command.Length / 2; i = i + 2, j++)
            {
                string temp = command.Substring(i, 2);
                comuni[j] = Convert.ToByte(temp, 16);//表示是16进制的

            }
            return comuni;

        }
        public  void SendMessage(string Ord)
        {
            try
            {
                if (lidarclient.Connected)
                {
                    byte[] ord_buf =StringToBytes(Ord);
                    lidarclient.Send(ord_buf);
                }
            }
            catch
            { }
        }
        public int SendGetNumMessage(string Ord)
        {
            int sendnum = 0;
            if (lidarclient != null)
            {
               if (lidarclient.Connected)
                {
                    byte[] d_byte =StringToBytes(Ord);
                    sendnum = lidarclient.Send(d_byte);
                }
            }
            return sendnum;

        }
    }
    public static class ScanData
    {
    	public static int [] X_VALUE=new int[3600] ;
    	public static int [] Y_VALUE =new int[3600] ;
    	public static float  [] ANGLE_VALUE=new float[3600] ;
    	public static float [] POLAR=new float[3600] ;
    }
}
