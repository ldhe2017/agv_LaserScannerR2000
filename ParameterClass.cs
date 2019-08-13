/*
 * Created by SharpDevelop.
 * User: ZJUCAOBIN
 * Date: 2019/4/16
 * Time: 13:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Newtonsoft.Json;
using System .Linq ;
using System .IO ;
using  System .Windows .Forms;
using System .Threading ;
namespace P_F_Interface
{
	/// <summary>
	/// Description of PrarmeterClass.
	/// </summary>
	public class ParameterClass
	{
		public ParameterClass()
		{
			
		}
		public ParameterClass  (string path )
		{
			GetParaJson (path );
		}
		/// <summary>
		/// 读取配置信息
		/// </summary>
		/// <param name="path"></param>
		public void GetParaJson(string path )
		{
			//string [] json =File .ReadAllLines (Application .StartupPath +@"\ParameterSet.ini");
			string [] json =File .ReadAllLines (path );
			ParameterClass  item =JsonConvert .DeserializeObject <ParameterClass >(json[0]);
			Para .LidarIP =item .LidarIP ;
			Para .WathchDogTimeOut =item .WathchDogTimeOut ;
			Para .PackType =item .PackType ;
			Para .TheoryPointNum =item .TheoryPointNum ;
			Para .XYERROR =item .XYERROR ;
			Para .LENERROR =item .LENERROR ;
			Para .ANGLEFILTER =item .ANGLEFILTER ;
			Para .MAXDISTANCE =item.MAXDISTANCE ;	
			Para .FilterType =item .FilterType ;
			Para .FilterWidth =item .FilterWidth ;
			Para .TIMETOLERANCE =item .TIMETOLERANCE ;
			if (Para .FilterType == "remission")
			{
				Para .AngleResolution =(float )1.600;//用于获取滤波后的定位数据
				
				LidarMode .IsNavicationMode =true ;
				
				
			}
			else  if (Para .FilterType=="none")
			{
				Para .AngleResolution =(float )0.100;//用于获取未进行滤波的轮廓数据
				LidarMode .IsNavicationMode =false ;
			}
			float tem =360/Para .AngleResolution ;
			Para .PackageNum =(int )tem ;
		}
		/// <summary>
		/// 设置信息
		/// </summary>
		/// <param name="strjson"></param>
		/// <returns></returns>
		public bool  WritePara(ParameterClass  strjson)
		{
			try 
			{
				FileStream file=new FileStream (Application .StartupPath +@"\ParameterSet.ini",FileMode .Create );
				string str=JsonConvert .SerializeObject (strjson );
				byte [] data =System .Text .ASCIIEncoding .Default .GetBytes (str );
				file .Write (data,0,data .Length );
				file .Flush ();
				file .Close ();
			}
			catch (Exception ex)
			{
				return false ;
			}
			return  true ;
		}
		/// <summary>
		///激光雷达的IP地址
		/// </summary>
		public string LidarIP{get ;set ;}
		/// <summary>
		/// 激光雷达的数据类型 默认为A；
		/// </summary>
		public string  PackType{get ;set ;}
		/// <summary>
		/// 激光雷达的理论最大输出点云点的数量
		/// </summary>
		public int TheoryPointNum{get ;set ;}
		/// <summary>
		/// 激光雷达看门狗超时时间间隔
		/// </summary>
		public int WathchDogTimeOut{get ;set ;}
		/// <summary>
		/// 滤波类型
		/// </summary>
		public string FilterType{get ;set ;}
		/// <summary>
		/// 滤波宽度
		/// </summary>
		public int FilterWidth{get ;set ;}
	    /// <summary>
	    ///激光雷达识别已存储反光柱的偏差阀值1
	    /// </summary>
	    public  int XYERROR {get ;set ;}
        /// <summary>
        /// 激光雷达识别已存储反光柱的偏差阀值2
        /// </summary>
        public  int LENERROR{get ;set ;}
	    /// <summary>
	    /// 激光雷达识别已存储反光柱滤波阀值1
	    /// </summary>
	    public  int ANGLEFILTER{get ;set ;}
	    /// <summary>
	    /// 激光雷达识别已存储反光柱最大距离 
	    /// </summary>
	    public int MAXDISTANCE{get ;set ;}
	    /// <summary>
	    /// 反光柱识别响应时间容差
	    /// </summary>
	    public int TIMETOLERANCE{get ;set ;}
		
	}
    class Para
	{
		/// <summary>
		///激光雷达的IP地址
		/// </summary>
		public static string LidarIP;
		/// <summary>
		/// 激光雷达的数据类型 默认为A；
		/// </summary>
		public static string  PackType;
		/// <summary>
		/// 激光雷达的理论最大输出点云点的数量
		/// </summary>
		public  static int TheoryPointNum;
		/// <summary>
		/// 激光雷达看门狗超时时间间隔
		/// </summary>
		public static int WathchDogTimeOut;
		/// <summary>
		/// 滤波类型
		/// </summary>
		public static string FilterType;
		/// <summary>
		/// 滤波宽度
		/// </summary>
		public static  int FilterWidth;
		/// <summary>
		/// 角度分辨率
		/// </summary>
		public static float AngleResolution;
		/// <summary>
		///单圈数据个数
		/// </summary>
		public static int   PackageNum;
	    /// <summary>
	    ///激光雷达识别已存储反光柱的偏差阀值1
	    /// </summary>
	    public static  int XYERROR ;
        /// <summary>
        /// 激光雷达识别已存储反光柱的偏差阀值2
        /// </summary>
        public static  int LENERROR;
	    /// <summary>
	    /// 激光雷达识别已存储反光柱滤波阀值1
	    /// </summary>
	    public  static int ANGLEFILTER;
	    /// <summary>
	    /// 激光雷达识别已存储反光柱最大距离 
	    /// </summary>
	    public static  int MAXDISTANCE;
	     /// <summary>
	    /// 反光柱识别响应时间容差
	    /// </summary>
	    public static int TIMETOLERANCE;
	}
     class LidarMode
	{
     	/// <summary>
     	/// 导航模式（true）/轮廓数据获取（false）
     	/// </summary>
     	public static  bool IsNavicationMode;
     	/// <summary>
     	/// 靶标探测模式（true）/其他模式（false）
     	/// </summary>
     	public static bool TargetDetectionState;
     	/// <summary>
     	/// 建图模式（true）/其他模式（false）(至少三个靶标以上)
     	/// </summary>
     	public static bool GraphCreateState;
	}
}
