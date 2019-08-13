/*
 * Created by SharpDevelop.
 * User: ZJUCAOBIN
 * Date: 2019/3/18
 * Time: 20:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System .IO ;
using System .Text ;
using System  .Threading ;
using Newtonsoft ;
using System.Data ;
using System .Linq ;
using System .Net ;
using System .Net .Sockets;
using Newtonsoft .Json;
using System .Net .NetworkInformation ;
using System .Collections .Generic;
namespace P_F_Interface
{
	/// <summary>
	/// Description of HttpClass.
	/// </summary>
	public class HttpHandle
	{
		private  string jsonData;
		public string JsonData
		{
			get {return jsonData ;}	
		}
		private  int  error_code;
		public int Error_Code
		{
			get {return error_code; }
		}
		private  string error_text;
		public string Error_Text
		{
			get {return error_text;}
		}
		private   bool   state;
		public  bool State
		{
			get {return state ;}
		}
		private string ip;
		public string IP
		{
			get {return ip ;}
		}
		private double  port;
		public  double   Port
		{    
			get {return port ;}	
			
		}
		private  string handle;
		public   string Handle
		{
			get  {return handle;}
		}
		
		public HttpHandle(string jsonstr,string ipe)
		{
			if (jsonstr !="")
			{
				this .jsonData =jsonstr ;
				this .ip =ipe ;
			
				DealJsonData(jsonData );
				
			}	
		}
		/// <summary>
		/// 反序列化
		/// </summary>
		/// <param name="jsonstr"></param>
		void  DealJsonData(string jsonstr)
		{
			
			dynamic objitem =JsonConvert.DeserializeObject <dynamic>(jsonstr) ;
			string errocodetem=Convert .ToString (objitem ["error_code"]);
			if (errocodetem !="0")
			{
				port =0;
				handle ="";
				error_code =Convert .ToInt16(errocodetem );
				error_text =Convert .ToString (objitem ["error_text"]);
				state =false; 
			}
			else 
			{
				string porttem =Convert .ToString   (objitem ["port"]);
			    port =Convert .ToDouble (porttem) ;
			    handle =Convert .ToString (objitem ["handle"]);
			    error_code =Convert .ToInt16(errocodetem );
				error_text =Convert .ToString (objitem ["error_text"]);
				state =true ;
			}
			
		}
	}
	public class OutPutConfig
	{
	    private  string jsonData;
		public string JsonData
		{
			get {return jsonData ;}	
		}
		private string address;
		public string Address
		{
			get {return address ;}
			set {address =value ;}
		}
		private double  port;
		public  double   Port
		{    
			get {return port ;}	
		}
		private string watchdog;
		public string Watchdog
		{
			get {return watchdog ;}
			set {watchdog =value ;}
		}
		private  double  watchdogtimeout;
		public double Watchdogtimeout
		{
			get {return watchdogtimeout ;}
			set {watchdogtimeout =value ;}
		}
		private string  packet_type;
		public string Packet_type
		{
			get {return packet_type ;}
			set {packet_type =value ;}
		}
		private  double start_angle;
		public double Start_angle
		{
			get {return start_angle ;}
			set {start_angle =value ;}
			  
		}
		private int error_code;
		public int Error_Code
		{
			get {return error_code; }
		}
		private  string error_text;
		public string Error_Text
		{
			get {return error_text;}
		}
		private bool  state;
		public  bool State
		{
			get {return state ;}
		}
			
		
		public OutPutConfig (string jsonstr)
		{
			if (jsonData !="")
			{
				this .jsonData =jsonstr ;
			}
		}
		/// <summary>
		/// 反序列化
		/// </summary>
		/// <param name="jsonstr"></param>
		void  DealJsonData(string jsonstr)
		{
			
			dynamic objitem =JsonConvert.DeserializeObject <dynamic>(jsonstr) ;
			string errocodetem=Convert .ToString (objitem ["error_code"]);
			if (errocodetem !="0")
			{
				
				error_code =Convert .ToInt16(errocodetem );
				error_text =Convert .ToString (objitem ["error_text"]);
				state =false; 
			}
			else 
			{
				string porttem =Convert .ToString   (objitem ["port"]);
				string angeltem=Convert .ToString (objitem ["start_angle"]);
				string watchdogtime=Convert .ToString (objitem ["watchdogtimeout"]);
				watchdog =Convert .ToString (objitem ["watchdog"]);
				watchdogtimeout =Convert .ToDouble (watchdogtime);
				packet_type =Convert .ToString (objitem ["packet_type"]);
				address =Convert .ToString (objitem ["address"]);	
				start_angle=Convert .ToDouble (angeltem );
			    port =Convert .ToDouble (porttem);
			    error_code =Convert .ToInt16(errocodetem );
				error_text =Convert .ToString (objitem ["error_text"]);
				state =true ;
			}
			
		}
	}
}
