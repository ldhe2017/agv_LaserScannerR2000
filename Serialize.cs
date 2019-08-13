/*
 * Created by SharpDevelop.
 * User: ZJUCAOBIN
 * Date: 2019/3/19
 * Time: 16:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Newtonsoft .Json;
using System .IO ;
using System .Linq ;
namespace P_F_Interface
{
	/// <summary>
	/// Description of Serialize.
	/// </summary>
	public class Serialize
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
		public Serialize(string jsonstr)
		{
			if (jsonstr!="")
			{
				this .jsonData =jsonstr;
				DealJsonData(jsonstr);
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
			    error_code =Convert .ToInt16(errocodetem );
				error_text =Convert .ToString (objitem ["error_text"]);
				state =true ;
			}
			
		}
	}
}
