/*
 * Created by SharpDevelop.
 * User: ZJUCAOBIN
 * Date: 2019/3/21
 * Time: 9:55
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
using System .Linq ;
using System .Threading ;
using System .Collections ;
using Newtonsoft .Json ;
using P_F_Interface ;
namespace LidarInterface
{

	/// <summary>
	/// 主要用于标靶探测和获取标靶
	/// </summary>
	public class SingleAgv
	{
       
		private int xoydirction;
		private double [] agvlocator;
		public double [] AgvLocator//Length =4;
		{
			get {return agvlocator;}
		}
		private  List <double []>barrierlocator=new List<double[]> () ;
		public  List <double []> BarrierLocator //Length =4;
		{
			get {return barrierlocator ;}
		}
		private AGV  agv;
		public  AGV Agv
		{
			get {return agv ;}
		}
		/// <summary>
		/// AGV在全局坐标系下坐标 /反光柱与AGV的距离角度
		/// </summary>
		/// <param name="datalisttem"></param>反光柱与AGV的距离和角度
		/// <param name="agvpointem"></param>AGV在全局坐标系下坐标
		public SingleAgv(AGV agvtem)
		{
			this .agv =agvtem;
			xoydirction =0 ;
			SwitchXoY();
		}
        public SingleAgv(AGV agvtem, int swyox)
        {
            this.agv = agvtem;
            this.xoydirction = swyox;
            SwitchXoY();
        }
		/// <summary>
		/// 获得反光柱子和单个AGV在全局坐标系下的坐标信息
		/// </summary>
		void SwitchXoY()
		{
			int  k=1;
			if (xoydirction ==0)
			{
				
			for  (int i=0;i< agv .NotBatter .Count  ;i ++)
			{
				Coordinate newcoord=new Coordinate (agv .NotBatter[i][4],agv .NotBatter[i][3]);
			    agvlocator =new double[5] ;
				double [] itemm=new double[5];
                itemm[0] = (double)agv .NotBatter[i][0];//反光柱序号
                //根据机器人在世界坐标系下的坐标换算探测到的反光柱的坐标
                 itemm[1] = agv.AgvLocation_X + newcoord.X * Math.Cos(agv.rotationangle/1000 *Math .PI /180 ) + newcoord.Y * Math.Sin(agv.rotationangle/1000 *Math .PI /180);// 反光柱在全局坐标下X值
                 itemm[2] = agv.AgvLocation_Y + newcoord.Y * Math.Cos(agv.rotationangle/1000 *Math .PI /180) - newcoord.X * Math.Sin(agv.rotationangle/1000 *Math .PI /180);//反光柱在全局坐标下Y值
                 agv .NotBatter[i][1]=itemm[1] ;
                 agv .NotBatter[i][2]=itemm[2] ;
				itemm [3]=agv .NotBatter[i][3];//反光柱在局部坐标下角度
				itemm [4]=agv .NotBatter[i][4];//反光柱在局部坐标下的极轴长度
				barrierlocator .Add (itemm);
				agvlocator[0]=agv .AgvNo ;
				agvlocator [1]=agv.AgvLocation_X ;
				agvlocator [2]=agv .AgvLocation_Y ;
				double poal=Math .Sqrt (Math .Pow (agv.AgvLocation_X,2)+Math .Pow (agv.AgvLocation_Y ,2));
				double ang=Math .Asin (agv.AgvLocation_X/poal )/ Math .PI  *180;
				agvlocator [3]=ang ;
				agvlocator [4]=poal ;
				k++;
			}
			}
			else 
			{
				for  (int i=0;i< agv .Polar .Length   ;i ++)
			   {
				Coordinate newcoord=new Coordinate (agv .Polar [i],agv .Angle [i]);
			    agvlocator =new double[5] ;
				double [] itemm=new double[5];
                itemm[0] = (double)k;//反光柱序号 
                //用于作图
                itemm[1] = agv.AgvLocation_X + newcoord.X;//反光柱在全局坐标下X值
                itemm[2] = agv.AgvLocation_Y - newcoord.Y;//反光柱在全局坐标下Y值 
				itemm [3]=agv .Angle [i];//反光柱在局部坐标下角度
				itemm [4]=agv .Polar [i];//反光柱在局部坐标下的极轴长度
				barrierlocator .Add (itemm);	
				agvlocator[0]=agv .AgvNo ;
				agvlocator [1]=agv.AgvLocation_X ;
				agvlocator [2]=agv .AgvLocation_Y ;
				double poal=Math .Sqrt (Math .Pow (agv.AgvLocation_X,2)+Math .Pow (agv.AgvLocation_Y ,2));
				double ang=Math .Asin (agv.AgvLocation_X/poal )/ Math .PI  *180;
				agvlocator [3]=ang ;
				agvlocator [4]=poal ;
				k++;
			}
		   }
		}
	}
	public class AGV
{

    public byte AgvNo;
    public int  []Polar;//探测到的反光柱的极轴长
    public float  []Angle;//探测到的反光柱的极角
    public List <double []>IsBatter= new List<double[]> ();//已经识别匹配到的反光柱信息集合
    public List <double []>NotBatter= new List<double[]> ();//未识别匹配到的反光柱信息集合
    public List <double []>DisIsBatter= new List<double[]> ();//已经识别匹配到的反光柱信息集合
    public double AgvLocation_X//agv当前的位置（X,Y）
    {
     get;
     set;
    }
    public double AgvLocation_Y
    {
     get;
     set;
    }
public double rotationangle;//AGV当前的坐标系相对全局坐标系的旋转角度；
}
public class AgvAbsoluteLocation
{
    public AgvAbsoluteLocation ( ref AGV agvv)
    {
        
        this .agv =agvv ;
        CalcuteAverage();
    }
    private double [,] iniavalue;
    private int [,] combination ;
    private AGV agv ;
//    public AGV Agv
//    {
//        get { return agv; }
//
//    }
    /* batterlocation[0]: 反光柱编号
     * batterlocation[1]: 世界坐标  Y
     * batterlocation[2]: 世界坐标  X
     * batterlocation[3]: 局部坐标极角
     * batterlocation[4]: 局部坐标极轴
     */
   
    public List<double[]> Batterlocation
    {
    get { return agv .IsBatter ; }
    }
   public  void CalcuteAverage()
    {
   	    if (agv .IsBatter.Count==0)
      	{
   	    	return ;
   	    }
        CalcuteAgvLocation();
        double x = 0, y = 0, ang = 0;
        int lenx =0;int leny=0;int lenangle=0;
        double firstangle;
        for  (int i=0;i< iniavalue.GetLength (0);i++)
        {
        	 if (agv .IsBatter.Count >=3)
            {   	 
        	 if (!double .IsNaN (iniavalue[i, 0]))
        	{
                 agv.AgvLocation_X = Math .Round (iniavalue[i, 0] ,3);
        	}
        	if (!double .IsNaN (iniavalue[i, 1]))
        	{
        		agv.AgvLocation_Y = Math .Round(iniavalue[i, 1] ,3); 
        	}
        	if (!double .IsNaN (iniavalue[i, 2]))
        	{
        		ang = iniavalue[i,2];
        		agv.rotationangle = Math .Round(ang,0);
        		
        	}	
        	CurrentWorld .timeeror =System .DateTime .Now ;
        	}
        }
        
        if (agv .IsBatter.Count <3)
        {
        	TimeSpan  sqp =System .DateTime .Now -CurrentWorld .timeeror ;
        	if (sqp .Seconds >Para .TIMETOLERANCE )//反光柱识别时间容差
        	{
             agv.AgvLocation_X = 0 ;
             agv.AgvLocation_Y =0;
             agv.rotationangle = 0;
        	}
        }
       
       agv .IsBatter .Clear ();        
    }  
   void  CalcuteAgvLocation()
    {
        GetCombination(agv .IsBatter .Count );
        iniavalue = new double[combination .GetLength (0),3];
        for (int i=0;i<combination .GetLength (0);i++)
        {
            double[]item_a,item_b,item_c= new double[5];
            item_a = agv .IsBatter[combination[i,0]];
            item_b = agv.IsBatter[combination[i,1]];
            item_c= agv.IsBatter[combination[i,2]];
            double[] vall = new double[2];
            double  an=new double();
            vall= GetPoint(item_a[1], item_b[1], item_c[1], item_a[2], item_b[2], item_c[2], item_a[4], item_b[4], item_c[4]);
            an= Getangle(item_a[1], vall[0], item_a[4] * Math .Cos (item_a[3]*Math .PI / 180), item_a[2], vall[1], item_a[4]* Math.Sin (item_a[3]*Math .PI / 180));
            iniavalue[i, 0] = vall[0];
            iniavalue[i, 1] = vall[1];
            iniavalue[i, 2] =an;
        }

    }
    /// <summary>
    /// 输出C(N,3)的组合
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    void   GetCombination(int n )
    {
       combination = new int[GetCombinationNum(n,3),3];
        List<string > tt = new List<string >();
        int cc = 0;
        for (int i=0;i <n;i ++)
        {
            for (int j=i+1; j<n;j ++)
            {
                for (int  k=j+1;k<n;k++)
                { 
                    if(i!=j && i !=k && j != k )
                    {
                        combination[cc, 0] = i;
                        combination[cc, 1] = j;
                        combination[cc, 2] = k;
                        cc++;
                    }

                }
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="x1"></param>
    /// <param name="x0"></param>
    /// <param name="xp"></param>
    /// <param name="y1"></param>
    /// <param name="y0"></param>
    /// <param name="yp"></param>
    /// <returns></returns>
    double Getangle(double x1,double x0,double xp, double y1, double y0, double yp)
    {
        double value = 0;
        double child_sin = x1 * yp - y1 * xp + y0 * xp - x0 * yp;
        double child_cos =x1 *xp +y1 *yp -x0 *xp -y0 *yp ;
        double father = Math.Pow(yp, 2) + Math.Pow(xp, 2);
        
        double sin=child_sin /father ;
        double cos =child_cos /father ;
        if ((sin >=0&& cos <=0)||(sin <=0&& cos <=0))
        {
        	 value =180- Math.Asin(sin)/(double )Math.PI*180  ;
        }
        else if (sin <=0&& cos >=0)
        {
        	 value =360+ Math.Asin(sin)/(double )Math.PI*180  ;
        }
        else 
        {
        	 value = Math.Asin(sin)/(double )Math.PI*180  ;
        }
        return value*1000;
    }
    /// <summary>
    /// 计算机器人在全局坐标下的坐标
    /// </summary>
    /// <param name="x1"></param>
    /// <param name="x2"></param>
    /// <param name="x3"></param>
    /// <param name="y1"></param>
    /// <param name="y2"></param>
    /// <param name="y3"></param>
    /// <param name="L1"></param>
    /// <param name="L2"></param>
    /// <param name="L3"></param>
    /// <returns></returns>
   double [] GetPoint (double  x1,double  x2, double x3, double y1, double y2, double y3, double L1,double L2,double L3)
    {
        double X = 0,Y = 0;
        double[] poin = new double[2];
        double child_x = (Math.Pow(L1, 2) - Math.Pow(L2, 2)) * (y2 - y3) - (Math.Pow(L2, 2) - Math.Pow(L3, 2)) * (y1 - y2) - (y1 - y2) * (y2 - y3) * (y1 - y3) + (Math.Pow(x2, 2) - Math.Pow(x3, 2)) * (y1 - y2) - (Math.Pow(x1, 2) - Math.Pow(x2, 2)) * (y2 - y3);
        double child_y= (Math.Pow(L1, 2) - Math.Pow(L2, 2)) * (x2 - x3) - (Math.Pow(L2, 2) - Math.Pow(L3, 2)) * (x1 - x2) - (x1 - x2) * (x2 - x3) * (x1 - x3) + (Math.Pow(y2, 2) - Math.Pow(y3, 2)) * (x1 - x2) - (Math.Pow(y1, 2) - Math.Pow(y2, 2)) * (x2 - x3 );
        double father_x = 2 * ((x1 - x3) * (y1 - y2) - (x1 - x2) * (y2 - y3));
        double father_y = -father_x;
        poin[0] = child_x/father_x;
        poin[1] = child_y / father_y;

        return poin;
    }
    int GetCombinationNum(int n ,int m )
    {
        return CalculateFactorial(n) / (CalculateFactorial(m) * CalculateFactorial(n - m));

    }
    int  CalculateFactorial(int value)
    {
        int mu = 1;
        for (int i=value;i>0;i--)
        {
            mu = mu * i;
        }
        return mu;
    }


}

public class TheLightNode//环境中添加的反光柱
{
	
	public byte NumberNo{get ;set ;}//世界坐标下的反光柱的编号
	public double X{get ;set ;}//世界坐标下的X
	public double Y{get ;set ;}//世界坐标下的Y
	public double Angle{get ;set ;}//世界坐标下的极角
	public double Polar{get ;set;}//世界坐标下的极轴 	
}
public class  GraphAevironment
{

  
	private  TheLightNode[] Node;
	public TheLightNode [] NODE
	{
		get {return Node ;}
	}
	private int numEdge;
	private double  [,] Matrix;
	public  double [,]MATRIX
	{
		get {return Matrix ;}
	}
	public GraphAevironment (int n)
	{
		Node =new TheLightNode[n] ;
		Matrix =new double[n,n] ;
		numEdge =0;
	}
	/// <summary>
	/// 获取定点信息
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public  TheLightNode  GetNode(int index)
	{
		return Node [index ];
	}
	public int GetNodeNum()
	{
		return Node .Length ;
	}
	/// <summary>
	/// 设置定点信息
	/// </summary>
	/// <param name="index"></param>
	/// <param name="node"></param>
	public void SetNode(int index,TheLightNode node)
	{
		Node [index ]=node ;
	}
	//边的数目属性 
    public int NumEdges 
    { 
    get 
    { 
    return numEdge; 
    } 
    set 
    { 
   
    numEdge = value; 
    } 
    }
    /// <summary>
    /// 获取边的信息
    /// </summary>
    /// <param name="index1"></param>
    /// <param name="index2"></param>
    /// <returns></returns>
    public  double GetMatrix(int index1,int index2)
    {
    	return Matrix[index1,index2];
    }
    /// <summary>
    /// 设置边的信息
    /// </summary>
    /// <param name="index1"></param>
    /// <param name="index2"></param>
    /// <param name="value"></param>
    public void SetMatrix(int index1,int index2, double  value)
    {
    	Matrix [index1 ,index2 ]=value;
    }
    /// <summary>
    /// 判断是否是其节点
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public bool IsNode(TheLightNode node)
    {
    	foreach (TheLightNode item in Node )
    	{
    		if (-Para .XYERROR <=(item .X -node .X)&&(item .X -node .X)<=Para .XYERROR  )
    		{
    			if (-Para .XYERROR <=(item .Y  -node .Y )&&(item .Y  -node .Y )<=Para .XYERROR  )
    			{
    				return true ;
    			}
    			
    		}
    	}
    	return false ;
    }
    /// <summary>
    /// 获取节点的编号
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public int GetNodeIndex(TheLightNode node)
    {
    	int indexx=-1;
    	for (int i=0;i<Node .Length ;i++)
    	{
    		if (-Para .XYERROR <=(Node[i] .X -node .X)&&(Node[i] .X -node .X)<=Para .XYERROR  )
    		{
    			if (-Para .XYERROR <=(Node[i] .Y  -node .Y )&&(Node[i] .Y  -node .Y )<=Para .XYERROR  )
    			{
    			  indexx =i ;
    		    }
    		}
    	}
    	
    	return indexx ;
    }
    /// <summary>
    /// 添加边
    /// </summary>
    /// <param name="node1"></param>
    /// <param name="node2"></param>
    /// <param name="value"></param>
    public void SetEdge(TheLightNode node1,TheLightNode node2,double value)
    {
    	if (!IsNode (node1 )||!IsNode (node2 ))
    	{
    		MessageBox .Show ("没有加入此节点反光柱！");
    		return ;
    	}
    	else 
    	{
    		Matrix [GetNodeIndex (node1),GetNodeIndex (node2)]=value ;
    		Matrix [GetNodeIndex (node2),GetNodeIndex (node1)]=value ;
    		++numEdge ;
    	}
    }
    /// <summary>
    /// 删除边
    /// </summary>
    /// <param name="node1"></param>
    /// <param name="node2"></param>
     public void DeleEdge(TheLightNode node1,TheLightNode node2)
    {
    	if (!IsNode (node1 )||!IsNode (node2 ))
    	{
    		MessageBox .Show ("没有加入此节点反光柱！");
    		return ;
    	}
    	else 
    	{
    		Matrix [GetNodeIndex (node1),GetNodeIndex (node2 )]=0 ;
    		Matrix [GetNodeIndex (node2),GetNodeIndex (node1 )]=0;
    		--numEdge ;
    	}
    }
     /// <summary>
     /// 判断两个反关柱之间是否添加边
     /// </summary>
     /// <param name="node1"></param>
     /// <param name="node2"></param>
     /// <returns></returns>
     public bool IsExistEdge(TheLightNode node1,TheLightNode node2)
     {
     	if (!IsNode (node1 )||!IsNode (node2 ))
    	{
    		MessageBox .Show ("没有加入此节点反光柱！");
    		return  false ;
    	}
     	else 
     	{
     		if (Matrix [GetNodeIndex (node1),GetNodeIndex (node2)]==0)
     		{
     			return false  ;
     		}
     		else 
     		{
     			return true ;
     		}
     	}
     }
     /// <summary>
     /// 根据两个反光柱之间的距离提取两个反光柱的坐标信息
     /// </summary>
     /// <param name="value"></param>
     /// <returns></returns>
     public TheLightNode [] GetEdgeNode(double value)
     {
     	TheLightNode[] node=new TheLightNode[2] ;
     	node [0] =new TheLightNode ();
     	node [1]=new TheLightNode ();
     	for (int i=0;i<Matrix .GetLength(0) ;i++)
     	{
     		for (int j=0;j< Matrix .GetLength (1);j++)
     		{
     			if (-Para .LENERROR <=(Matrix [i,j]-value ) && (Matrix [i ,j ]-value )<=Para .LENERROR )
     			{
     				
     				node [0]=GetNode (i);
     				node [1]=GetNode (j);			
     			}
     		}
     	}
     	return  node ;
     }
     /// <summary>
     /// 
     /// </summary>
     /// <param name="edge"></param>
     /// <returns></returns>
     public  TheLightNode[]  GetCurrentWorldCoordinate( double [,] edge)
     {
     	TheLightNode [] wordxy =new TheLightNode[edge .GetLength (0)] ;
            int k = 0;
     	for (int i=0;i<edge .GetLength (0);i++)
     	{
     		List <TheLightNode>nodelist =new List<TheLightNode> ();
     		for (int j=0;j<edge .GetLength (1);j++)
     		{
     			if (i !=j && edge [i,j]!=0 )
     			{
     				TheLightNode[] node=new TheLightNode [2];
     				node [0]=new TheLightNode ();
     				node [1]=new TheLightNode ();
     				node =GetEdgeNode (edge [i,j]);
     				if (node !=null )
     				{
     				nodelist .Add (node[0]);
     				nodelist .Add (node [1]);
     				}
     		    }
     		}
     		var res =from n in nodelist
     			   group n by n into g
     			   orderby  g.Count() 
     			   descending
     			   select g ;
     		   if (nodelist.Count >=4  )
     		   {
     		   var gr =res .First ();
     		   foreach (TheLightNode itenn in gr )
     		   {
     			wordxy[k]=new TheLightNode ();
     			wordxy [k]=itenn ;
                k++;
                break;
     		   }	
     	       }
     	        else 
     	       {
     	       wordxy[k]=new TheLightNode ();
     	       wordxy [k]=null ;
     	       k ++;
     	       }
     }
     
    return wordxy ;
  }
}
public class CurrentWorld
{
	private GraphAevironment G;
	private  AGV agv;
	public static DateTime timeeror;
	public AGV Agv
	{
		get {return agv ;}
		set {agv =value ;}
	}
	public CurrentWorld (GraphAevironment g ,AGV car)
	{
		
		this .agv =car ;
		this .G =g ;
		
	    
	}
	private System .Timers .Timer quarttimer=new System.Timers.Timer ();
	public System .Timers .Timer QuartTimer
	{
		get {return quarttimer ;}
		set {quarttimer =value ;}
	}
	private Thread quaryth;
	public Thread QuaryTh
	{
		get {return quaryth ;}
		set {quaryth =value ;}
	}
	private int quarystep=50;
	public int QuaryStep
	{
		get {return quarystep ;}
		set {quarystep =value ;}
	}
	/// <summary>
	/// 
	/// </summary>
	public void InialQuary()
	{
		quarttimer .Elapsed +=ComupteRobotLocation;
		quarttimer .Interval =quarystep ;
		
	}
	void ComupteRobotLocation(object sender,EventArgs e)
	{
		Thread th =new Thread (GetAGVLocation);
		th .IsBackground =true ;
		th .Start ();
	}
	/// <
	/// summary>
	/// 
	/// </summary>
	 void GetAGVLocation()	
	{
	 	if (agv .Polar!=null &&agv .Angle !=null )
	 	{
	 	int [] poalte=agv .Polar .ToList ().Distinct ().ToArray ();
	 	float [] antem=agv .Angle .ToList ().Distinct ().ToArray ();
	 	double [,]edge=new double[poalte .Length ,poalte.Length ] ;	
		TheLightNode [] worldcoord =new TheLightNode[poalte .Length] ;
		for (int i=0;i<poalte.Length ;i++)
		{
			worldcoord [i]=new TheLightNode ();
		}
		edge=GetEdge (poalte ,antem );
		worldcoord =G.GetCurrentWorldCoordinate (edge);
		GetBatter (worldcoord ,poalte,antem);
		AgvAbsoluteLocation agvlocation =new AgvAbsoluteLocation (ref agv );
		if (LidarMode .TargetDetectionState )//靶标探测模式
		{
			SingleAgv addbiaoba=new SingleAgv (agv);
		}
		}
        GC.Collect();
        }
	/// <summary>
	/// 
	/// </summary>
	/// <param name="itenn"></param>
	/// <returns></returns>
	void  GetBatter(TheLightNode [] itenn,int [] poalte, float [] antem)
	{
		
		if (itenn .Length >=3&&agv .IsBatter .Count ==0)
		{
		  for (int i=0;i<itenn .Length ;i ++)
		  {
			//识别的用于计算的反光柱不能多余5个,否则计算速度会很慢
			if (itenn [i]!=null &&itenn[i].Polar !=0 && itenn [i].Angle !=0&&agv .IsBatter .Count <=5)//为了防止计算缓慢
			{
			double [] batter=new double[5] ;
			batter [0]=itenn[i].NumberNo ;
			batter [1]=itenn[i].X ;
			batter [2]=itenn[i].Y ;
			batter [3]=antem[i];
			batter [4]=poalte[i];
			agv.IsBatter.Add (batter);	
			}	
		  }
		  if (agv .DisIsBatter .Count ==0)
		  {
		  	agv .DisIsBatter .AddRange (agv .IsBatter );
		  }
		}
		if(LidarMode .TargetDetectionState )
		{
			//添加未识别到的反光柱的坐标信息集合
			
		if (agv .IsBatter .Count >=3&&agv .NotBatter .Count ==0)
		{
			for (int j=0;j<itenn .Length ;j++)
			{
				if (itenn [j]!=null &&itenn[j].X==0 && itenn [j].Y ==0&&poalte[j]!=0)
				{
					double [] batter=new double[5] ;
					batter [0]=G .NODE.Length +agv .NotBatter .Count +1 ;//0
			        batter [1]=itenn [j].X ;//0
			        batter [2]=itenn [j].Y ;//0
			        batter [3]=antem[j] ;
			        batter [4]=poalte [j];
			        agv.NotBatter .Add (batter );
				}
			}
		  }
		}
	}
	/// <summary>
	/// 根据极轴和极坐标获取任意两个反光柱之间的距离
	/// </summary>
	double [,] GetEdge(int  [] polarte,float  [] anglete)
	{
		double [,] edge =new double[polarte.Length ,polarte .Length ] ;
		if (polarte .Length ==anglete .Length )
		{
		for (int i=0;i<polarte .Length  ;i++)
		{
			for (int j=0;j <polarte .Length   ;j++)
			{
				if (i !=j )
				{
					edge [i ,j ]=Math .Sqrt (Math .Pow (polarte [i],2)+Math .Pow (polarte [j],2) -2*polarte[i]*polarte[j] * Math .Cos (Math .PI * (anglete [i]-anglete [j])  /180));
				}
			}
		  }
	    }
		return edge ;
	}	
}
/*
 *读写反光柱信息 
 */
public class RWTheLight
{
	public RWTheLight ()
	{
		
	}
	  void WriteText(string path,string str)
     {
            FileStream fs = new FileStream(path ,FileMode.Create);
            byte[] data = System.Text.Encoding.Default.GetBytes(str);
            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
     }
	/// <summary>
	/// 保存反光柱的信息
	/// </summary>
	/// <param name="list"></param>
	public  void WriteTheLightMsg(List <TheLightNode> list)
	{
		string path =Application .StartupPath +@"\TheLightInformation.ini";
		string jso=""; 
		foreach (TheLightNode item  in list )
		{
			jso +=JsonConvert .SerializeObject (item)  +"\r\n";
		}
		WriteText (path ,jso );
	}
	/// <summary>
	/// 加载反光柱的图层
	/// </summary>
	/// <returns></returns>
   public static GraphAevironment  LoadTheLightMsg()
	{
		GraphAevironment graph=null ;
		try 
		{
			string[] read = File.ReadAllLines(Application .StartupPath+@"\TheLightInformation.ini");
			graph=new GraphAevironment (read .Length );
			double [,] TEM=new double[read .Length,read .Length] ;
			for (int i=0;i<read .Length ;i++)
			{
				TheLightNode node =JsonConvert .DeserializeObject<TheLightNode >(read [i]);
				graph .SetNode (node .NumberNo-1,node );//添加节点
			}
			for (int J=0;J<graph .NODE .Length ;J ++)
			{
				for (int K=J ;K <graph .NODE .Length ;K ++)
				{
					if (J !=K )
					{
						double len=Math .Sqrt (Math .Pow (graph.NODE[J].Polar  ,2 )+Math .Pow (graph .NODE [K ].Polar ,2)-2*graph.NODE[J].Polar*graph.NODE[K].Polar* Math .Cos (Math .PI * (graph.NODE[J].Angle -graph.NODE[K].Angle)/180));
						graph .SetMatrix (J ,K ,len );//添加边
					}
				}
			}
		TEM=graph .MATRIX ;	
		}
		
		catch (Exception ex)
		{
			MessageBox .Show (ex .ToString ());
		}
		return  graph ;
	}
}
public class CreateMark//建图
{
	private double[] Polar;
	private double[] Angle;
	private AGV agv ;
	public  List <TheLightNode > nodelist =new List<TheLightNode> ();
	public  List <TheLightNode > isnodelist =new List<TheLightNode> ();
	public  List <TheLightNode > notnodelist =new List<TheLightNode> ();
	public CreateMark (double[] poaler,double[] angle)
	{
		Polar =new double[poaler .Length ] ;
		Angle =new double[poaler .Length ] ;
		this .Polar =poaler;
		this .Angle =angle ;
		ComputeMag();
	}
	public CreateMark ()
	{
		
	}
	/// <summary>
	/// 计算获取靶标
	/// </summary>
	/// <param name="poaler"></param>
	/// <param name="angle"></param>
	public void GetBaBiao(int[]  poaler,float [] angle,AGV agvtem)
	{
		this.agv =agvtem;
		Polar =new double[poaler .Length ] ;
		Angle =new double[poaler .Length ] ;
		Array .Copy (poaler ,0,Polar ,0,poaler .Length );
		Array .Copy (angle ,0,Angle ,0,angle .Length );
		ComputeMag();
	}
	/// <summary>
	/// 获取靶标
	/// </summary>
	/// <param name="agv"></param>
	public void GetBaBiao(AGV agv)
	{
		try {
		if (agv !=null )
		{
		this .agv =agv ;
		if (agv .Polar !=null )
		{
		Polar =new double[agv .Polar.Length  ] ;
		Angle =new double[agv .Angle .Length ] ;
		Array .Copy (agv .Polar ,0,Polar ,0,agv .Polar .Length );
		Array .Copy (agv .Angle  ,0,Angle ,0,agv .Angle  .Length );
		if (LidarMode .GraphCreateState )
       {
		for (int i=0;i<Polar .Length ;i++ )
		{
			TheLightNode node =new TheLightNode ();
			if (Polar [i]!=0&&Polar [i]!=0)
			{
			node .X =Polar [i] *Math .Cos (Math .PI*Angle [i]/180);
			node .Y =Polar [i] *Math .Sin (Math .PI*Angle [i]/180);
			node .NumberNo =(byte)(nodelist.Count +1 );
			node .Angle =Angle [i];
			node .Polar  =Polar [i];
			nodelist .Add (node);
			}
		 }
       }
        else 
       {
       	if (LidarMode .IsNavicationMode )
      	{
       		List <double []> isbarrerlist=new List<double[]> ();
       		if (isbarrerlist.Count ==0)
       		{
		    isbarrerlist .AddRange (agv.DisIsBatter  );	 
       		}
            agv .DisIsBatter .Clear ();		    
		    for (int i=0;i<isbarrerlist .Count ;i++)
		    {
			TheLightNode node=new TheLightNode ();
			if (isbarrerlist !=null  )
			{ 
				if (isbarrerlist [i][0]!=0 && isbarrerlist [i][1]!=0)
				{
				node .X =isbarrerlist [i][1];
				node .Y =isbarrerlist [i][2];
				node .NumberNo =(byte )isbarrerlist [i][0];
				node .Angle =isbarrerlist [i][3];
				node .Polar =isbarrerlist [i][4];
				isnodelist .Add (node);	
				}
				}
		   }
		   
       	}
       	if (LidarMode .TargetDetectionState )
		{
       		List <double []> isbarrerlist=new List<double[]> ();
		    if (isbarrerlist.Count ==0)
       		{
		    isbarrerlist .AddRange (agv.DisIsBatter  );	 
       		}   
		    for (int i=0;i<isbarrerlist .Count ;i++)
		    {
			TheLightNode node=new TheLightNode ();
			if (isbarrerlist !=null  )
			{ 
				if (isbarrerlist [i][0]!=0 && isbarrerlist [i][1]!=0)
				{
				node .X =isbarrerlist [i][1];
				node .Y =isbarrerlist [i][2];
				node .NumberNo =(byte )isbarrerlist [i][0];
				node .Angle =isbarrerlist [i][3];
				node .Polar =isbarrerlist [i][4];
				isnodelist .Add (node);	
				}
			  }
		   }
          List <double []> notbarrerlist=new List<double[]> ();
          if (notnodelist .Count ==0)
          {
          	notbarrerlist .AddRange (agv.NotBatter  );
          } 
		    for (int i=0;i<notbarrerlist .Count ;i++)
		    {
			TheLightNode node=new TheLightNode ();
			if (notbarrerlist !=null && notbarrerlist [i][0]!=0 && notbarrerlist [i][1]!=0)
			{ 
				node .X =notbarrerlist [i][1];
				node .Y =notbarrerlist [i][2];
				node .NumberNo =(byte )notbarrerlist [i][0];
				node .Angle =notbarrerlist [i][3];
				node .Polar =notbarrerlist [i][4];
				notnodelist .Add (node);	
			}
		   }
		      agv .DisIsBatter .Clear ();
		      agv .NotBatter .Clear ();
       	  }
       	
        }
		}
		}
	   }
		catch (Exception ex)
		{
			MessageBox .Show (ex .ToString ());
		}
	}
   	void  ComputeMag()
	{
      if (LidarMode .GraphCreateState )
      {
		for (int i=0;i<Polar .Length ;i++ )
		{
			TheLightNode node =new TheLightNode ();
			if (Polar [i]!=0&&Polar [i]!=0)
			{
			node .X =Polar [i] *Math .Cos (Math .PI*Angle [i]/180);
			node .Y =Polar [i] *Math .Sin (Math .PI*Angle [i]/180);
			node .NumberNo =(byte)(nodelist.Count +1 );
			node .Angle =Angle [i];
			node .Polar  =Polar [i];
			nodelist .Add (node);
			}
		}
      }
      else 
      {
      	if (LidarMode .IsNavicationMode )
      	{
      		for (int l=0;l<agv .IsBatter .Count ;l++)
      		{
      			if (agv.IsBatter[l][1]!=0&&agv .IsBatter [l][2]!=0)
      			{
      				TheLightNode node =new TheLightNode ();
				   node .NumberNo =(byte )agv .IsBatter [l][0];
				   node .X =agv .IsBatter [l][1];
				   node .Y =agv .IsBatter [l][2];
				   node .Angle =agv .IsBatter [l][3];
				   node .Polar =agv .IsBatter [l][4];
				   nodelist .Add (node );
      			}
      		}
      	}
      	if (LidarMode .TargetDetectionState )
		{
			for ( int j=0;j<agv .NotBatter .Count ;j++)
			{
				TheLightNode node =new TheLightNode ();
				node .NumberNo =(byte )agv .NotBatter [j][0];
				node .X =agv .NotBatter [j][1];
				node .Y =agv .NotBatter [j][2];
				node .Angle =agv .NotBatter [j][3];
				node .Polar =agv .NotBatter [j][4];
				nodelist .Add (node );
			}
		}
      }
		
	}
	/// <summary>
	/// 创建标靶
	/// </summary>
	/// <returns></returns>
	public bool  WriteTxt(List <TheLightNode >nolist)
	{
		bool res=false; 
		try 
		{
		RWTheLight item =new RWTheLight ();
		item .WriteTheLightMsg (nolist );
		res =true ;
		}
		catch (Exception ex)
		{
			res =false ;
		}
		return res ;
		
	}
	
}

}
	



